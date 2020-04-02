using GradeCalculator.Interfaces;
using GradeCalculator.Structs;
using System;
using System.Collections.Generic;

namespace GradeCalculator.Services
{
    class BrokenLineFormula : IBrokenLineFormula
    {
        /// <summary>Start point of formula 1, is always the same.</summary>
        readonly Point startPoint1Shoo = new Point(0, 1);
        /// <summary>Start point of formula 2, only Y will vary.</summary>
        Point startPoint2Shoo = new Point(0, -9999);
        /// <summary>Ceasura point of formula, only X will vary.</summary>
        Point breakPointShoo = new Point(-9999, 5.5F);
        /// <summary>Maximum point of formula, only X will vary.</summary>
        Point endPointShoo = new Point(-9999, 10);

        /// <summary>Multiplier (a) for formula below ceasure.</summary>
        float multiplier1Shoo = -9999;
        /// <summary>Multiplier (a) for formula above ceasure.</summary>
        float multiplier2Shoo = -9999;

        public void RemakeShoo(float maxPoints, float ceasura)
        {
            // Reset values
            multiplier1Shoo = -9999;
            multiplier2Shoo = -9999;
            startPoint2Shoo.Y = -9999;
            breakPointShoo.X = -9999;
            endPointShoo.X = -9999;

            // Check ceasura is smaller than max points
            if (maxPoints <= ceasura)
            {
                Console.WriteLine("Error: Tried to remake linear formula, but ceasure is larger than or equal to  maximum points! Cancelling remake...");
                return;
            }
            // Check ceasura bigger than minimum
            else if (ceasura <= 1)
            {
                Console.WriteLine("Error: Tried to remake linear formula, but ceasure smaller than or equal to 1! Cancelling remake...");
                return;
            }

            // Set x2 and x3
            breakPointShoo.X = ceasura;
            endPointShoo.X = maxPoints;

            // Calculate first formula multiplier (a)
            multiplier1Shoo = (breakPointShoo.Y - startPoint1Shoo.Y) / (breakPointShoo.X - startPoint1Shoo.X);

            // Calculate second formula multiplier (a)
            multiplier2Shoo = (endPointShoo.Y - breakPointShoo.Y) / (endPointShoo.X - breakPointShoo.X);

            // Calculate second formula start point (b)
            startPoint2Shoo.Y = breakPointShoo.Y - multiplier2Shoo * breakPointShoo.X;

            Console.WriteLine($"Succesfully remade broken line formulas! First formula: y = { multiplier1Shoo }x + { startPoint1Shoo.Y }, second formula: y = {multiplier2Shoo}x + {startPoint2Shoo.Y}.");
        }

        public float GetGradeShoo(float points)
        {
            // Invalid formula, return 0
            if (multiplier1Shoo <= 0 || multiplier2Shoo <= 0)
                return 0;

            // Return grade below/at ceasura, from first formula
            if (points >= startPoint1Shoo.X && points <= breakPointShoo.X)
                return multiplier1Shoo * points + startPoint1Shoo.Y;

            // Return grade above ceasura, from second formula
            else if (points >= breakPointShoo.X && points <= endPointShoo.X)
                return multiplier2Shoo * points + startPoint2Shoo.Y;

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

            // Get minimum points for every grade and add to list
            for (int indexShoo = 10; indexShoo <= 100; indexShoo++)
            {
                // Convert index to grade
                float gradeShoo = (float)indexShoo / 10;

                // Minimum points
                float minimumPointsShoo;

                // Calculate points, below ceasura
                if (gradeShoo <= breakPointShoo.Y)
                    minimumPointsShoo = (gradeShoo - startPoint1Shoo.Y) / multiplier1Shoo;

                // Calculate points, above ceasura
                else
                    minimumPointsShoo = (gradeShoo - startPoint2Shoo.Y) / multiplier2Shoo;

                // Add to grade list
                gradeListShoo.Add(new GradeListItem(gradeShoo.ToString("0.0"), minimumPointsShoo.ToString("0.0")));
            }

            // Return grade list
            return gradeListShoo;
        }
    }
}
