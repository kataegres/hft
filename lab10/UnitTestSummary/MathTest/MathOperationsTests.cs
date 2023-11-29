using NUnit.Framework;
using System;
using UnitTestSummary;

namespace MathTest
{
    [TestFixture]
    public class MathOperationsTests
    {
        private MathOperations math;

        [SetUp]
        public void Setup()
        {
            math = new MathOperations(); // minden tesztelés előtt!
        }

        // névkonvenció: Should_AmitCsinalniaKene
        [Test]
        public void ShouldReturnCorrectSum()
        {
            int result = math.Add(11, 7);
            Assert.AreEqual(18, result);
            // Asserten belül rengeteg metódus: AreNotEqual, Fail, IsNotNull, ThrowsException...
        }

        [Test]
        public void ShouldReturnCorrectDifference()
        {
            int result = math.Subtract(10, 5);
            Assert.AreEqual(5, result);
        }

        //// elhasal
        //[Test]
        //public void ShouldReturnCorrectDifferenceFail()
        //{
        //    int result = math.Subtract(10, 4);
        //    Assert.AreEqual(3, result);
        //}
    }
}
