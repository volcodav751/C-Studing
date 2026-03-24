using System;
using System.Text;

namespace Practise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("Практична робота №2");
            Console.WriteLine("\n===== Завдання 1. Клімат-контроль =====");

            Sensor sensor = new Sensor();
            Display display = new Display();
            AirConditioner airConditioner = new AirConditioner();
            SecuritySystem securitySystem = new SecuritySystem();

            sensor.SendTypeWorking += display.ShowTemperature;
            sensor.SendTypeWorking += airConditioner.React;
            sensor.SendTypeWorking += securitySystem.React;

            sensor.SetTemperature(4);
            sensor.SetTemperature(18);
            sensor.SetTemperature(28);
            sensor.SetTemperature(45);

            Console.WriteLine("\n===== Завдання 2. Player отримує Damage =====");

            Player player = new Player(100);
            UIHealthBar uiHealthBar = new UIHealthBar();
            SoundSystem soundSystem = new SoundSystem();
            AchievementSystem achievementSystem = new AchievementSystem();
            GameLogger gameLogger = new GameLogger();

            player.DamageTaken += uiHealthBar.UpdateHealth;
            player.DamageTaken += soundSystem.PlaySound;
            player.DamageTaken += achievementSystem.CheckAchievements;
            player.DamageTaken += gameLogger.Log;

            player.TakeDamage(20);
            player.TakeDamage(30);
            player.TakeDamage(35);
            player.TakeDamage(20);
        }
    }
}