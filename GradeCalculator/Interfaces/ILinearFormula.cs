using GradeCalculator.Structs;
using System.Collections.Generic;

namespace GradeCalculator.Interfaces
{
    interface ILinearFormula
    {
        /// <summary>
        /// Remake.
        /// Remakes parabolic formula based on max points and ceasure.
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="ceasure"></param>
        void RemakeShoo(float maxPoints, float ceasure);

        /// <summary>
        /// Get Grade Shoo.
        /// Returns grade for certain amount of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        float GetGradeShoo(float points);

        /// <summary>
        /// Get Grade List Shoo.
        /// Returns a grade list, from 1.0 till 10.0, containing the minimum points needed for a grade.
        /// </summary>
        /// <returns>Grade list</returns>
        List<GradeListItem> GetGradeListShoo();
    }
}
