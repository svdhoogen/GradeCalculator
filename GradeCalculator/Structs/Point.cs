namespace GradeCalculator.Structs
{
    struct Point
    {
        /// <summary>Point's X position.</summary>
        public float X { get; set; }

        /// <summary>Point's Y position.</summary>
        public float Y { get; set; }

        /// <summary>
        /// Point.
        /// Constructor for point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
