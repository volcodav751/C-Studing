using System.Text;

namespace Practice1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("Завдання 1");

            double a = 5;
            double b = 3;
            double result = For_1_Exercise.PerformOperation(a, b, For_1_Exercise.Add);
            Console.WriteLine(result);

            result = For_1_Exercise.PerformOperation(a, b, For_1_Exercise.Subtract);
            Console.WriteLine(result);

            result = For_1_Exercise.PerformOperation(a, b, For_1_Exercise.Multiply);
            Console.WriteLine(result);

            try
            {
                result = For_1_Exercise.PerformOperation(a, 0, For_1_Exercise.Divide);
                Console.WriteLine(result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("unluck");
            }

            Console.WriteLine("\nЗавдання 2");

            For_2_Exercise.NotificationHandler? operation = null;
            operation += For_2_Exercise.SendEmail;
            operation += For_2_Exercise.SendSMS;
            operation?.Invoke("textforexercise");

            Console.WriteLine("\nЗавдання 3");

            int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            Console.Write("Парні числа: ");
            For_3_Exercise.FilterArray(numbers, For_3_Exercise.IsPair);

            Console.Write("Числа більше 5: ");
            For_3_Exercise.FilterArray(numbers, For_3_Exercise.IsMore5);

            Console.Write("Непарні числа: ");
            For_3_Exercise.FilterArray(numbers, n => n % 2 != 0);

            Console.WriteLine("\nЗавдання 4");

            Func<double, double, double> mathOperation = For_4_Exercise.Add;
            Console.WriteLine($"Add: {mathOperation(10, 5)}");

            mathOperation = For_4_Exercise.Subtract;
            Console.WriteLine($"Subtract: {mathOperation(10, 5)}");

            mathOperation = For_4_Exercise.Multiply;
            Console.WriteLine($"Multiply: {mathOperation(10, 5)}");

            try
            {
                mathOperation = For_4_Exercise.Divide;
                Console.WriteLine($"Divide: {mathOperation(10, 2)}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ділення на нуль!");
            }

            List<string> students = new List<string>
            {
                "Максим",
                "Марія",
                "Олег",
                "Микита",
                "Іван",
                "Анна"
            };

            List<string> namesWithM = students.FindAll(name => name.StartsWith('М'));

            Console.WriteLine("Імена на літеру М:");
            foreach (string name in namesWithM)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nЗавдання 5");

            Logger logger = new Logger();

            logger.LogHandler = message => Console.WriteLine("Log: " + message);
            logger.Log("звичайне повідомлення");

            logger.LogHandler = message => Console.WriteLine(message.ToUpper());
            logger.Log("повідомлення у верхньому регістрі");

            Console.WriteLine("\nЗавдання 6");

            For_6_Exercise.Validator loginValidator = For_6_Exercise.GetValidator(3);
            For_6_Exercise.Validator passwordValidator = For_6_Exercise.GetValidator(8);

            Console.Write("Введіть логін: ");
            string? login = Console.ReadLine();

            Console.Write("Введіть пароль: ");
            string? password = Console.ReadLine();

            Console.WriteLine($"Логін коректний: {loginValidator(login ?? "")}");
            Console.WriteLine($"Пароль коректний: {passwordValidator(password ?? "")}");
        }
    }
}