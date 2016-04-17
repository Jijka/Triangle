using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeSidesTest()
        {
            new Triangle.Triangle(-1.5, -2.1, -3.999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroSidesTest()
        {
            new Triangle.Triangle(0.0, 0.0, 0.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PiphagorTest()
        {
            new Triangle.Triangle(1, 9, 8);
        }

        [TestMethod]
        public void AreaTest()
        {
            var triangle = new Triangle.Triangle(3, 4, 5);
            Assert.AreEqual(6, triangle.Area());
        }

        [TestMethod]
        public void StaticAreaTest()
        {
            Assert.AreEqual(6, Triangle.Triangle.Area(3, 4, 5));
        }

    }
}