using System;
using System.Collections.Generic;



namespace SodaMachine
{

    public abstract class Soda
    {
        public string Name { get; set; }
        public int Nr { get; set; }
        public int Price {get;set;}

        public (IEnumerable<string> output, int credit) Order(int money) {

            List<string> output = new List<string>();

            if (money >= Price && Nr > 0)
            {
                output.Add($"Giving {Name} out");
                money -= 20;
                output.Add($"Giving {money} + out in change");
                money = 0;
                Nr--;
            }
            else if (Nr == 0)
            {
                output.Add($"No {Name} left");
            }
            else
            {
                output.Add($"Need {(Price - money)} more");
            }

            return (output, money);
        }
    }

    public class Coke : Soda {
        public Coke() {
            Name = "coke";
            Price = 20;
        }
    }

    public class Fanta : Soda {
        public Fanta() {
            Name = "fanta";
            this.Price = 15;
        }
    }

    public class Sprite : Soda {
        public Sprite() {
            Name = "sprite";
            this.Price = 15;
        }

    }


}
