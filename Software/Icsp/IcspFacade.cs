using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ApProg.Utilities;

namespace ApProg.Icsp
{
    public class IcspFacade
    {
        private readonly IIcspService myIcsp;

        public IcspFacade(IIcspService icsp)
        {
            myIcsp = icsp;
        }

        public bool EnterIcsp()
        {
            return myIcsp.EnterIcsp(0x4d434851) &&
                   myIcsp.SendSix(0x000000) &&
                   myIcsp.SendSix(0x040200) &&
                   myIcsp.SendSix(0x000000);
        }

        public bool ExitIcsp()
        {
            return myIcsp.ExitIcsp();
        }

        public string ReadDeviceId()
        {
            ushort devId, revId;
            if (EnterIcsp() &&

            myIcsp.SendSix(0x200FF0) &&
            myIcsp.SendSix(0x880190) &&
            myIcsp.SendSix(0x200006) &&

            myIcsp.SendSix(0x207847) &&
            myIcsp.SendSix(0x000000) &&

            myIcsp.SendSix(0xBA0B96) &&
            myIcsp.SendSix(0x000000) &&
            myIcsp.SendSix(0x000000) &&
            myIcsp.SendRegout(out devId) &&
            myIcsp.SendSix(0x000000) &&

            myIcsp.SendSix(0xBA0BB6) &&
            myIcsp.SendSix(0x000000) &&
            myIcsp.SendSix(0x000000) &&
            myIcsp.SendRegout(out revId) &&
            myIcsp.SendSix(0x000000) &&

            myIcsp.ExitIcsp())
                return string.Format("Device Id: 0x{0:X4}\r\nRevision Id: {1:X4}\r\n", devId, revId);
            return "Device did not respond correctly";
        }

        public string ReadApplicationId()
        {
            return "ToDo...";
        } 

        public void EraseFlash()
        {
            EnterIcsp();

            myIcsp.SendSix(0x2404FA);
            myIcsp.SendSix(0x883B0A);

            myIcsp.SendSix(0x200000);
            myIcsp.SendSix(0x880190);
            myIcsp.SendSix(0x200000);
            myIcsp.SendSix(0xBB0800);
            myIcsp.SendSix(0x000000);
            myIcsp.SendSix(0x000000);

            myIcsp.SendSix(0xA8E761);
            myIcsp.SendSix(0x000000);
            myIcsp.SendSix(0x000000);

            Thread.Sleep(2000); //Wait P10 + P11

            myIcsp.SendSix(0x000000);
            myIcsp.SendSix(0x040200);
            myIcsp.SendSix(0x000000);
            ExitIcsp();
        }

        public IEnumerable<uint> ReadFlash(Action<string> act)
        {
            throw new NotImplementedException("ToDo...");
        }

        public void WriteFlash(IEnumerable<uint> instrs, Action<int, string> act)
        {
            List<uint> instructions = new List<uint>(instrs);
            EnterIcsp();
            for (int index = 0; index + 64 <= instructions.Count; index += 64)
            {
                List<uint> instr = instructions.GetRange(index, 64);
                // write only pages which contains some instructions
                if (instr.Any(inst => inst != 0x00FFFFFF))
                {
                    act(index*100/instructions.Count, string.Format("Writing 64 instructions at: 0x{0:X8}...", index*2));
                    WriteInstructions(index*2, instr);
                }
            }
            ExitIcsp();
        }

        public IEnumerable<uint> ReadInstructions(int address)
        {
            uint[] instr = new uint[2];
            ushort result;
            myIcsp.SendSix(0x200000 | ((uint) address).Msb() << 4);
            myIcsp.SendSix(0x880190);
            myIcsp.SendSix(0x200006 | ((uint)address).Lsw() << 4);

            myIcsp.SendSix(0x207847);
            myIcsp.SendSix(0x000000);

            myIcsp.SendSix(0xBA0B96);
            myIcsp.SendSix(0x000000);
            myIcsp.SendSix(0x000000);
            myIcsp.SendRegout(out result);
            myIcsp.SendSix(0x000000);
            instr[0] |= result;            

            myIcsp.SendSix(0xBADBB6);
            myIcsp.SendSix(0x000000);
            myIcsp.SendSix(0x000000);
            myIcsp.SendSix(0xBAD3D6);
            myIcsp.SendSix(0x000000);
            myIcsp.SendSix(0x000000);
            myIcsp.SendRegout(out result);
            myIcsp.SendSix(0x000000);
            instr[0] |= (uint)((result & 0x00FF) << 16);
            instr[1] |= (uint)((result & 0xFF00) << 8);

            myIcsp.SendSix(0xBA0BB6);
            myIcsp.SendSix(0x000000);
            myIcsp.SendSix(0x000000);
            myIcsp.SendRegout(out result);
            myIcsp.SendSix(0x000000);
            instr[1] |= result;

            return instr;
        }

        /// <summary>
        /// Writes instructions according to: 3.6 Writing Code Memory...
        /// </summary>
        /// <returns>message</returns>
        public void WriteInstructions(int address, IList<uint> inst)
        {
            // Step 2: Set the NVMCON to program 64 instr. words
            myIcsp.SendSix(0x24001A);
            myIcsp.SendSix(0x883B0A);

            // Step 3:
            myIcsp.SendSix(0x200000 | ((uint) address).Msb() << 4);
            myIcsp.SendSix(0x880190);
            myIcsp.SendSix(0x200007 | ((uint) address).Lsw() << 4);

            // Step 4-6: Write 64 (16*4 packed) instructions
            for (int index = 0; index < 64; index += 4)
            {
                myIcsp.SendSix(0x200000 | inst[index].Lsw() << 4);
                myIcsp.SendSix(0x200001 | (inst[index + 1].Msb() << 8 | inst[index].Msb()) << 4);
                myIcsp.SendSix(0x200002 | inst[index + 1].Lsw() << 4);
                myIcsp.SendSix(0x200003 | inst[index + 2].Lsw() << 4);
                myIcsp.SendSix(0x200004 | (inst[index + 3].Msb() << 8 | inst[index + 2].Msb()) << 4);
                myIcsp.SendSix(0x200005 | inst[index + 3].Lsw() << 4);

                myIcsp.SendSix(0xEB0300);
                myIcsp.SendSix(0x000000);
                for (int latch = 0; latch < 2; latch++)
                {
                    myIcsp.SendSix(0xBB0BB6);
                    myIcsp.SendSix(0x000000);
                    myIcsp.SendSix(0x000000);
                    myIcsp.SendSix(0xBBDBB6);
                    myIcsp.SendSix(0x000000);
                    myIcsp.SendSix(0x000000);
                    myIcsp.SendSix(0xBBEBB6);
                    myIcsp.SendSix(0x000000);
                    myIcsp.SendSix(0x000000);
                    myIcsp.SendSix(0xBB1BB6);
                    myIcsp.SendSix(0x000000);
                    myIcsp.SendSix(0x000000);
                }
            }

            // Step 7: Initiate write cycle
            myIcsp.SendSix(0xA8E761);
            myIcsp.SendSix(0x000000);
            myIcsp.SendSix(0x000000);

            // Step 8: Poll WR bit
            ushort nvmcon;
            do
            {
                myIcsp.SendSix(0x040200);
                myIcsp.SendSix(0x000000);
                myIcsp.SendSix(0x803B02);
                myIcsp.SendSix(0x883C22);
                myIcsp.SendSix(0x000000);
                myIcsp.SendRegout(out nvmcon);
                myIcsp.SendSix(0x000000);
                Thread.Sleep(50);
            } while ((nvmcon & 0x8000) == 0x8000);

            // Reset device
            myIcsp.SendSix(0x040200);
            myIcsp.SendSix(0x000000);
        }
    }
}
