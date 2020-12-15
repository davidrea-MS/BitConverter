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
            Assert.IsFalse(EndianBitConverter.BigEndian.IsLittleEndian);
            Assert.IsTrue(EndianBitConverter.LittleEndian.IsLittleEndian);
        }
    }
}
