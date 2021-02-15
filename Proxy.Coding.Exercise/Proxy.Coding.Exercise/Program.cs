using System;

namespace Proxy.Coding.Exercise
{
    class Program
    {
        public class Person
        {
            public int Age { get; set; }

            public string Drink()
            {
                return "drinking";
            }

            public string Drive()
            {
                return "driving";
            }

            public string DrinkAndDrive()
            {
                return "driving while drunk";
            }
        }

        public class ResponsiblePerson
        {
            Person person;
            public ResponsiblePerson(Person person)
            {
                this.person = person;
            }

            public string Drink()
            {
                if (person.Age >= 18)
                    return person.Drink();
                return ("too Young");
            }

            public string Drive()
            {
                if (person.Age >= 16)
                    return person.Drive();
                return "too young";
            }

            public string DrinkAndDrive()
            {
                return "dead";
            }
            public int Age { get { return person.Age; } }
        }
        static void Main(string[] args)
        {
            var rp1 = new ResponsiblePerson(new Person { Age = 18 });
            Console.WriteLine(rp1.Drink());
            Console.WriteLine(rp1.Drive()); 
            Console.WriteLine(rp1.DrinkAndDrive() + "\n");

            var rp2 = new ResponsiblePerson(new Person { Age = 14 });
            Console.WriteLine(rp2.Drink());
            Console.WriteLine(rp2.Drive());
            Console.WriteLine(rp2.DrinkAndDrive());
        }
    }
}
