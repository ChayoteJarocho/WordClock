using System;
using System.Collections.Generic;
using System.Text;

namespace WordClock
{
    public class Line
    {
        private readonly List<Letter> _letters;

        public Line(List<Letter> letters) => _letters = letters;

        public void Print()
        {
            foreach (Letter letter in _letters)
            {
                letter.Print();
            }

            Console.WriteLine();
        }

        public string Get()
        {
            var line = new StringBuilder();

            bool lastWasSpace = true;
            bool currentIsSpace;
            char c;
            foreach (Letter letter in _letters)
            {
                c = letter.Get();

                currentIsSpace = char.IsWhiteSpace(c);

                if ((currentIsSpace && !lastWasSpace) || !currentIsSpace)
                {
                    line.Append(c);
                }

                lastWasSpace = currentIsSpace;
            }

            if (!lastWasSpace)
            {
                line.Append(' ');
            }

            return line.ToString();
        }
    }
}
