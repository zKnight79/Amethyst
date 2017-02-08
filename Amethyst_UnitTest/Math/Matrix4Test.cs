using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amethyst.Math;

namespace Amethyst_UnitTest.Math
{
    /// <summary>
    /// Description résumée pour TestMatrix4
    /// </summary>
    [TestClass]
    public class Matrix4Test
    {
        public Matrix4Test()
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
        public void TestRotation()
        {
            Vector2 vectorX2Y0 = new Vector2(2, 0);
            Matrix4 matRotZ90 = Matrix4.RotationZ(90);

            Vector2 vectorX0Y2 = matRotZ90.Transform(vectorX2Y0);
            TestContext.WriteLine("vectorX0Y2 : " + vectorX0Y2);
            Assert.IsTrue((new Vector2(0, 2)) == vectorX0Y2);
            Assert.IsFalse((new Vector2(0.001f, 2)) == vectorX0Y2);
        }

        [TestMethod]
        public void TestTranslation()
        {
            Vector2 vectorX2Y0 = new Vector2(2, 0);
            Matrix4 matTransX2Y6 = Matrix4.Translation(2, 6, 0);

            Vector2 vectorX4Y6 = matTransX2Y6.Transform(vectorX2Y0);
            TestContext.WriteLine("vectorX4Y6 : " + vectorX4Y6);
            Assert.IsTrue((new Vector2(4, 6)) == vectorX4Y6);
            Assert.IsFalse((new Vector2(4.001f, 6)) == vectorX4Y6);
        }
    }
}
