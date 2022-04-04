namespace Kinematics
{
    public partial class Molecules
    {

        public static void Main()
        {
            double d = Math.Pow(10, 23);
            double boltzConst = 1.38 / Math.Pow(10, 23);
            Console.WriteLine(boltzConst);
            //areaCircle();
        }
        public static void Level1()
        {

        }
        public static void areaCircle()
        {
            const double radius = 1;
            const double squareSide = radius * 2;
            const double squareArea = squareSide * squareSide;

            var random = new Random();

            const double nPoints = 100000000;
            int nPointsInCircle = 0;
            for (int i = 0; i < nPoints; i++)
            {
                double x = random.NextDouble() * squareSide - radius;
                double y = random.NextDouble() * squareSide - radius;

                if (x * x + y * y < radius * radius)
                {
                    ++nPointsInCircle;
                }
            }
            double ratio = nPointsInCircle / nPoints;
            double areaOfCircle = squareArea * ratio;
            Console.WriteLine($"Area of Circle: {areaOfCircle}");
        }
    }
}