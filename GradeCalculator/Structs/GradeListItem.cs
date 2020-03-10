namespace GradeCalculator.Structs
{
    struct GradeListItem
    {
        /// <summary>Item's grade value.</summary>
        public string Grade { get; }
        /// <summary>Item's points value.</summary>
        public string Points { get; }

        /// <summary>
        /// Grade List Item.
        /// Constructor for grade list item.
        /// </summary>
        /// <param name="grade">Item's grade value.</param>
        /// <param name="points">Item's points value.</param>
        public GradeListItem(string grade, string points)
        {
            Grade = grade;
            Points = points;
        }
    }
}
