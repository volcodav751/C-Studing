using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise2
{
    public class Sensor
    {
        public int WorkingType;
        public int temperature;
        public delegate void HomeSystem(int temperature);
        public event HomeSystem ?SendTypeWorking;
        public void SetTemperature(int temp)
        {
            temperature = temp;
            PublishType();
        }
        public void PublishType()
        {
            Console.WriteLine($"В кімнаті температура {temperature}");
            SendTypeWorking?.Invoke(temperature);
        }
    }
}
