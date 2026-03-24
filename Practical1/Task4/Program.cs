using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Program
    {
        public static bool IsValidTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) return false;
            if (a + b <= c || a + c <= b || b + c <= a) return false;
            else return true;
        }
        public static double GetPerimeter(double a, double b, double c)
        {
            double perimeter = a + c + b;
            return perimeter;
        }
        public static double GetArea(double a, double b, double c)
        {
            double p = (a + c + b) / 2;
            double Area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return Area;
        }
        public static string GetTriangleType(double a, double b, double c)
        {
            if (a == b && a == c && c == b) return "рівносторонній";
            else if (a == b || a == c || c == b) return "рівнобедрений";
            else if (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a) return "прямокутний";
            else return "довільний";
        }
        public static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Enter sides");
            string aside = Console.ReadLine();
            a = double.Parse(aside);
            string bside = Console.ReadLine();
            b = double.Parse(bside);
            string cside = Console.ReadLine();
            c = double.Parse(cside);
            if (IsValidTriangle(a, b, c) == false) Console.WriteLine("Unreal triangle, check your sides");
            else
            {
                Console.WriteLine($"Perimeter of triangle: {GetPerimeter(a, b, c)}");
                Console.WriteLine($"Area of triangle:{GetArea(a, b, c)}");
                Console.WriteLine($"Type of triangle:{GetTriangleType(a, b, c)}");
            }

            Console.WriteLine("For exite, do something");
            Console.ReadKey();

        }
    }
}
