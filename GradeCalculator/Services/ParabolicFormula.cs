using GradeCalculator.Interfaces;
using GradeCalculator.Structs;

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

        /// <summary>
        /// Remake Shoo.
        /// Remakes parabolic formula based on max points and ceasure.
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="ceasure"></param>
        private void RemakeShoo(float maxPoints, float ceasure)
        {
            ceasuraPointShoo.X = ceasure;
            maxPointShoo.X = maxPoints;
        }
    }
}
