using System;
using Xunit;
using System.Linq;
using SodaMachineApplication;

namespace SodaMachineApplication.Tests
{
    public class SodaTests
    {
        [Fact]
        public void TestGetSoda()
        {
            var sodaMachine = new SodaMachine();

            var fill = new List<Soda> {
                new Coke { Nr = 5 },
                new Fanta {  Nr = 3 },
                new Sprite { Nr = 3 },
            };

            sodaMachine.fillMachine(fill);

            var soda = sodaMachine.GetSoda("coke");

            Assert.Equal("coke", soda.Name);


            soda = sodaMachine.GetSoda("fanta");

            Assert.Equal("fanta", soda.Name);


            soda = sodaMachine.GetSoda("sprite");

            Assert.Equal("sprite", soda.Name);

        }












    }
}
