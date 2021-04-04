using System;
using Xunit;

namespace WordClock.Tests
{
    public class SpanishTests
    {
        private DateTime HM(int hour, int minute)
        {
            DateTime n = DateTime.Now;
            return new DateTime(n.Year, n.Month, n.Day, hour, minute, 0);
        }

        [Fact]
        public void CompareGetStrings()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Clock clock = Clock.Create(Language.Spanish);

            Assert.Equal("Es medianoche", clock.Get(HM(0,0)));
            Assert.Equal("La una de la mañana", clock.Get(HM(1,0)));
        }
    }
}
