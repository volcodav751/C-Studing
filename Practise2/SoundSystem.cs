using System;

namespace Practise2
{
    public class SoundSystem
    {
        public void PlaySound(int damage, int currentHp)
        {
            Console.WriteLine("SoundSystem: Відтворено звук отримання урону");

            if (currentHp <= 20)
            {
                Console.WriteLine("SoundSystem: Відтворено звук критичного стану");
            }
        }
    }
}