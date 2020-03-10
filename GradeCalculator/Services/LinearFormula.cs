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
                System.Windows.Forms.MessageBox.Show("Tried to remake linear formula, but ceasure is bigger than maximum points! Cancelling remake...", "Whoops!");
                Console.WriteLine("Error: Tried to remake linear formula, but ceasure is bigger than maximum points! Cancelling remake...");
                return;
            }
            // Check ceasura bigger then 0
            else if (ceasura <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Tried to remake linear formula, but ceasure smaller then or equal to 0! Cancelling remake...", "Whoops!");
                Console.WriteLine("Error: Tried to remake linear formula, but ceasure smaller then or equal to 0! Cancelling remake...");
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
            // Return point from formula below ceasura
            if (points >= startPointShoo.X && points <= ceasuraPointShoo.X)
                return multiplier1Shoo * points + startPointShoo.Y;

            // Return point from formula above ceasure
            else if (points >= ceasuraPointShoo.X && points <= maxPointShoo.X)
                return multiplier2Shoo * points + ceasuraPointShoo.Y;

            // Invalid grade, return 0
            return 0;
        }

        public List<GradeListItem> GetGradeListShoo()
        {
            // Create a grade list
            List<GradeListItem> gradeListShoo = new List<GradeListItem>();

            // Fill grade list with each tenth grade's minimum needed points
            for (float gradeShoo = 1; gradeShoo <= 10; gradeShoo += 0.1F)
            {
                float minimumPointsShoo;

                // Calculate points below ceasura
                if (gradeShoo <= ceasuraPointShoo.Y)
                    minimumPointsShoo = (gradeShoo - startPointShoo.Y) / multiplier1Shoo;

                // Calculate points above ceasura
                else
                    minimumPointsShoo = (gradeShoo - ceasuraPointShoo.Y) / multiplier2Shoo;

                // Add grade and minimum points to list
                gradeListShoo.Add(new GradeListItem(gradeShoo, minimumPointsShoo));
            }

            // Return grade list
            return gradeListShoo;
        }
    }
}
