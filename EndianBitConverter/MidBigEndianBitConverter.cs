// Copyright (C) Microsoft Corporation. All rights reserved.

namespace EndianBitConverter
{
    /// <summary>
    /// A mid big-endian BitConverter that converts base data types to an array of bytes, and an array of bytes to base data types. 
    /// All conversions are in mid big-endian format regardless of machine architecture.
    /// </summary>
    internal class MidBigEndianBitConverter : EndianBitConverter
    {
        // Instance available from EndianBitConverter.BigEndian
        internal MidBigEndianBitConverter() { }

        public override bool IsLittleEndian { get; } = false;
        public override bool IsMid { get; } = true;


        public override byte[] GetBytes(short value)
        {
            return new byte[] { (byte)(value >> 8), (byte)value };
        }

        public override byte[] GetBytes(int value)
        {
            return new byte[] { (byte)(value >> 16), (byte)(value >> 24), (byte)value, (byte)(value >> 8) };
        }

        public override byte[] GetBytes(long value)
        {
            return new byte[] {
                (byte)(value >> 48), (byte)(value >> 56), (byte)(value >> 32), (byte)(value >> 40),
                (byte)(value >> 16), (byte)(value >> 24), (byte)value, (byte)(value >> 8)
            };
        }

        public override short ToInt16(byte[] value, int startIndex)
        {
            this.CheckArguments(value, startIndex, sizeof(short));

            return (short)((value[startIndex] << 8) | (value[startIndex + 1]));
        }

        public override int ToInt32(byte[] value, int startIndex)
        {
            this.CheckArguments(value, startIndex, sizeof(int));

            return (value[startIndex] << 16) | (value[startIndex + 1] << 24) | (value[startIndex + 2]) | (value[startIndex + 3] << 8);
        }

        public override long ToInt64(byte[] value, int startIndex)
        {
            this.CheckArguments(value, startIndex, sizeof(long));

            int highBytes = (value[startIndex] << 16) | (value[startIndex + 1] << 24) | (value[startIndex + 2]) | (value[startIndex + 3] << 8);
            int lowBytes = (value[startIndex + 4] << 16) | (value[startIndex + 5] << 24) | (value[startIndex + 6]) | (value[startIndex + 7] << 8);
            return ((uint)lowBytes | ((long)highBytes << 32));
        }
    }
}
