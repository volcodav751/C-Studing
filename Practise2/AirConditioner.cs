using System;

namespace Practise2
{
    public class AirConditioner
    {
        public void React(int temperature)
        {
            if (temperature < 17)
            {
                HeatOn();
            }
            else if (temperature >= 17 && temperature <= 25)
            {
                TurnOff();
            }
            else
            {
                TurnFreezeOn();
            }
        }
        public void HeatOn()
        {
            Console.WriteLine("AirConditioner: Увімкнено обігрів");
        }
        public void TurnOff()
        {
            Console.WriteLine("AirConditioner: Кондиціонер вимкнено");
        }
        public void TurnFreezeOn()
        {
            Console.WriteLine("AirConditioner: Увімкнено охолодження");
        }
    }
}