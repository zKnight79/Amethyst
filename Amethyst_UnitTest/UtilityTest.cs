using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amethyst;
using Amethyst.Math;
using System.IO;

namespace Amethyst_UnitTest
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void TestEncryption()
        {
            string clearText = "Hello World";
            string secretPassword = "ThisIsASecret";
            string encryptedText = Utility.Encryption.Encrypt(clearText, secretPassword);
            string decryptedText = Utility.Encryption.Decrypt(encryptedText, secretPassword);

            Assert.AreEqual(clearText, decryptedText);
        }

        [TestMethod]
        public void TestArrayResizing()
        {
            int[,] array_3x2 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            int[,] array_5x3 = Utility.Arrays.ResizeArray<int>(array_3x2, 5, 3);
            Assert.AreEqual(1, array_5x3[0, 0]);
            Assert.AreEqual(2, array_5x3[0, 1]);
            Assert.AreEqual(0, array_5x3[0, 2]);
            Assert.AreEqual(3, array_5x3[1, 0]);
            Assert.AreEqual(4, array_5x3[1, 1]);
            Assert.AreEqual(0, array_5x3[1, 2]);
            Assert.AreEqual(5, array_5x3[2, 0]);
            Assert.AreEqual(6, array_5x3[2, 1]);
            Assert.AreEqual(0, array_5x3[2, 2]);
            Assert.AreEqual(0, array_5x3[3, 0]);
            Assert.AreEqual(0, array_5x3[3, 1]);
            Assert.AreEqual(0, array_5x3[3, 2]);
            Assert.AreEqual(0, array_5x3[4, 0]);
            Assert.AreEqual(0, array_5x3[4, 1]);
            Assert.AreEqual(0, array_5x3[4, 2]);

            int[,] array_5x3_off_2_1 = Utility.Arrays.ResizeArray<int>(array_3x2, 5, 3, 2, 1);
            Assert.AreEqual(0, array_5x3_off_2_1[0, 0]);
            Assert.AreEqual(0, array_5x3_off_2_1[0, 1]);
            Assert.AreEqual(0, array_5x3_off_2_1[0, 2]);
            Assert.AreEqual(0, array_5x3_off_2_1[1, 0]);
            Assert.AreEqual(0, array_5x3_off_2_1[1, 1]);
            Assert.AreEqual(0, array_5x3_off_2_1[1, 2]);
            Assert.AreEqual(0, array_5x3_off_2_1[2, 0]);
            Assert.AreEqual(1, array_5x3_off_2_1[2, 1]);
            Assert.AreEqual(2, array_5x3_off_2_1[2, 2]);
            Assert.AreEqual(0, array_5x3_off_2_1[3, 0]);
            Assert.AreEqual(3, array_5x3_off_2_1[3, 1]);
            Assert.AreEqual(4, array_5x3_off_2_1[3, 2]);
            Assert.AreEqual(0, array_5x3_off_2_1[4, 0]);
            Assert.AreEqual(5, array_5x3_off_2_1[4, 1]);
            Assert.AreEqual(6, array_5x3_off_2_1[4, 2]);
        }

        [TestMethod]
        public void TestXMLSerialization()
        {
            Box srcBox = new Box(10, 20, 30, 40);
            string xmlFileName = "boxTest.xml";
            Assert.IsTrue(Utility.Serialization.ToXML(srcBox, xmlFileName));

            Box xmlBox = Utility.Serialization.FromXML<Box>(xmlFileName);
            File.Delete(xmlFileName);
            Assert.AreEqual<Box>(srcBox, xmlBox);
        }
    }
}
