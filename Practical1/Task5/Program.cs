using System;

namespace Task5
{
    public class Program
    { 
        public static double GetAverage(int[] marks)
        {
            int sum = 0;
            foreach (int m in marks)
            {
                sum += m;
            }
            return (double)sum / marks.Length;
        }

        public static int GetMin(int[] marks)
        {
            int min = marks[0];
            foreach (int m in marks)
            {
                if (m < min) min = m;
            }
            return min;
        }

        public static int GetMax(int[] marks)
        {
            int max = marks[0];
            foreach (int m in marks)
            {
                if (m > max) max = m;
            }
            return max;
        }

        public static void PrintGroupStatistics(int[][] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                double avg = GetAverage(groups[i]);
                int min = GetMin(groups[i]);
                int max = GetMax(groups[i]);
                Console.WriteLine($"Група {i + 1}: Середній = {Math.Round(avg, 2)}, Мінімальний = {min}, Максимальний = {max}");
            }
        }

        public static void Main(string[] args)
        {
            Random random = new Random();
            int groupCount = random.Next(3, 6);
            int[][] groups = new int[groupCount][];

            for (int i = 0; i < groupCount; i++)
            {
                int studentCount = random.Next(10, 31);
                groups[i] = new int[studentCount];
                for (int j = 0; j < studentCount; j++)
                {
                    groups[i][j] = random.Next(50, 101);
                }
            }

            PrintGroupStatistics(groups);
        }
    }
}
