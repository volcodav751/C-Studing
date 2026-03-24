using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    public class For_3_Exercise
    {
        public  delegate bool FilterPredicate (int numbers);
        public static void FilterArray(int[] numbers, FilterPredicate predicate)
        {
            foreach(int num in numbers)
            {
                if (predicate(num))
                {
                    Console.Write(num + " ");
                }
            }
            Console.WriteLine(" ");
        }

        public static bool IsMore5(int numbers)
        {
            return numbers > 5;
        }

        public static bool IsPair(int numbers)
        {
            return numbers % 2 == 0;
        }
    } 
}
