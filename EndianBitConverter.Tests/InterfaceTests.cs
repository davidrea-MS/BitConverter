// Copyright (C) Microsoft Corporation. All rights reserved.

namespace EndianBitConverter.Tests
{
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InterfaceTests
    {
        [TestMethod]
        public void IsLittleEndian()
        {
            //big-endian
            Assert.IsFalse(EndianBitConverter.BigEndian.IsLittleEndian);
            Assert.IsFalse(EndianBitConverter.BigEndian.IsMid);

            //mid big-endian
            Assert.IsFalse(EndianBitConverter.MidBigEndian.IsLittleEndian);
            Assert.IsTrue(EndianBitConverter.MidBigEndian.IsMid);

            //little-endian
            Assert.IsTrue(EndianBitConverter.LittleEndian.IsLittleEndian);
            Assert.IsFalse(EndianBitConverter.LittleEndian.IsMid);

            //mid little-endian
            Assert.IsTrue(EndianBitConverter.MidLittleEndian.IsLittleEndian);
            Assert.IsTrue(EndianBitConverter.MidLittleEndian.IsMid);
        }
    }
}
