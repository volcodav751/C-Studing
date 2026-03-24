using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    public class For_2_Exercise
    {
        public delegate void NotificationHandler (string message);
        static public void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
        static public void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }
}
