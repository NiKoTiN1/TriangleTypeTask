namespace TriangleTypeTask
{
    public class Triangle
    {
        private double SideA { get; }
        private double SideB { get; }
        private double SideC { get; }
        public TriangleType TriangleType { get => GetTriangleType(); }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        private TriangleType GetTriangleType()
        {
            if (!CheckIsValid())
            {
                return TriangleType.None;
            }

            var maxSide = Math.Max(Math.Max(SideA, SideB), SideC);
            var minSide = Math.Min(Math.Min(SideA, SideB), SideC);
            var midSide = SideA + SideB + SideC - maxSide - minSide;

            var sqrdMaxSide = Math.Pow(maxSide, 2);
            var sqrdMinSide = Math.Pow(minSide, 2);
            var sqrdMidSide = Math.Pow(midSide, 2);

            if (sqrdMaxSide > sqrdMinSide + sqrdMidSide)
            {
                return TriangleType.ObtuseAngled;
            }
            else if (sqrdMaxSide == sqrdMinSide + sqrdMidSide)
            {
                return TriangleType.Rectangular;
            }
            else
            {
                return TriangleType.Acute;
            }
        }

        private bool CheckIsValid()
        {
            return SideA + SideB > SideC
                && SideA + SideC > SideB
                && SideB + SideC > SideA;
        }
    }
}