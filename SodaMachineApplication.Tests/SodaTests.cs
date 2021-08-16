using System;
using Xunit;
using System.Linq;
using SodaMachineApplication;
using System.Collections.Generic;

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

        [Fact]
        public void TestSmsOrder() {

            var sprite = new Sprite
            {
                Nr = 1
            };

            var output = sprite.SmsOrder();

            Assert.Equal("Giving sprite out", output);

            output = sprite.SmsOrder();

            Assert.Equal("No sprite left", output);
        }

        [Fact]
        public void TestInsertCredit() {

            var sodaMachine = new SodaMachine();

            
            var output = sodaMachine.InsertCredit("insert 100");

            Assert.Equal($"Adding 100 to credit", output);

            output = sodaMachine.InsertCredit("insert");

            Assert.Equal("Missing number of credits", output);

            output = sodaMachine.InsertCredit("insert ABC");

            Assert.Equal($"ABC is not a number", output);
        }
    }
}
