using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace ApProg.Utilities
{
    public class ComPortParams
    {
        public string PortId { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public string Parity { get; set; }
        public string StopBits { get; set; }

        public IEnumerable<string> AvailablePorts
        {
            get { return SerialPort.GetPortNames(); }
        }

        public IEnumerable<int> BaudRates
        {
            get { return new[] { 9600, 14400, 19200, 38400, 57600, 115200 }; }
        }

        public IEnumerable<int> DataValues
        {
            get { return new[] { 7, 8 }; }
        }

        public IEnumerable<string> AvailableParity
        {
            get { return Enum.GetNames(typeof(Parity)); }
        }

        public IEnumerable<string> AvailableStopBits
        {
            get { return Enum.GetNames(typeof(StopBits)); }
        }

        public ComPortParams()
        {
            PortId = AvailablePorts.FirstOrDefault();
            BaudRate = 57600;
            DataBits = 8;
            Parity = AvailableParity.FirstOrDefault();
            StopBits = "One";
        }

        public void ConfigurePort(SerialPort port)
        {
            port.PortName = PortId;
            port.BaudRate = BaudRate;
            port.DataBits = DataBits;
            port.Parity = (Parity)Enum.Parse(typeof(Parity), Parity);
            port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBits);
            port.ReadTimeout = 500;
            port.ReadBufferSize = 4;
            port.WriteBufferSize = 4;
        }
    }
}
