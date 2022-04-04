using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utility;

namespace UtilityTest
{
    [TestClass]
    public class VectorUnitTest
    {
        public Vector v1 = new Vector(1, 0, -13);
        public Vector v2 = new Vector(0.4, -9.3, 5.5);

        [TestMethod]
        public void AdditionTest()
        {

            var answer = v1 + v2;
            var realAnswer = new Vector(v1.X+v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

            Assert.AreEqual(realAnswer, answer);

            
        }

        [TestMethod]
        public void SubtractionTest()
        {
            var answer = v1 - v2;
            var realAnswer = new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

            Assert.AreEqual(realAnswer, answer);

            answer = v2 - v1;
            realAnswer = new Vector(v2.X - v1.X, v2.Y - v1.Y, v2.Z - v1.Z);
            Assert.AreEqual(realAnswer, answer);
        }

        [TestMethod]
        public void DivideTest()
        {
            var answer = (v1 / 3).Round();
            var realAnswer = (new Vector(v1.X/3.0, v1.Y/3.0, v1.Z/3.0)).Round();

            Assert.AreEqual(realAnswer, answer);

            answer = (v1 / 3.5).Round();
            realAnswer = (new Vector(v1.X / 3.5, v1.Y / 3.5, v1.Z / 3.5)).Round();

            Assert.AreEqual(realAnswer, answer);

            Assert.ThrowsException<ArithmeticException>(() => v1 / 0);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            var answer = v1 * 3;
            var realAnswer = new Vector(v1.X * 3, v1.Y * 3, v1.Z * 3);

            Assert.AreEqual(realAnswer.Round(), answer.Round());

            answer = v1 * 3.5;
            realAnswer = new Vector(v1.X*3.5,v1.Y*3.5,v1.Z*3.5);

            Assert.AreEqual(realAnswer.Round(), answer.Round());

            answer = v2 * 5;
            realAnswer = new Vector(v2.X * 5, v2.Y * 5, v2.Z * 5);

            Assert.AreEqual(realAnswer.Round(), answer.Round());

            answer = v2 * 3.3;
            realAnswer = new Vector(v2.X * 3.3, v2.Y * 3.3, v2.Z * 3.3);

            Assert.AreEqual(realAnswer.Round(), answer.Round());
        }

        [TestMethod]
        public void TestMagnitude()
        {

            Assert.AreEqual(v1.Magnitude, Math.Sqrt(170));
            Assert.AreEqual(v2.Magnitude, Math.Sqrt(115.25));
        }
        [TestMethod]
        public void TestUnitVector()
        {
            Assert.AreEqual(v1.UnitVector(), new Vector(v1.X / v1.Magnitude, v1.Y / v1.Magnitude, v1.Z / v1.Magnitude));
            Assert.AreEqual(v2.UnitVector(), new Vector(v2.X / v2.Magnitude, v2.Y / v2.Magnitude, v2.Z / v2.Magnitude));
        }
        [TestMethod]
        public void TestDotProduct()
        {
            var answer = v1 * 3;
            var realAnswer = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z; ;

            Assert.AreEqual(realAnswer, v1.DotProduct(v2));
        }
    }
}