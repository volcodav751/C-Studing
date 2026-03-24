using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Task2
    {
        public class Program
        {
            public static int[] GenerateRandomArray(int size, int min, int max)
            {
                Random random = new Random();
                int[] numbers = new int[size];
                for (int i = 0; i < size; i++)
                {
                    numbers[i] = random.Next(min, max + 1);
                }
                return numbers;
            }

            public static int GetSum(int[] numbers)
            {
                int sum = 0;
                foreach (int num in numbers)
                {
                    sum += num;
                }
                return sum;
            }

            public static double GetAverage(int[] numbers)
            {
                return (double) GetSum(numbers) / numbers.Length;
            }

            public static int GetMin(int[] numbers)
            {
                int min = numbers[0];
                foreach (int num in numbers)
                {
                    if (num < min)
                        min = num;
                }
                return min;
            }

            public static int GetMax(int[] numbers)
            {
                int max = numbers[0];
                foreach (int num in numbers)
                {
                    if (num > max)
                        max = num;
                }
                return max;
            }

            static void Main()
            {
                int[] numbers = GenerateRandomArray(10, 1, 100);

                Console.WriteLine("Generated massive");
                for (int i = 0; i < numbers.Length; i++)
                {
                Console.Write($"{numbers[i]} ");
                }
                Console.WriteLine("");
                Console.WriteLine($"Sum: {GetSum(numbers)}");
                Console.WriteLine($"Avarage: {GetAverage(numbers)}");
                Console.WriteLine($"Minimum {GetMin(numbers)}");
                Console.WriteLine($"Maximum: {GetMax(numbers)}");

                Console.WriteLine("For exite, do something");
                Console.ReadKey();
            }
        }
    }