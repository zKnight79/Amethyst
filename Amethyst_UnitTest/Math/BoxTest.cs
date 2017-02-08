using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amethyst.Math;

namespace Amethyst_UnitTest.Math
{
    /// <summary>
    /// Description résumée pour TestBox
    /// </summary>
    [TestClass]
    public class BoxTest
    {
        public BoxTest()
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
        public void TestContructors()
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(10, 20, 50, 100);
            foreach (Box box in new Box[]
            {
                new Box(rectangle),
                new Box(rectangle.Location.ToAmethystPoint(), rectangle.Size.ToAmethystSize()),
                new Box(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
            })
            {
                Assert.AreEqual(10, box.Left);
                Assert.AreEqual(20, box.Top);
                Assert.AreEqual(60, box.Right);
                Assert.AreEqual(120, box.Bottom);

                Assert.AreEqual(rectangle, (System.Drawing.Rectangle)box);
            }
        }

        [TestMethod]
        public void TestIntersects()
        {
            Box boxA = new Box(100, 100, 100, 100);
            Box boxB = new Box(160, 160, 100, 100);
            Box boxC = new Box(220, 220, 100, 100);

            Assert.IsTrue(boxA.IntersectsWith(boxB));
            Assert.IsFalse(boxA.IntersectsWith(boxC));
            Assert.IsTrue(boxB.IntersectsWith(boxC));
        }

        [TestMethod]
        public void TestContains()
        {
            Box box = new Box(100, 100, 100, 100);
            Point pointA = new Point(120, 120);
            Point pointB = new Point(180, 180);
            Point pointC = new Point(220, 220);
            Point pointD = new Point(20, 20);
            Point pointE = new Point(150, 220);
            Point pointF = new Point(20, 150);

            Assert.IsTrue(box.Contains(pointA));
            Assert.IsTrue(box.Contains(pointB));
            Assert.IsFalse(box.Contains(pointC));
            Assert.IsFalse(box.Contains(pointD));
            Assert.IsFalse(box.Contains(pointE));
            Assert.IsFalse(box.Contains(pointF));
        }
    }
}
