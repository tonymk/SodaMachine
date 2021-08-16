namespace SodaMachine
{

    public abstract class Soda
    {
        public string Name { get; set; }
        public int Nr { get; set; }
        public int Cost {get;set;}
    }

    public class Coke : Soda {
        public Coke() {
            Name = "coke";
            Cost = 20;
        }
    }

    public class Fanta : Soda {
        public Fanta() {
            Name = "fanta";
            this.Cost = 15;
        }
    }

    public class Sprite : Soda {
        public Sprite() {
            Name = "sprite";
            this.Cost = 15;
        }

    }


}
