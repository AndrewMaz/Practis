using System;
using System.Collections.Generic;

namespace Mediator.Coding.Exercise
{
    public class Participant
    {
        readonly Mediator mediator;
        readonly public string name;
        static int counter = 1;
        public int Value { get; set; }

        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
            Value = 0;
            name = $"Участник {counter}";
            counter++;

            mediator.Events += Alert;
        }

        public void Alert(object sender, int value)
        {
            if (sender != this)
                Value = value;
        }
        public void Say(int n)
        {
            mediator.Broadcast(this, n);
        }
    }

    public class Mediator
    {
        public event EventHandler<int> Events;

        public void Broadcast(object sender, int n)
        {
            Events?.Invoke(sender, n);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new Mediator();

            var p1 = new Participant(mediator);
            var p2 = new Participant(mediator);

            Console.WriteLine($"{p1.name}, {p1.Value}");
            Console.WriteLine($"{p2.name}, {p2.Value}\n");

            p1.Say(1);
            Console.WriteLine($"{p1.name}, {p1.Value}");
            Console.WriteLine($"{p2.name}, {p2.Value}\n");

            p2.Say(5);
            Console.WriteLine($"{p1.name}, {p1.Value}");
            Console.WriteLine($"{p2.name}, {p2.Value}");
        }
    }
}
