using System;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intersection2D;
namespace UnitTest
{
    [TestClass()]
    public class LineLineTests
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

    [TestClass()]
    public  class LineSLineS
    {
        [TestMethod]
        public  void Parallel1Test()
        {
            Vector2 a1 = new Vector2(2,2);
            Vector2 a2 = new Vector2(1, 3);

            Vector2 b1 = new Vector2(3, 2);
            Vector2 b2 = new Vector2(2, 3);

            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1,a2,b1,b2).X));
            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).Y));

        }

        [TestMethod]
        public  void Parallel2Test()
        {
            Vector2 a1 = new Vector2(2, 2);
            Vector2 a2 = new Vector2(2, 3);

            Vector2 b1 = new Vector2(0, 0);
            Vector2 b2 = new Vector2(0, 1);

            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).X));
            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).Y));
        }

        [TestMethod]
        public static void Parallel3Test()
        {

            Vector2 a1 = new Vector2(0, 1);
            Vector2 a2 = new Vector2(0, 2);

            Vector2 b1 = new Vector2(1, 1);
            Vector2 b2 = new Vector2(1, 2);

            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).X));
            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).Y));
        }

        [TestMethod]
        public  void SamelineTest()
        {
            Vector2 a1 = new Vector2(0,0);
            Vector2 a2 = new Vector2(0,3);
            
            Vector2 b1 = new Vector2(0,0.5f);
            Vector2 b2 = new Vector2(0,0.7f);

            Assert.IsTrue(float.IsPositiveInfinity(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).X));
            Assert.IsTrue(float.IsPositiveInfinity(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).Y));
        }

        [TestMethod]
        public  void Intersection1Test()
        {
            Vector2 a1 = new Vector2(1, 3);
            Vector2 a2 = new Vector2(3, 1);

            Vector2 b1 = new Vector2(1.5f, 1.5f);
            Vector2 b2 = new Vector2(2.5f, 2.5f);

            Assert.AreEqual(new Vector2(2,2),Intersections.LinesegmentLinesegmentIntersection(a1,a2,b1,b2));
        }

        [TestMethod]
        public  void Intersection2Test()
        {
            Vector2 a1 = new Vector2(0, 0.5f);
            Vector2 a2 = new Vector2(0, 2);

            Vector2 b1 = new Vector2(-1, 1);
            Vector2 b2 = new Vector2(1, 1);

            Assert.AreEqual(new Vector2(0,1), Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2));
        }

        [TestMethod]
        public  void NoIntersection1Test()
        {
            Vector2 a1 = new Vector2(0, 0);
            Vector2 a2 = new Vector2(0, 2);

            Vector2 b1 = new Vector2(1, 1);
            Vector2 b2 = new Vector2(2, 1);


            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).X));
            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).Y));

        }

        [TestMethod]
        public  void NoIntersection2Test()
        {
            Vector2 a1 = new Vector2(1, 2);
            Vector2 a2 = new Vector2(2, 1);

            Vector2 b1 = new Vector2(2, 2);
            Vector2 b2 = new Vector2(3, 3);



            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).X));
            Assert.IsTrue(float.IsNaN(Intersections.LinesegmentLinesegmentIntersection(a1, a2, b1, b2).Y));
        }

        [TestMethod]
        public  void TouchIntersection1Test()
        {
            Vector2 a1 = new Vector2(1, 3);
            Vector2 a2 = new Vector2(3, 1);

            Vector2 b1 = new Vector2(2, 2);
            Vector2 b2 = new Vector2(3, 3);

            Assert.AreEqual(new Vector2(2,2),Intersections.LinesegmentLinesegmentIntersection(a1,a2,b1,b2));

        }

    }

    [TestClass]
    public class CircleCircleTests
    {
        [TestMethod]
        public void TouchIntersectionTest()
        {
            Vector2 aMiddle= new Vector2(3,3);
            float aRadius = 1;
            Vector2 bMiddle= new Vector2(3,1);
            float bRadius = 1; 

            Assert.IsTrue(Intersections.CircleCircleIntersection(aMiddle,aRadius,bMiddle,bRadius));
        }

        [TestMethod]
        public void NoIntersectionTest()
        {
            Vector2 aMiddle = new Vector2(3, 3);
            float aRadius = 1;
            Vector2 bMiddle = new Vector2(1, 1);
            float bRadius = 1;

            Assert.IsTrue(!Intersections.CircleCircleIntersection(aMiddle, aRadius, bMiddle, bRadius));
        }

        [TestMethod]
        public void IntersectionTest()
        {
            Vector2 aMiddle = new Vector2(3, 3);
            float aRadius = 1;
            Vector2 bMiddle = new Vector2(3, 1);
            float bRadius = 2;

            Assert.IsTrue(Intersections.CircleCircleIntersection(aMiddle, aRadius, bMiddle, bRadius));
        }
    }

    [TestClass]
    public class CircleLineSTests
    {
        [TestMethod]
        public void SingleIntersection()
        {
            Vector2 aMiddle = new Vector2(2, 3);
            float aRadius = 2;
            Vector2 b1 = new Vector2(0,0);
            Vector2 b2 = new Vector2(3,4);
            Vector2[] i = Intersections.CircleLineSegmentIntersection(aMiddle, aRadius, b1, b2);
            Assert.AreEqual(1,i.Length);
            Assert.IsTrue(i.Contains(new Vector2(0.9660151f,1.28802025f)));
        }

        [TestMethod]
        public void InterSection1Test()
        {
            Vector2 aMiddle = new Vector2(3, 2);
            float aRadius = 1;
            Vector2 b1 = new Vector2(0,2);
            Vector2 b2 = new Vector2(4,2);
            Vector2[] i = Intersections.CircleLineSegmentIntersection(aMiddle, aRadius, b1, b2);
            
            Assert.IsTrue(i.Contains(new Vector2(2,2)));
            Assert.IsTrue(i.Contains(new Vector2(4,2)));
        }

        [TestMethod]
        public void InterSection2Test()
        {
            Vector2 aMiddle = new Vector2(3, 2);
            float aRadius = 1;
            Vector2 b1 = new Vector2(3, 1);
            Vector2 b2 = new Vector2(3, 4);
            Vector2[] i = Intersections.CircleLineSegmentIntersection(aMiddle, aRadius, b1, b2);

            Assert.IsTrue(i.Contains(new Vector2(3, 1)));
            Assert.IsTrue(i.Contains(new Vector2(3, 3)));
        }

        [TestMethod]
        public void NoIntersection()
        {
            Vector2 aMiddle = new Vector2(1, 3);
            float aRadius = 1;
            Vector2 b1 = new Vector2(0, 1);
            Vector2 b2 = new Vector2(1, 1);
            Vector2[] i = Intersections.CircleLineSegmentIntersection(aMiddle, aRadius, b1, b2);

            Assert.IsTrue(i.Length == 0);
        }

        [TestMethod]
        public void NoIntersection2()
        {
            Vector2 aMiddle = new Vector2(3,2);
            float aRadius = 1;
            Vector2 a = new Vector2(3,0.999f);
            Vector2 b = new Vector2(3.0f,0.5f);
            Vector2[] i = Intersections.CircleLineSegmentIntersection(aMiddle, aRadius, a, b);
            Assert.IsTrue(i.Length == 0);
        }

        [TestMethod]
        public void Intersection3Test()
        {
            Vector2 aMiddle = new Vector2(5,1);
            float aRadius = 1;

            Vector2 b1 = new Vector2(2,0);
            Vector2 b2 = new Vector2(8,0);

            Vector2[] i = Intersections.CircleLineSegmentIntersection(aMiddle, aRadius, b1, b2);

            Assert.IsTrue(i.Contains(new Vector2(5,0)) && i.Length == 1);
        }
    }
}
