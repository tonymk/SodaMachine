using System;
using System.Collections.Generic;
using System.Linq;

namespace SodaMachineApplication
{
    public class SodaMachine
    {

        private int money;
        private List<Soda> inventory = new List<Soda>();

        private void Order(string input) {
            var sodaType = input.Split(' ')[1];
            var soda = GetSoda(sodaType);
            if(soda == null) return;

            var res  = soda.Order(money);

            money = res.credit;
            Console.WriteLine(res.output);
        }

        private IEnumerable<string> TypesInInventory() {
            return inventory.Select(s => s.Name);
        }

        public void fillMachine(List<Soda> fill) {
            inventory = inventory.AddRange(fill);
        }

        private void Prompt() {
            Console.WriteLine("\n\nAvailable commands:");
            Console.WriteLine("insert (money) - Money put into money slot");
            Console.WriteLine($"order ({string.Join(", ", TypesInInventory())}) - Order from machines buttons");
            Console.WriteLine($"sms order ({string.Join(", ", TypesInInventory())}) - Order sent by sms");
            Console.WriteLine("recall - gives money back");
            Console.WriteLine("-------");
            Console.WriteLine($"Inserted money: {money}");
            Console.WriteLine("-------\n\n");
        }

        private void InsertCredit(string input) {
            //Add to credit
            var added = input.Split(' ')[1];
            money += int.Parse(added);
            Console.WriteLine($"Adding {added} to credit");
        }

        public Soda GetSoda(string soda) {
            switch(soda) {
                case "coke":
                    return inventory[0];
                case "fanta":
                    return inventory[1];
                case "sprite":
                    return inventory[2];
                default:
                    Console.WriteLine("No such soda");
                    return null;
            }
        }



        /// <summary>
        /// This is the starter method for the machine
        /// </summary>
        public void Start()
        {

            var fill = new List<Soda> {
                new Coke { Nr = 5 },
                new Fanta {  Nr = 3 },
                new Sprite { Nr = 3 },
            };

            fillMachine(fill);

            while (true)
            {
                Prompt();

                var input = Console.ReadLine();

                if (input.StartsWith("insert"))
                {
                    InsertCredit();
                }
                if (input.StartsWith("order"))
                {
                    Order(input);
                }
                if (input.StartsWith("sms order"))
                {
                    var csoda = input.Split(' ')[2];
                    //Find out witch kind
                    switch (csoda)
                    {
                        case "coke":
                            if (inventory[0].Nr > 0)
                            {
                                Console.WriteLine("Giving coke out");
                                inventory[0].Nr--;
                            }
                            break;
                        case "sprite":
                            if (inventory[1].Nr > 0)
                            {
                                Console.WriteLine("Giving sprite out");
                                inventory[1].Nr--;
                            }
                            break;
                        case "fanta":
                            if (inventory[2].Nr > 0)
                            {
                                Console.WriteLine("Giving fanta out");
                                inventory[2].Nr--;
                            }
                            break;
                    }

                }

                if (input.Equals("recall"))
                {
                    //Give money back
                    Console.WriteLine("Returning " + money + " to customer");
                    money = 0;
                }

            }
        }
    }

}
