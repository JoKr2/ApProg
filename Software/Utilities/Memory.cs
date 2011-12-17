using System.Collections.Generic;
using System.Globalization;

namespace ApProg.Utilities
{
    public class Memory
    {
        readonly List<byte> myBytes = new List<byte>();

        public IEnumerable<uint> Instructions
        {
            get
            {
                for (int addr = 0; addr + 4 <= myBytes.Count; addr += 4)
                    yield return myBytes.ToUint(addr);
            }
        }

        public void AddFromString(int address, string hexData)
        {
            while (myBytes.Count < address)
                myBytes.Add(0xFF);

            for (int index = 0; index < hexData.Length / 2; index++)
            {
                byte bb = byte.Parse(hexData.Substring(index * 2, 2), NumberStyles.HexNumber);
                if (myBytes.Count > address + index)
                    myBytes.Insert(address + index, bb);
                else
                    myBytes.Add(bb);
            }
        }
    }
}