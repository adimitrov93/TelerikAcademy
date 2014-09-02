namespace Methods
{
    using System;

    public class Methods
    {
        private const string SideOutOfRangeMessage = "Sides cannot be negative or zero.";

        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (!IsSideValid(sideA))
            {
                throw new ArgumentOutOfRangeException("sideA", SideOutOfRangeMessage);
            }

            if (!IsSideValid(sideB))
            {
                throw new ArgumentOutOfRangeException("sideB", SideOutOfRangeMessage);
            }

            if (!IsSideValid(sideC))
            {
                throw new ArgumentOutOfRangeException("sideC", SideOutOfRangeMessage);
            }

            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));

            return area;
        }

        public static string DigitToWord(int digit)
        {
            string result;

            switch (digit)
            {
                case 0:
                    result = "zero";
                    break;
                case 1:
                    result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("digit", "The digit must be >= 0 and <= 9.");
            }

            return result;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("elements", "The array cannot be null or empty.");
            }

            int max = int.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        public static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = (y1 == y2);

            return isHorizontal;
        }

        public static bool IsVertical(double x1, double x2)
        {
            bool isVertical = (x1 == x2);

            return isVertical;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool isHorizontal = IsHorizontal(-1, 2.5);
            Console.WriteLine("Horizontal? " + isHorizontal);

            bool isVertical = IsVertical(3, 3);
            Console.WriteLine("Vertical? " + isVertical);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        private static bool IsSideValid(double side)
        {
            bool isSideValid = true;

            if (side <= 0)
            {
                isSideValid = false;
            }

            return isSideValid;
        }
    }
}
