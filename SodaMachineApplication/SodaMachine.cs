using System;
using System.Collections.Generic;
using System.Linq;

namespace SodaMachineApplication
{
    public class SodaMachine
    {
        private int Money;
        private List<Soda> Inventory = new List<Soda>();

        private void Prompt() {
            Console.WriteLine("\n\nAvailable commands:");
            Console.WriteLine("insert (money) - Money put into money slot");
            Console.WriteLine($"order ({string.Join(", ", TypesInInventory())}) - Order from machines buttons");
            Console.WriteLine($"sms order ({string.Join(", ", TypesInInventory())}) - Order sent by sms");
            Console.WriteLine("recall - gives money back");
            Console.WriteLine("-------");
            Console.WriteLine($"Inserted money: {Money}");
            Console.WriteLine("-------\n\n");
        }

        public void Order(string input) {
            try
            {
                var sodaType = input.Split(' ')[1];
                var soda = GetSoda(sodaType);
                if (soda == null) return;

                var res = soda.Order(Money);

                Money = res.credit;

                if(soda.Nr == 0) {
                    Inventory.Remove(soda);
                }

            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Missing argument after order");
            }

        }

        public IEnumerable<string> TypesInInventory() {
            return Inventory.Select(s => s.Name);
        }

        public void fillMachine(List<Soda> fill) {
            Inventory.AddRange(fill);
        }

        public Soda GetSoda(string sodaName) {

            var soda =  Inventory.FirstOrDefault(s => {
                return s.Name == sodaName && s.Nr > 0;
            });

            if(soda == null) {

                Console.WriteLine($"No {sodaName} left");
            }

            return soda;

        }

        public string InsertCredit(string input) {
            string added = "";
            string output;
            try
            {
                added = input.Split(' ')[1];
                Money += int.Parse(added);
                output = $"Adding {added} to credit";
            }
            catch(IndexOutOfRangeException)
            {
                output = "Missing number of credits";
            }
            catch(FormatException)
            {
                output = $"{added} is not a number";
            }

            Console.WriteLine(output);
            return output;
        }

        public void SmsOrder(string input) {
            try
            {
                var sodaType = input.Split(' ')[2];
                var soda = GetSoda(sodaType);
                if (soda == null) return;
                soda.SmsOrder();

            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Need to specify a soda");
            }
        }

        public string Recall() {
            var output = $"Returning {Money} to customer";
            Console.WriteLine(output);
            Money = 0;
            return output;
        }

        public void Start()
        {
            var fill = new List<Soda> {
                new Coke { Nr = 2 },
                new Fanta {  Nr = 1 },
                new Sprite { Nr = 1 },
            };

            fillMachine(fill);

            while (true)
            {
                Prompt();

                var input = Console.ReadLine();

                if (input.StartsWith("insert"))
                {
                    InsertCredit(input);
                }
                else if (input.StartsWith("order"))
                {
                    Order(input);
                }
                else if (input.StartsWith("sms order"))
                {
                    SmsOrder(input);
                }
                else if (input.Equals("recall"))
                {
                    Recall();
                }
                else {
                    Console.WriteLine("No such command");
                }

            }
        }




    }
}
