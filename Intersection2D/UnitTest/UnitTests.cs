using System;
using System.Collections.Specialized;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intersection2D;
namespace UnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ParallelTest()
        {
           Vector2 a1 = new Vector2(0,0);
           Vector2 a2 = new Vector2(1,0);
           
           Vector2 b1 = new Vector2(0,1);
           Vector2 b2 = new Vector2(1,1);

           Assert.IsTrue(float.IsNaN(Intersections.LineLineIntersection(a1,a2,b1,b2).X));
           Assert.IsTrue(float.IsNaN(Intersections.LineLineIntersection(a1, a2, b1, b2).Y));
        }
        [TestMethod]
        public void Parallel2Test()
        {
            Vector2 a1 = new Vector2(0,0);
            Vector2 a2 = new Vector2(1,1);

            Vector2 b1 = new Vector2(0,1);
            Vector2 b2 = new Vector2(1,2);

            Assert.IsTrue(float.IsNaN(Intersections.LineLineIntersection(a1, a2, b1, b2).X));
            Assert.IsTrue(float.IsNaN(Intersections.LineLineIntersection(a1, a2, b1, b2).Y));
        }
        [TestMethod]
        public void Parellel3Test()
        {
            Vector2 a1 = new Vector2(0, 0);
            Vector2 a2 = new Vector2(0, 1);

            Vector2 b1 = new Vector2(1, 0);
            Vector2 b2 = new Vector2(1, 1);

            Assert.IsTrue(float.IsNaN(Intersections.LineLineIntersection(a1, a2, b1, b2).X));
            Assert.IsTrue(float.IsNaN(Intersections.LineLineIntersection(a1, a2, b1, b2).Y));
        }
        [TestMethod]
        public void SameLineTest()
        {

            Vector2 a1 = new Vector2(0, 0);
            Vector2 a2 = new Vector2(1, 1);

            Vector2 b1 = new Vector2(2,2 );
            Vector2 b2 = new Vector2(-1,-1);

            Assert.IsTrue(float.IsPositiveInfinity(Intersections.LineLineIntersection(a1, a2, b1, b2).X));
            Assert.IsTrue(float.IsPositiveInfinity(Intersections.LineLineIntersection(a1, a2, b1, b2).Y));
        }

        [TestMethod]
        public void Intersection1Test()
        {

            Vector2 a1 = new Vector2(0, 0);
            Vector2 a2 = new Vector2(0, 1);

            Vector2 b1 = new Vector2(2, 0);
            Vector2 b2 = new Vector2(4, 0);

            Assert.AreEqual(Intersections.LineLineIntersection(a1,a2,b1,b2),Vector2.Zero);

        }

        [TestMethod]
        public void Intersection2Test()
        {

            Vector2 a1 = new Vector2(0, 0);
            Vector2 a2 = new Vector2(1, 1);

            Vector2 b1 = new Vector2(0, 1);
            Vector2 b2 = new Vector2(1,0);

            Assert.AreEqual(new Vector2(0.5f, 0.5f),Intersections.LineLineIntersection(a1,a2,b1,b2));
        }

    }

    [TestClass]
    public class LineSLineS
    {
        
    }
}
