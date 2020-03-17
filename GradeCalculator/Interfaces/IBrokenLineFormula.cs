using GradeCalculator.Structs;
using System.Collections.Generic;

namespace GradeCalculator.Interfaces
{
    interface IBrokenLineFormula
    {
        /// <summary>
        /// Remake Shoo.
        /// Will remake the formula's based on maximum points and ceasura.
        /// </summary>
        /// <param name="maxPoints">The new maximum points</param>
        /// <param name="ceasura">The new ceasura</param>
        void RemakeShoo(float maxPoints, float ceasure);

        /// <summary>
        /// Get Grade Shoo.
        /// Returns grade at specified amount of points.
        /// </summary>
        /// <param name="points">Points to get grade for</param>
        /// <returns>Grade at points</returns>
        float GetGradeShoo(float points);

        /// <summary>
        /// Get Grade List Shoo.
        /// Returns a list of grades in tenths and the corresponding minimum points required.
        /// </summary>
        /// <returns>List of grades from 1.0 to 10.0 paired with minimum points needed</returns>
        List<GradeListItem> GetGradeListShoo();
    }
}
