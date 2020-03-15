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
        Point startPoint2Shoo = new Point(0, -1);
        /// <summary>Ceasura point of formula, only X will vary.</summary>
        Point breakPointShoo = new Point(-1, 5.5F);
        /// <summary>Maximum point of formula, only X will vary.</summary>
        Point endPointShoo = new Point(-1, 10);

        /// <summary>Multiplier (a) for formula below ceasure.</summary>
        float multiplier1Shoo = -1;
        /// <summary>Multiplier (a) for formula above ceasure.</summary>
        float multiplier2Shoo = -1;

        public void RemakeShoo(float maxPoints, float ceasura)
        {
            // Check max points < ceasura
            if (maxPoints <= ceasura)
            {
                Console.WriteLine("Error: Tried to remake linear formula, but ceasure is larger than or equal to  maximum points! Cancelling remake...");
                multiplier1Shoo = -1;
                multiplier2Shoo = -1;
                return;
            }
            // Check ceasura bigger than 0
            else if (ceasura <= 0)
            {
                Console.WriteLine("Error: Tried to remake linear formula, but ceasure smaller than or equal to 0! Cancelling remake...");
                multiplier1Shoo = -1;
                multiplier2Shoo = -1;
                return;
            }

            // Update break and end point x-positions
            breakPointShoo.X = ceasura;
            endPointShoo.X = maxPoints;

            // Calculate formula multipliers (a)
            multiplier1Shoo = (breakPointShoo.Y - startPoint1Shoo.Y) / (breakPointShoo.X - startPoint1Shoo.X);
            multiplier2Shoo = (endPointShoo.Y - breakPointShoo.Y) / (endPointShoo.X - breakPointShoo.X);

            // Calculate formula 2's start point (b)
            startPoint2Shoo.Y = breakPointShoo.Y - multiplier2Shoo * breakPointShoo.X;

            Console.WriteLine($"Succesfully remade broken line formulas! Multiplier 1: { multiplier1Shoo }, multiplier 2: { multiplier2Shoo } formula 2 start point: { startPoint2Shoo.Y }.");
        }

        public float GetGradeShoo(float points)
        {
            // Invalid formula, return 0
            if (multiplier1Shoo <= 0 || multiplier2Shoo <= 0)
                return 0;

            // Return grade from formula 1, below ceasura
            if (points >= startPoint1Shoo.X && points <= breakPointShoo.X)
                return multiplier1Shoo * points + startPoint1Shoo.Y;

            // Return grade from formula 2, above ceasure
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

            // Foreach grade, get minimum points needed and add to list
            for (int indexShoo = 10; indexShoo <= 100; indexShoo++)
            {
                float minimumPointsShoo;

                float gradeShoo = (float)indexShoo / 10;

                // Calculate points below ceasura
                if (gradeShoo <= breakPointShoo.Y)
                    minimumPointsShoo = (gradeShoo - startPoint1Shoo.Y) / multiplier1Shoo;

                // Calculate points above ceasura
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
