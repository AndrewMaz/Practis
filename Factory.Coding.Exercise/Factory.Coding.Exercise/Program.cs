using System;

namespace Factory.Coding.Exercise
{
    class Program
    {
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class PersonFactory
        {
            static int counter = 0;
            public static Person CreatePerson(string name)
            {
                Person person = new Person();
                person.Id = counter;
                person.Name = name;
                counter++;

                return person;    
            }
        }
        static void Main(string[] args)
        {
            var p1 = PersonFactory.CreatePerson("Виктор");
            var p2 = PersonFactory.CreatePerson("Игорь");
            var p3 = PersonFactory.CreatePerson("Майкл");

            Console.WriteLine("{0} {1}\n{2} {3}\n{4} {5}", p1.Id, p1.Name, p2.Id, p2.Name, p3.Id, p3.Name);
        }
    }
}
