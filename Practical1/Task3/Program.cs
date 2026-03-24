using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Program
    {
        public static string ClassifyAge(int age)
        {
            if (age < 0 || age > 120) return "Нереальний вік";
            else if (age < 12) return "Ви дитина";
            else if (age >= 12 && age <= 17) return "Підліток";
            else if (age >= 18 && age <= 59) return "Дорослий";
            else return "Пенсіонер";
        }

        static void Main()
        {
            int age = 0;
            Console.WriteLine("Enter age");
            string inputage = Console.ReadLine();
            age = int.Parse(inputage);
            Console.WriteLine(ClassifyAge(age));
            Console.WriteLine("For exite, do something");
            Console.ReadKey();
        }
    }
}