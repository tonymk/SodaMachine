using System;
using Xunit;
using System.Linq;

namespace SodaMachine.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestOrderWithSuccess()
        {
            var coke = new Coke {
                Nr = 1
            };
            var res = coke.Order(100);

            Assert.Equal(0, res.credit);

        }

        [Fact]
        public void TestOrderNoStock()
        {
            var fanta = new Fanta {
                Nr = 0
            };

            var res = fanta.Order(100);

            Assert.Equal("No fanta left", res.output.First());
        }

        [Fact]
        public void TestOrderNeedMore()
        {
            var sprite = new Sprite
            {
                Nr = 1
            };

            var res = sprite.Order(10);

            Assert.Equal("Need 5 more", res.output.First());
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

            Assert.Equal("No coke left", res.output.First());
        }










    }
}
