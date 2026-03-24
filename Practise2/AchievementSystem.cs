using System;

namespace Practise2
{
    public class AchievementSystem
    {
        private bool halfHealthUnlocked = false;
        private bool firstDeathUnlocked = false;

        public void CheckAchievements(int damage, int currentHp)
        {
            if (currentHp <= 50 && !halfHealthUnlocked)
            {
                halfHealthUnlocked = true;
                Console.WriteLine("AchievementSystem: Досягнення 'Half Health'");
            }

            if (currentHp <= 0 && !firstDeathUnlocked)
            {
                firstDeathUnlocked = true;
                Console.WriteLine("AchievementSystem: Досягнення 'First Death'");
            }
        }
    }
}