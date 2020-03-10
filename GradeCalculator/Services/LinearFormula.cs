using GradeCalculator.Interfaces;
using GradeCalculator.Structs;
using System;
using System.Collections.Generic;

namespace GradeCalculator.Services
{
    class LinearFormula : ILinearFormula
    {
        /// <summary>The start point of formula, is always the same.</summary>
        readonly Point startPointShoo = new Point(0, 1);
        /// <summary>The ceasura point of formula, only X will vary.</summary>
        Point ceasuraPointShoo = new Point(5.5F, 5.5F);
        /// <summary>The maximum point of formula, only X will vary.</summary>
        Point maxPointShoo = new Point(10, 10);

        /// <summary>Multiplier (a) for formula below ceasure.</summary>
        float multiplier1Shoo = 1;
        /// <summary>Multiplier (a) for formula above ceasure.</summary>
        float multiplier2Shoo = 1;

        public void RemakeShoo(float maxPoints, float ceasura)
        {
            // Check max points < ceasura
            if (maxPoints < ceasura)
            {
                Console.WriteLine("Error: Tried to remake linear formula, but ceasure is bigger than maximum points! Cancelling remake...");
                multiplier1Shoo = 0;
                multiplier2Shoo = 0;
                return;
            }
            // Check ceasura bigger then 0
            else if (ceasura <= 0)
            {
                Console.WriteLine("Error: Tried to remake linear formula, but ceasure smaller then or equal to 0! Cancelling remake...");
                multiplier1Shoo = 0;
                multiplier2Shoo = 0;
                return;
            }

            // Update ceasura and max points
            ceasuraPointShoo.X = ceasura;
            maxPointShoo.X = maxPoints;

            // Re-calculate formula multipliers (a)
            multiplier1Shoo = (ceasuraPointShoo.Y - startPointShoo.Y) / (ceasuraPointShoo.X - startPointShoo.X);
            multiplier2Shoo = (maxPointShoo.Y - ceasuraPointShoo.Y) / (maxPointShoo.X - ceasuraPointShoo.X);

            Console.WriteLine($"Succesfully remade linear formulas! Multiplier 1: { multiplier1Shoo }, multiplier 2: { multiplier2Shoo } based on max points: { maxPointShoo.X }, ceasura: { ceasuraPointShoo.X }.");
        }

        public float GetGradeShoo(float points)
        {
            // Invalid formula, return 0
            if (multiplier1Shoo == 0 || multiplier2Shoo == 0)
                return 0;

            // Return point from formula below ceasura
            if (points >= startPointShoo.X && points <= ceasuraPointShoo.X)
                return multiplier1Shoo * points + startPointShoo.Y;

            // Return point from formula above ceasure
            else if (points >= ceasuraPointShoo.X && points <= maxPointShoo.X)
                return multiplier2Shoo * (points - ceasuraPointShoo.Y) + ceasuraPointShoo.Y;

            // Invalid grade, return 0
            return 0;
        }

        public List<GradeListItem> GetGradeListShoo()
        {
            // Create a grade list
            List<GradeListItem> gradeListShoo = new List<GradeListItem>();

            // Invalid formula, return 0
            if (multiplier1Shoo == 0 || multiplier2Shoo == 0)
                return gradeListShoo;

            // Fill grade list with each tenth grade's minimum needed points
            for (int indexShoo = 10; indexShoo <= 100; indexShoo++)
            {
                float minimumPointsShoo;
                float gradeShoo = (float)indexShoo / 10;

                // Calculate points below ceasura
                if (gradeShoo <= ceasuraPointShoo.Y)
                    minimumPointsShoo = (gradeShoo - startPointShoo.Y) / multiplier1Shoo + startPointShoo.Y;

                // Calculate points above ceasura
                else
                    minimumPointsShoo = (gradeShoo - ceasuraPointShoo.Y) / multiplier2Shoo + ceasuraPointShoo.Y;

                // Add grade and minimum points to list
                gradeListShoo.Add(new GradeListItem(gradeShoo.ToString("0.0"), minimumPointsShoo.ToString("0.0")));
            }

            // Return grade list
            return gradeListShoo;
        }
    }
}
