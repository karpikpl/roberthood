using System;
using System.IO;
using System.Linq;
using KattisSolution.IO;

namespace KattisSolution
{
    public struct Point
    {
        public readonly int X;
        public readonly int Y;
        public readonly double Dist;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            Dist = Math.Sqrt(x * x + y * y);
        }

        public static readonly Point Empty = new Point();

        public static double CalculateDistance(ref Point p1, ref Point p2)
        {
            var a = Math.Pow(p1.X - p2.X, 2);
            var b = Math.Pow(p1.Y - p2.Y, 2);

            return Math.Sqrt(a + b);
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}", X, Y);
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            Solve(Console.OpenStandardInput(), Console.OpenStandardOutput());
        }

        public static void Solve(Stream stdin, Stream stdout)
        {
            IScanner scanner = new OptimizedIntReader(stdin);
            // uncomment when you need more advanced reader
            scanner = new Scanner(stdin);
            BufferedStdoutWriter writer = new BufferedStdoutWriter(stdout);

            var size = scanner.NextInt();

            Point[] points = new Point[size];

            for (int i = 0; i < size; i++)
            {
                points[i] = new Point(scanner.NextInt(), scanner.NextInt());
            }

            //    var result = OldSolution.Solve(points);
            var result = Solve(ref points);

            writer.Write(result);
            writer.Write("\n");
            writer.Flush();
        }

        public static double Solve(ref Point[] points)
        {
            double max = 0, dist;

            var candidates = points.OrderByDescending(p => p.Dist).ToArray();

            var howMany = candidates.Length > 10 ? 10 : candidates.Length;

            for (int i = 0; i < howMany; i++)
            {
                for (int j = i + 1; j < candidates.Length; j++)
                {
                    dist = Point.CalculateDistance(ref candidates[i], ref candidates[j]);

                    if (dist > max)
                        max = dist;
                }
            }

            return max;
        }
    }
}
