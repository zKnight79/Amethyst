using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amethyst.Math;

namespace Amethyst_UnitTest.Math
{
    /// <summary>
    /// Description résumée pour TestHelper
    /// </summary>
    [TestClass]
    public class TestHelper
    {
        public TestHelper()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestClamp()
        {
            Assert.AreEqual(1, Helper.Clamp(1, 0.5f, 1.5f));
            Assert.AreEqual(0.7f, Helper.Clamp(0.7f, 0.5f, 1.5f));
            Assert.AreEqual(0.5f, Helper.Clamp(0.2f, 0.5f, 1.5f));
            Assert.AreEqual(1.5f, Helper.Clamp(2, 0.5f, 1.5f));
        }

        [TestMethod]
        public void TestSwap()
        {
            int a = 29;
            int b = 13;

            Helper.Swap<int>(ref a, ref b);
            Assert.AreEqual(13, a);
            Assert.AreEqual(29, b);

            Helper.Swap<int>(ref a, ref b);
            Assert.AreEqual(29, a);
            Assert.AreEqual(13, b);

            Helper.Swap<int>(ref a, ref b);
            Assert.AreEqual(13, a);
            Assert.AreEqual(29, b);
        }
    }
}
