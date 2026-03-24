using System;

namespace Practise2
{
    public class SecuritySystem
    {
        public void React(int temperature)
        {
            if (temperature > 40)
            {
                OverHeat();
            }
            else if (temperature < 5)
            {
                OverFreeze();
            }
        }

        private void OverHeat()
        {
            Console.WriteLine("SecuritySystem: занадто велика температура в кімнаті");
        }

        private void OverFreeze()
        {
            Console.WriteLine("SecuritySystem: попередження про ризик замерзання систем");
        }
    }
}