using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
     public class For_1_Exercise
     {
        public delegate double MathOperation(double a, double b);
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;

        public static double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }

        public static double PerformOperation(double a, double b, MathOperation operation)
        {
            return operation(a, b);
        }
     }
}
