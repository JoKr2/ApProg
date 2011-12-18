using System.IO.Ports;
using ApProg.Utilities;

namespace ApProg.Icsp
{
    public interface IIcspService
    {
        bool IsConnected { get; }
        bool Connect(ComPortParams portParams);
        void Disconnect();
        bool EnterIcsp(uint code);
        bool ExitIcsp();
        bool SendSix(uint instr);
        bool SendRegout(out ushort instr);
    }

    /// <summary>
    /// Talks to AVR device via serial port
    /// 
    /// Communication protocol: Command -> Action
    /// 0x0X -> Replies 0x0X
    /// 0x1X -> Sets MCLR to X
    /// 0x2X -> Clocks next 4 bits via PGD
    /// 0x3X -> Clocks Low X times via PGD
    /// 0x4X -> Clocks High X times via PGD
    /// 0x5X -> Clocks next X bytes via PGD
    /// 0x6X -> Reads next X bytes from PGD
    /// </summary>
    /// <remarks>Icsp pins are: PGC, PGD, MCLR</remarks>
    public class IcspService : IIcspService
    {
        private readonly SerialPort myPort;

        public bool IsConnected
        {
            get { return myPort.IsOpen; }
        }

        public IcspService()
        {
            myPort = new SerialPort("COM1");
        }

        public bool Connect(ComPortParams portParams)
        {
            if(myPort.IsOpen)
                myPort.Close();

            portParams.ConfigurePort(myPort);
            myPort.Open();

            myPort.DiscardInBuffer();
            for (byte aByte = 0; aByte < 10; aByte++)
            {
                myPort.Write(new[] {aByte}, 0, 1);
                if (aByte != myPort.ReadByte())
                {
                    Disconnect();
                    return false;
                }
            }
            return true;
        }

        public void Disconnect()
        {
            myPort.Close();
        }

        public bool EnterIcsp(uint code)
        {
            // The Icsp code is MSB first so convert it
            code = code.MsbToLsb();

            myPort.DiscardInBuffer();
            
            myPort.Write(new byte[] { 0x11 }, 0, 1); //mclr high
            if (myPort.ReadByte() != 0x01)
                return false;

            myPort.Write(new byte[] { 0x10 }, 0, 1); //mclr low
            if (myPort.ReadByte() != 0x01)
                return false;

            myPort.Write(new byte[] {0x54}, 0, 1);
            myPort.Write(code.ToBytes(), 0, 4);
            if (myPort.ReadByte() != 0x01)
                return false;

            myPort.Write(new byte[] { 0x11 }, 0, 1); //mclr high
            if (myPort.ReadByte() != 0x01)
                return false;

            myPort.Write(new byte[]{0x35}, 0, 1);
            return myPort.ReadByte() == 0x01;
        }

        public bool ExitIcsp()
        {
            myPort.Write(new byte[] { 0x10 }, 0, 1); //mclr low
            return myPort.ReadByte() == 0x01;
        }

        public bool SendSix(uint instr)
        {
            myPort.DiscardInBuffer();
            myPort.Write(new byte[] {0x20}, 0, 1); //six
            if (myPort.ReadByte() != 0x01)
                return false;

            myPort.Write(new byte[] {0x53}, 0, 1);
            myPort.Write(instr.ToBytes(), 0, 3);

            return myPort.ReadByte() == 0x01;
        }

        public bool SendRegout(out ushort instr)
        {
            instr = 0;
            myPort.DiscardInBuffer();
            myPort.Write(new byte[] { 0x21 }, 0, 1); //regout
            if (myPort.ReadByte() != 0x01)
                return false;

            myPort.Write(new byte[] {0x38}, 0, 1); // waste 8 bitss
            if (myPort.ReadByte() != 0x01)
                return false;

            myPort.Write(new byte[] { 0x62 }, 0, 1); //pin instruction
            instr = (ushort)(myPort.ReadByte() | myPort.ReadByte() << 8);

            return true;
        }
    }
}