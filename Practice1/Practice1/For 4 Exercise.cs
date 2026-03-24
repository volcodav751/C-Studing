using System;
using System.Collections.Generic;

namespace Practice1
{
    public class For_4_Exercise
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;

        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return a / b;
        }

        public static List<string> FindStudentsByLetter(List<string> students, char letter)
        {
            return students.FindAll(name => name.StartsWith(letter));
        }
    }
}