using GradeCalculator.Interfaces;
using GradeCalculator.Structs;
using System;
using System.Collections.Generic;

namespace GradeCalculator.Services
{
    class ParabolicFormula : IParabolicFormula
    {
        /// <summary>The start point of formula, is always the same.</summary>
        readonly Point startPointShoo = new Point(0, 1);
        /// <summary>The ceasura point of formula, only X will vary.</summary>
        Point ceasuraPointShoo = new Point(5.5F, 5.5F);
        /// <summary>The maximum point of formula, only X will vary.</summary>
        Point maxPointShoo = new Point(10, 10);

        public void RemakeShoo(float maxPoints, float ceasura)
        {

        }

        public float GetGradeShoo(float points)
        {
            return 0;
        }

        public List<GradeListItem> GetGradeListShoo()
        {
            // Create a grade list
            List<GradeListItem> gradeListShoo = new List<GradeListItem>();

            // Fill grade list with each tenth grade's minimum needed points
            for (int indexShoo = 10; indexShoo <= 100; indexShoo++)
            {

            }

            // Return grade list
            return gradeListShoo;
        }
    }
}
