using System;
using System.Globalization;
using System.IO;

namespace ApProg.Utilities
{
    public class HexReader
    {
        public static Memory ReadHexFile(string filename)
        {
            if(!File.Exists(filename))
                throw new InvalidOperationException("File does not exist!");

            int baseAddress = 0;
            Memory memory = new Memory();
            foreach (string line in File.ReadAllLines(filename))
            {
                if(line[0] != ':')
                    throw new InvalidOperationException("File does not look like a valid Hex file...");

                byte lenght = byte.Parse(line.Substring(1, 2), NumberStyles.HexNumber);
                int address = int.Parse(line.Substring(3, 4), NumberStyles.HexNumber);
                byte recType = byte.Parse(line.Substring(7, 2), NumberStyles.HexNumber);

                if(recType == 0x00) // data record
                    memory.AddFromString(baseAddress | address, line.Substring(9, lenght * 2));

                if(recType == 0x01) // end of record
                    break;

                if(recType == 0x04) // extended address
                {
                    baseAddress = int.Parse(line.Substring(9, 4), NumberStyles.HexNumber);
                    baseAddress <<= 16;
                }
            }
            return memory;
        }
    }
}
