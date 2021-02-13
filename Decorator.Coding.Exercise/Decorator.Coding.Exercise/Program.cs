using System;

namespace Decorator.Coding.Exercise
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        public int age;
        Lizard lizard = new Lizard();
        Bird bird = new Bird();
        public int Age
        {
            get { return age; }
            set { age = lizard.Age = bird.Age = value; }
        }

        public string Fly()
        {
            return bird.Fly();
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dragon youngDragon = new Dragon { Age = 1 };
            Console.WriteLine("youngster");
            Console.WriteLine(youngDragon.Fly());
            Console.WriteLine(youngDragon.Crawl()+"\n");

            Dragon elderDragon = new Dragon { Age = 11 };
            Console.WriteLine("elder");
            Console.WriteLine(elderDragon.Fly());
            Console.WriteLine(elderDragon.Crawl());
        }
    }
}
