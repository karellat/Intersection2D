using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Intersection2D
{
    public static class Intersections
    {
        // Intersection methods
        /// <summary>
        /// Return true if a, b circles intersects
        /// </summary>
        /// <param name="aMiddle"></param>
        /// <param name="aRadius"></param>
        /// <param name="bMiddle"></param>
        /// <param name="bRadius"></param>
        /// <returns></returns>
        public static bool CircleCircleIntersection(Vector2 aMiddle, float aRadius, Vector2 bMiddle, float bRadius)
        {
            float squaredDistanceBetweenAB = (bMiddle - aMiddle).LengthSquared();

            if (squaredDistanceBetweenAB <= ((aRadius + bRadius) * (aRadius + bRadius)))
                return true;
            return false;
        }
        /// <summary>
        /// Return intersection point of Line a and b
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns> Return NaN vector if no intersection, Infity if one line is part of the second </returns>
        public static Vector2 LineLineIntersection(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
        {
            //Transform points to equation form 
            //line a 
            float A1 = a1.Y - a2.Y;
            float B1 = a2.X - a1.X;
            float C1 = A1 * a2.X + B1 * a2.Y;

            //line b
            float A2 = b1.Y - b2.Y;
            float B2 = b2.X - b1.X;
            float C2 = A2 * b2.X + B2 * b2.Y;

            //assuming Ax + By = C form 
            float delta = A1 * B2 - A2 * B1;
            //Check parallelity of lines 
            if (delta == 0)
            {
                //Check equality of lines 
                if (A2 * b1.X + B2 * b1.Y == -C2)
                    return new Vector2(float.PositiveInfinity, float.PositiveInfinity);

                return new Vector2(float.NaN, float.NaN);
            }
            //If not parellel return point of intersection
            return new Vector2((B2 * C1 - B1 * C2) / delta, (A1 * C2 - A2 * C1) / delta);


        }
        /// <summary>
        /// Return intersection point of two line segment a & b 
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static Vector2 LinesegmentLinesegmentIntersection(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
        {
            //If not line throw exception
            //Debug.Assert(a1 - a2 == Vector2.Zero);
            //Debug.Assert(b1 - b2 == Vector2.Zero);
            //Find line & line intersection 
            Vector2 i = LineLineIntersection(a1, a2, b1, b2);
            //No intersection 
            if (float.IsNaN(i.X))
                return i;

            if (!float.IsPositiveInfinity(i.X))
            {
                //Check line a contains intersection 
                //if  perpendicular with axis 
                if (a1.X != a2.X)
                {
                    if (!MyExtensions.Between(a1.X, a2.X, i.X))
                        return new Vector2(float.NaN, float.NaN);
                }
                else
                {
                    if (!MyExtensions.Between(a1.Y, a2.Y, i.Y))
                        return new Vector2(float.NaN, float.NaN);
                }

                //Check line b contains intersection 
                if (b1.X != b2.X)
                {
                    if (!MyExtensions.Between(b1.X, b2.X, i.X))
                        return new Vector2(float.NaN, float.NaN);
                }
                else
                {
                    if (!MyExtensions.Between(b1.Y, b2.Y, i.Y))
                        return new Vector2(float.NaN, float.NaN);
                }

                return i;
            }
            //Same line 
            else
            {
                Vector2 aMiddle = Vector2.Divide((a1 + a2), 2.0f);
                float aRadius = (a1 - aMiddle).Length();
                Vector2 bMiddle = Vector2.Divide((b1 + b2), 2.0f);
                float bRadius = (b1 - bMiddle).Length();

                //if circle intersects 
                if (CircleCircleIntersection(aMiddle, aRadius, bMiddle, bRadius))
                {
                    return i;
                }
                else
                {
                    return new Vector2(float.NaN, float.NaN);
                }

            }
        }
        /// <summary>
        /// Return all point of intersections of circle & line 
        /// </summary>
        /// <param name="aMiddle"></param>
        /// <param name="aRadius"></param>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
       public  static Vector2[] CircleLineSegmentIntersection(Vector2 aMiddle, float aRadius, Vector2 b1, Vector2 b2)
        {
            //Debug.Assert(b1 == b2);
            //check if any intersection exists, find intersection with perpedicular line
            Vector2 p1 = aMiddle;
            Vector2 directionB = b1 - b2;
            //Create perpedicular vector to b
            Vector2 perpedicularB = new Vector2(directionB.Y, (-1.0f * directionB.X));
            Vector2 p2 = aMiddle + perpedicularB;
            //Intersection with perpedicular line, no point to 
            Vector2 i = LineLineIntersection(p1, p2, b1, b2);
            //If not in the segment 
            if (float.IsNaN(i.X))
                return new[] {i};
            //If distance between line and circle is bigger than radius 
            float distanceBetweenLineCircle = Vector2.DistanceSquared(i, aMiddle);
            if (distanceBetweenLineCircle > (aRadius * aRadius))
                return new Vector2[0];
            //if line is tangent
            else if (distanceBetweenLineCircle == (aRadius * aRadius))
                return new[] {i};

            //IF THERE is two intersection 
            //Using perpedicular line & pythagoren theorem 
            float distanceToV = (aRadius * aRadius) - Vector2.DistanceSquared(i, aMiddle);
            distanceToV = (float) Math.Sqrt(distanceToV);
            directionB = Vector2.Normalize(directionB);

            //Intersection points 
            Vector2 X_1 = (directionB * distanceToV) + i;
            Vector2 X_2 = (directionB * distanceToV * -1) + i;
            
            if (MyExtensions.Between(b1.X, b2.X, X_1.X))
            {
                if (MyExtensions.Between(b1.X, b2.X, X_2.X))
                    return new[] {X_1, X_2};
                else
                    return new[] {X_1};
            }
            else
            {
                if (MyExtensions.Between(b1.X, b2.X, X_2.X))
                    return new[] {X_2};
                else
                    return new Vector2[0]; 
            }
          

        }
     
    }
    public static class MyExtensions
    {
        /// <summary>
        /// Test if x lies between a & b 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool Between(float a, float b, float x)
        {
            float upper;
            float lower;

            if (a > b)
            {
                upper = a;
                lower = b;
            }
            else
            {
                upper = b;
                lower = a;
            }

            if (x >= lower && x <= upper)
                return true;
            return false;
        }
        public static bool QuadraticSolver(double A, double B, double C, out double[] x)
        {
            double D = B * B - 4 * A * C;
            if (D < 0)
            {
                x = null;
                return false;
            }
            else
            {
                double x_0 = (-B + Math.Sqrt(D)) / (2.0 * A);
                double x_1 = (-B - Math.Sqrt(D)) / (2.0 * A);

                if (D == 0)
                {
                    x = new double[1];
                    x[0] = x_0;
                    return true;
                }
                else
                {
                    x = new double[2];
                    x[0] = x_0;
                    x[1] = x_1;
                    return true;
                }
            }
        }
    }
}
