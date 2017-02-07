using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amethyst.Engine;
using Amethyst.Math;

namespace Amethyst_UnitTest.Engine
{
    /// <summary>
    /// Description résumée pour SceneNodeTest
    /// </summary>
    [TestClass]
    public class SceneNodeTest
    {
        public SceneNodeTest()
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

        class SceneNodeImpl : SceneNode
        {
            public SceneNodeImpl(Box box) : base(box) { }
            protected override void OnRender(SpriteBatch spriteBatch) { }
        }

        [TestMethod]
        public void TestNodeAngle()
        {
            SceneNodeImpl node = new SceneNodeImpl(new Box(0, 0, 32, 32));
            node.Angle += 200;
            Assert.AreEqual(200, node.Angle);
            node.Angle += 200;
            Assert.AreEqual(40, node.Angle);
            node.Angle += 200;
            Assert.AreEqual(240, node.Angle);
            node.Angle += 200;
            Assert.AreEqual(80, node.Angle);
            node.Angle -= 300;
            Assert.AreEqual(140, node.Angle);
        }

        [TestMethod]
        public void TestNodeBoxChanged()
        {
            SceneNodeImpl node = new SceneNodeImpl(new Box(0, 0, 200, 100));
            node.Box = new Box(0, 0, 32, 32);
            node.BoxChanged += () => TestContext.WriteLine("BoxChanged => " + node.Box);
            node.Box = new Box(0, 0, 300, 300);
            node.Box = new Box(100, 80, 50, 50);
        }
    }
}
