using System;
using System.Collections.Generic;



namespace SodaMachineApplication
{

    public abstract class Soda
    {
        public string Name { get; set; }
        public int Nr { get; set; }
        public int Price {get;set;}

        public (string output, int credit) Order(int money) {

            string output;

            if (money >= Price && Nr > 0)
            {
                output = $"Giving {Name} out \n\n";
                money -= 20;
                output += $"Giving {money} + out in change \n\n";
                money = 0;
                Nr--;
            }
            else if (Nr == 0)
            {
                output = $"No {Name} left";
            }
            else
            {
                output = $"Need {(Price - money)} more";
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
