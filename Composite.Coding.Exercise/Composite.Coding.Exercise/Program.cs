using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite.Coding.Exercise
{
    public interface IValueContainer : IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;

        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var single1 = new SingleValue { Value = 1 };
            var single2 = new SingleValue { Value = 5 };

            List<IValueContainer> numbers = new List<IValueContainer>();
            numbers.Add(single1);
            numbers.Add(single2);

            Console.WriteLine(ExtensionMethods.Sum(numbers)); // 6

            var many = new ManyValues { 2, 3, 4};
            numbers.Add(many);

            Console.WriteLine(ExtensionMethods.Sum(numbers)); // 15
        }
    }
}
