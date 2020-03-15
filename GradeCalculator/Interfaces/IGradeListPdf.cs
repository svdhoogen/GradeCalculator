using GradeCalculator.Enums;
using GradeCalculator.Structs;
using System.Collections.Generic;

namespace GradeCalculator.Interfaces
{
    interface IGradeListPdf
    {
        /// <summary>
        /// Create Shoo.
        /// Creates and displays grade list pdf.
        /// </summary>
        /// <param name="gradeListShoo">Grade list to fill table with</param>
        /// <param name="maxPointsShoo">Maximum points used for grading</param>
        /// <param name="ceasuraShoo">Ceasura used for grading</param>
        /// <param name="gradingMethodShoo">Grading method used for grading</param>
        void CreateShoo(List<GradeListItem> gradeListShoo, float maxPointsShoo, float ceasuraShoo, GradingMethodEnum gradingMethodShoo);
    }
}
