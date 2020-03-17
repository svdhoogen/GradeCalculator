using GradeCalculator.Interfaces;
using GradeCalculator.Structs;
using System;
using System.Collections.Generic;

namespace GradeCalculator.Services
{
    class ParabolicFormula : IParabolicFormula
    {
        /// <summary>The start point of formula (x1, y1), is always the same.</summary>
        readonly Point startPointShoo = new Point(0, 1);
        /// <summary>The break point of formula (x2, y2), only X will vary.</summary>
        Point breakPointShoo = new Point(-1, 5.5F);
        /// <summary>The end point of formula (x3, y3), only X will vary.</summary>
        Point endPointShoo = new Point(-1, 10);

        /// <summary>Multiplier (a) for parabolic formula.</summary>
        float multiplier1Shoo = -9999;
        /// <summary>Multiplier (b) for parabolic formula.</summary>
        float multiplier2Shoo = -9999;

        public void RemakeShoo(float maxPoints, float ceasura)
        {
            // Check for valid ceasura, ensures ascending parabola between start and end point
            if (ceasura <= maxPoints * 0.3 || ceasura == maxPoints * 0.5 || ceasura >= maxPoints * 0.70)
            {
                Console.WriteLine("Error: Tried to remake parabolic formula, but ceasure is invalid! Either smaller than maxpoints * 0.3, equal to maxpoints * 0.5 or larger than maxpoints * 0.75! Cancelling remake...");
                multiplier1Shoo = -9999;
                multiplier2Shoo = -9999;
                return;
            }
            // Check ceasura bigger than 1
            else if (ceasura <= 1)
            {
                Console.WriteLine("Error: Tried to remake linear formula, but ceasure smaller than or equal to 1! Cancelling remake...");
                multiplier1Shoo = -1;
                multiplier2Shoo = -1;
                return;
            }

            // Update points
            breakPointShoo.X = ceasura;
            endPointShoo.X = maxPoints;

            // Calculate multiplier 1 (a)
            CalculateMultiplier1Shoo();

            // Calculate multiplier 2 (b)
            CalculateMultiplier2Shoo();

            Console.WriteLine($"Succesfully remade parabolic formula! Formula is: y = { multiplier1Shoo }x^2 + {multiplier2Shoo}x + { startPointShoo.Y}.");
        }

        /// <summary>
        /// Calculate Multiplier 1 Shoo.
        /// Solve for a in parabolic formula: y = ax^2 + bx + c.
        /// </summary>
        private void CalculateMultiplier1Shoo()
        {
            // Solving this formula: a = ((y2 - c) * x3 - (y3 - c) * x2) / (x2^2 * x3 - x3^2 * x2)
            // Which we simplify to: a = (operation1 - operation2) / (operation3 - operation4)

            // Calculate (y2 - c) * x3
            double operation1Shoo = (breakPointShoo.Y - startPointShoo.Y) * endPointShoo.X;

            // Calculate (y3 - c) * x2
            double operation2Shoo = (endPointShoo.Y - startPointShoo.Y) * breakPointShoo.X;

            // Calculate x2^2 * x3
            double operation3Shoo = (float)Math.Pow(breakPointShoo.X, 2) * endPointShoo.X;

            // Calculate x3^2 * x2
            double operation4Shoo = (float)Math.Pow(endPointShoo.X, 2) * breakPointShoo.X;

            // Calculate (part1 - part2) / (part3 - part4)
            multiplier1Shoo = (float)((operation1Shoo - operation2Shoo) / (operation3Shoo - operation4Shoo));
        }

        /// <summary>
        /// Calculate Multiplier 2 Shoo.
        /// Solve for b in parabolic formula: y = ax^2 + bx + c.
        /// </summary>
        private void CalculateMultiplier2Shoo()
        {
            // Solving this formula: b = (y2 - c - a * x2^2) / x2
            // Which we simplify to: b = (operation1 - operation2) / operation3

            // Calculate y2 - c
            double operation1Shoo = breakPointShoo.Y - startPointShoo.Y;

            // Calculate a * x2^2
            double operation2Shoo = multiplier1Shoo * (float)Math.Pow(breakPointShoo.X, 2);

            // x2
            double operation3Shoo = breakPointShoo.X;

            // Calculate (part1 - part2) / part3
            multiplier2Shoo = (float)((operation1Shoo - operation2Shoo) / operation3Shoo);
        }

        public float GetGradeShoo(float points)
        {
            // Invalid formula, return 0
            if (multiplier2Shoo <= -9000)
                return 0;

            // Return grade
            if (points >= startPointShoo.X && points <= endPointShoo.X)
                return (float)(multiplier1Shoo * Math.Pow(points, 2) + multiplier2Shoo * points + startPointShoo.Y);

            // Invalid point amount, return 0
            return 0;
        }

        public List<GradeListItem> GetGradeListShoo()
        {
            // Create grade list
            List<GradeListItem> gradeListShoo = new List<GradeListItem>();

            // Invalid formula, return empty list
            if (multiplier2Shoo <= -9000)
                return gradeListShoo;

            // Solve for x in formula: y = ax^2 + bx + c where y, a, b and c are known
            // We convert this formula to: ax^2 + bx + (c - y) = 0
            // Solve for x using formula: x = (-b + sqrt(b^2 - 4 * a * (c - y))) / (2 * a)
            // Which we simplify to: x = (operation1 - sqrt(operation2 - operation3)) / operation4

            // Calculate -b
            float operation1Shoo = -multiplier2Shoo;

            // Calculate b^2
            double operation2Shoo = Math.Pow(multiplier2Shoo, 2);

            // Calculate 2 * a
            float operation4Shoo = 2 * multiplier1Shoo;

            // Fill grade list with each tenth grade's minimum needed points
            for (int indexShoo = 10; indexShoo <= 100; indexShoo++)
            {
                // Calculate grade
                float gradeShoo = (float)indexShoo / 10;

                // Calculate 4 * a * (c - y)
                float operation3Shoo = 4 * multiplier1Shoo * (startPointShoo.Y - gradeShoo);

                // Calculate points
                double minimumPointsShoo = (operation1Shoo + Math.Sqrt(operation2Shoo - operation3Shoo)) / operation4Shoo;

                // Add to grade list
                gradeListShoo.Add(new GradeListItem(gradeShoo.ToString("0.0"), minimumPointsShoo.ToString("0.0")));
            }

            // Return grade list
            return gradeListShoo;
        }
    }
}
