using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Program
    {
        public static bool IsEven(int number)
        {
            bool isbool;
            if (number % 2 == 0) isbool = true;
            else isbool = false;
            return isbool;
        }
        public static string GetMessage(int number)
        {
            bool isbool = IsEven(number);
            if (isbool == true) return "Двері відкриваються!";
            else return "Двері зачинені...";
        }
        static void Main()
        {
            Console.WriteLine("write number");
            string txtnumber = Console.ReadLine();
            int number = int.Parse(txtnumber);


            Console.WriteLine(GetMessage(number));


            Console.WriteLine("For exite, do something");
            Console.ReadKey();

        }

    }
}
