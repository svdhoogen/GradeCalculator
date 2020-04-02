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
        /// <param name="x">Point's x value</param>
        /// <param name="y">Point's y value</param>
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
