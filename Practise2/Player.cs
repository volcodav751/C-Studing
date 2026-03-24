using System;

namespace Practise2
{
    public class Player
    {
        public int HP { get; private set; }

        public delegate void DamageHandler(int damage, int currentHp);
        public event DamageHandler? DamageTaken;

        public Player(int hp)
        {
            HP = hp;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            Console.WriteLine($"\nPlayer отримав {damage} урону");

            DamageTaken?.Invoke(damage, HP);
        }
    }
}