using System.Collections.Generic;

namespace ApProg.Utilities
{
    public static class ByteConversion
    {
        public static uint MsbToLsb(this uint code)
        {
            uint result = 0;
            uint mask = 1;
            while (mask != 0)
            {
                result <<= 1;
                result |= (code & mask) > 0 ? 1u : 0;
                mask <<= 1;
            }
            return result;
        }

        public static byte[] ToBytes(this uint instr)
        {
            return new[]{(byte) instr, (byte) (instr >> 8), (byte) (instr >> 16), (byte)(instr >> 24)};
        }

        public static uint ToUint(this List<byte> bytes, int index)
        {
            return (uint)(bytes[index] | bytes[index + 1] << 8 | bytes[index + 2] << 16 | bytes[index + 3] << 24);
        }

        public static uint Msb(this uint instr)
        {   
            return (instr & 0x00FF0000) >> 16 ;
        }

        public static uint Lsw(this uint instr)
        {
            return instr & 0x0000FFFF;
        }
    }
}
