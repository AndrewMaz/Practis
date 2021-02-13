using System;
using System.Collections.Generic;

namespace FlyWeight.Coding.Exercise
{
    public class Sentence
    {
        string[] words;

        Dictionary<int, WordToken> pairs = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            int j = 0;
            words = new string[plainText.Length];

            for (int i=0; i< plainText.Length - 1; i++)
            {
                string PlainText = "";

                foreach (var t in plainText)
                {
                    if (plainText[i] == ' ')
                        break;
                    PlainText += plainText[i];

                    if (i == plainText.Length - 1)
                        break;
                    else
                        i++;
                }

/*                while (plainText[i] != ' ' && i < plainText.Length - 1)
                {
                    PlainText += plainText[i];
                    i++;
                } */

                words[j] += PlainText;
                j++;
            }
        }

        public WordToken this[int index]
        {
            get
            {
                WordToken wordToken = new WordToken();
                pairs.Add(index, wordToken);
                return pairs[index];
            }
        }

        public override string ToString()
        {
            var result = new List<string>();

            for (int i=0; i<words.Length; i++)
            {
                var word = words[i];

                if (pairs.ContainsKey(i) && pairs[i].Capitalize)
                    word = words[i].ToUpper();
                result.Add(word);
            }

            return string.Join(" ", result);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            Console.WriteLine(sentence); // hello WORLD
        }
    }
}
