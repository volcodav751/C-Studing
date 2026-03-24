using System;

namespace Practise2
{
    public class UIHealthBar
    {
        public void UpdateHealth(int damage, int currentHp)
        {
            Console.WriteLine("UIHealthBar: Поточне HP = " + currentHp);
        }
    }
}