using System;

namespace WordClock
{
    public class Letter
    {
        private const char Space = ' ';
        private readonly Func<bool> _conditions;

        public char C
        {
            get;
            private set;
        }

        private bool CanTurnOn => _conditions();

        public ConsoleColor OffColor { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor OnColor { get; set; } = ConsoleColor.Green;

        public Letter(char c, Func<bool> f)
        {
            C = c;
            _conditions = f;
        }

        public void Print()
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = CanTurnOn ? OnColor : OffColor;
            Console.Write($" {C}");
            Console.ForegroundColor = originalColor;
        }

        public char Get() => CanTurnOn ? C : Space;
    }
}
