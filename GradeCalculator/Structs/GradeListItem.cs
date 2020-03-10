namespace GradeCalculator.Structs
{
    struct GradeListItem
    {
        /// <summary>Item's grade value.</summary>
        public float Grade { get; }
        /// <summary>Item's points value.</summary>
        public float Points { get; }

        /// <summary>
        /// Grade List Item.
        /// Constructor for grade list item.
        /// </summary>
        /// <param name="grade">Item's grade value.</param>
        /// <param name="points">Item's points value.</param>
        public GradeListItem(float grade, float points)
        {
            Grade = grade;
            Points = points;
        }
    }
}
