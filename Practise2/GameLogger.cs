using System;

namespace Practise2
{
    public class GameLogger
    {
        public void Log(int damage, int currentHp)
        {
            Console.WriteLine($"GameLogger: Damage = {damage}, Current HP = {currentHp}");
        }
    }
}