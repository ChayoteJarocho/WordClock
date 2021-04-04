using System;
using System.Collections.Generic;
using System.Text;

namespace WordClock
{
    public abstract class Clock
    {
        public int H => _dt.Hour;
        public int M => _dt.Minute;
        public bool H1 => H == 1 || H == 13;
        public bool H2 => H == 2 || H == 14;
        public bool H3 => H == 3 || H == 15;
        public bool H4 => H == 4 || H == 16;
        public bool H5 => H == 5 || H == 17;
        public bool H6 => H == 6 || H == 18;
        public bool H7 => H == 7 || H == 19;
        public bool H8 => H == 8 || H == 20;
        public bool H9 => H == 9 || H == 21;
        public bool H10 => H == 10 || H == 22;
        public bool H11 => H == 11 || H == 23;
        public bool H12 => H == 12 || H == 0;

        private DateTime _dt;

        protected readonly List<Line> Lines = new();

        public static Clock Create(Language language) =>
            language switch
            {
                Language.Spanish => new ClockSpanish(),
                _ => throw new NotSupportedException($"Language {language} not supported yet.")
            };

        public Clock() => _dt = DateTime.Now;

        public string Get(DateTime dt)
        {
            _dt = dt;

            var text = new StringBuilder();

            foreach (Line line in Lines)
            {
                text.Append(line.Get());
            }

            return text.ToString();
        }

        public void Print(DateTime dt)
        {
            _dt = dt;

            foreach (Line line in Lines)
            {
                line.Print();
            }
        }
    }
}
