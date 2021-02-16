using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Command.Coding.Exercise
{
    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
    }

    public class Account
    {

        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    Balance += c.Amount;
                    c.Success = true;
                    break;

                case Command.Action.Withdraw:
                    if (Balance >= c.Amount)
                    {
                        Balance -= c.Amount;
                        c.Success = true;
                    }
                    else
                        c.Success = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (!c.Success)
                Console.WriteLine("На вашем счету недостаточно средств\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var ac = new Account { Balance = 1000 };
            ac.Process(new Command { Amount = 500, TheAction = Command.Action.Deposit });
            Console.WriteLine(ac.Balance); // 1500

            ac.Process(new Command { Amount = 1000, TheAction = Command.Action.Withdraw });
            Console.WriteLine(ac.Balance); // 500

            ac.Process(new Command { Amount = 1000, TheAction = Command.Action.Withdraw });
            Console.WriteLine(ac.Balance); // 500
        }
    }
}
