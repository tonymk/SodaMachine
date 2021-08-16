using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace SodaMachineApplication.Tests
{
    public class OrderTests
    {
        [Fact]
        public void TestOrderWithSodaMachine()
        {
            var machine = new SodaMachine();

            var fill = new List<Soda> {
                new Coke { Nr = 1 },
                new Fanta {  Nr = 2 },
                new Sprite { Nr = 2 },
            };

            machine.fillMachine(fill);

            machine.InsertCredit("insert 20");

            machine.Order("order coke");

            Assert.Equal(2, machine.TypesInInventory().Count());

        }

        [Fact]
        public void TestOrderWithSuccess()
        {
            var coke = new Coke {
                Nr = 1
            };
            var res = coke.Order(20);

            Assert.Equal(0, res.credit);

            Assert.Equal("Giving coke out \n\nGiving 0 out in change", res.output);
        }

        [Fact]
        public void TestOrderNoStock()
        {
            var fanta = new Fanta {
                Nr = 0
            };

            var res = fanta.Order(100);

            Assert.Equal("No fanta left", res.output);
        }

        [Fact]
        public void TestOrderNeedMore()
        {
            var sprite = new Sprite
            {
                Nr = 1
            };

            var res = sprite.Order(14);

            Assert.Equal("Need 1 more", res.output);
        }

        [Fact]
        public void TestStockGetsLess()
        {
            var coke = new Coke
            {
                Nr = 1
            };
            var res = coke.Order(100);

            Assert.Equal(0, res.credit);

            res = coke.Order(100);

            Assert.Equal("No coke left", res.output);
        }










    }
}
