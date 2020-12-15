namespace EndianBitConverter
{
    /// <summary>
    /// A mid little-endian BitConverter that converts base data types to an array of bytes, and an array of bytes to base data types. 
    /// All conversions are in mid little-endian format regardless of machine architecture.
    /// </summary>
    internal class MidLittleEndianBitConverter : EndianBitConverter
    {
        // Instance available from EndianBitConverter.MidLittleEndian
        internal MidLittleEndianBitConverter() { }

        public override bool IsLittleEndian { get; } = true;
        public override bool IsMid { get; } = true;


        public override byte[] GetBytes(short value)
        {
            return new byte[] { (byte)value, (byte)(value >> 8) };
        }

        public override byte[] GetBytes(int value)
        {
            return new byte[] { (byte)(value >> 8), (byte)value, (byte)(value >> 24), (byte)(value >> 16) };
        }

        public override byte[] GetBytes(long value)
        {
            return new byte[] {
                (byte)(value >> 8), (byte)value, (byte)(value >> 24), (byte)(value >> 16),
                (byte)(value >> 40), (byte)(value >> 32), (byte)(value >> 56), (byte)(value >> 48)
            };
        }

        public override short ToInt16(byte[] value, int startIndex)
        {
            this.CheckArguments(value, startIndex, sizeof(short));

            return (short)((value[startIndex]) | (value[startIndex + 1] << 8));
        }

        public override int ToInt32(byte[] value, int startIndex)
        {
            this.CheckArguments(value, startIndex, sizeof(int));

            return (value[startIndex] << 8) | (value[startIndex + 1]) | (value[startIndex + 2] << 24) | (value[startIndex + 3] << 16 );
        }

        public override long ToInt64(byte[] value, int startIndex)
        {
            this.CheckArguments(value, startIndex, sizeof(long));

            int lowBytes = (value[startIndex] << 8) | (value[startIndex + 1]) | (value[startIndex + 2] << 24) | (value[startIndex + 3] << 16);
            int highBytes = (value[startIndex + 4] << 8) | (value[startIndex + 5]) | (value[startIndex + 6] << 24) | (value[startIndex + 7] << 16);
            return ((uint)lowBytes | ((long)highBytes << 32));
        }
    }
}
