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
        float multiplier1Shoo = -1;

        /// <summary>Multiplier (b) for parabolic formula.</summary>
        float multiplier2Shoo = -1;

        public void RemakeShoo(float maxPoints, float ceasura)
        {
            breakPointShoo.X = ceasura;
            endPointShoo.X = maxPoints;

            // Calculate multiplier 1 (a)
            CalculateMultiplier1Shoo();

            // Calculate multiplier 2 (b)
            CalculateMultiplier2Shoo();
        }

        /// <summary>
        /// Calculate Multiplier 1 Shoo.
        /// We are solving for a in parabolic formula: y = ax^2 + bx + c.
        /// </summary>
        private void CalculateMultiplier1Shoo()
        {
            // We solve this formula: a = ((y2 - c) * x3 - (y3 - c) * x2) / (x2^2 * x3 - x3^2 * x2) to determine a

            // Calculate (y2 - c) * x3
            double part1Shoo = (breakPointShoo.Y - startPointShoo.Y) * endPointShoo.X;

            // Calculate (y3 - c) * x2
            double part2Shoo = (endPointShoo.Y - startPointShoo.Y) * breakPointShoo.X;

            // Calculate x2^2 * x3
            double part3Shoo = (float)Math.Pow(breakPointShoo.X, 2) * endPointShoo.X;

            // Calculate x3^2 * x2
            double part4Shoo = (float)Math.Pow(endPointShoo.X, 2) * breakPointShoo.X;

            // We've boiled it down to formula: a = (part1 - part2) / (part3 - part4)

            // Calculate (part1 - part2) / (part3 - part4)
            multiplier1Shoo = (float)((part1Shoo - part2Shoo) / (part3Shoo - part4Shoo));
        }

        /// <summary>
        /// Calculate Multiplier 2 Shoo.
        /// We are solving for b in parabolic formula: y = ax^2 + bx + c.
        /// </summary>
        private void CalculateMultiplier2Shoo()
        {
            // We solve this formula: b = (y2 - c - a * x2^2) / x2

            // Calculate y2 - c
            double part1Shoo = breakPointShoo.Y - startPointShoo.Y;

            // Calculate a * x2^2
            double part2Shoo = multiplier1Shoo * (float)Math.Pow(breakPointShoo.X, 2);

            // x2
            double part3Shoo = breakPointShoo.X;

            // We've boiled it down to formula: b = (part1 - part2) / part3

            // Calculate (part1 - part2) / part3
            multiplier2Shoo = (float)((part1Shoo - part2Shoo) / part3Shoo);
        }

        public float GetGradeShoo(float points)
        {
            // Invalid formula, return 0
            if (multiplier1Shoo <= 0 || multiplier2Shoo <= 0)
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
            if (multiplier1Shoo <= 0 || multiplier2Shoo <= 0)
                return gradeListShoo;

            // Fill grade list with each tenth grade's minimum needed points
            for (int indexShoo = 10; indexShoo <= 100; indexShoo++)
            {
                float minimumPointsShoo;

                float gradeShoo = (float)indexShoo / 10;

                // We are solving formula: y = ax^2 + bx + c where y, a, b and c are known
                // We convert to this formula: x^2 + (b / a)x + (y - c) / a = 0
                // We write this new formula like so: x^2 + part1x + part3 = 0
                // Then we can solve for x using formula: x = (-part1 + sqrt(part1^2 - 4 * part2)) / 4

                // Calculate b / a
                float part1Shoo = multiplier2Shoo / multiplier1Shoo;

                // Calculate (y - c) / a
                float part2Shoo = (gradeShoo - startPointShoo.Y) / multiplier1Shoo;

                // Calculate sqrt(part1^2 - 4 * part2)
                float part3Shoo = (float)Math.Sqrt(Math.Pow(part1Shoo, 2) - 4 * part2Shoo);

                // We've now boiled it down to (-part1 + part3) / 4

                // Calculate (-part1 + part3) / 4
                minimumPointsShoo = (-part1Shoo + part3Shoo) / 4;

                // Add to grade list
                gradeListShoo.Add(new GradeListItem(gradeShoo.ToString("0.0"), minimumPointsShoo.ToString("0.0")));
            }

            // Return grade list
            return gradeListShoo;
        }
    }
}
