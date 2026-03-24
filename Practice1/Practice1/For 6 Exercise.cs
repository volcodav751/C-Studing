using System;

namespace Practice1
{
    public class For_6_Exercise
    {
        public delegate bool Validator(string text);

        public static Validator GetValidator(int minLength)
        {
            return text => !string.IsNullOrEmpty(text) && text.Length >= minLength;
        }
    }
}