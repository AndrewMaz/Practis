using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Memento.Coding.Exercise
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public List<Token> Tokens = new List<Token>();
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            Tokens.Add(new Token(value));
            var m = new Memento();
            m.Tokens = Tokens.Select(t => new Token(t.Value)).ToList();

            return m;
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(new Token(token.Value));
            var m = new Memento();
            m.Tokens = Tokens.Select(t => new Token(t.Value)).ToList();

            return m;
        }

        public void Revert(Memento m)
        {
            if (m != null)
            {
                Tokens = m.Tokens.Select(t => new Token(t.Value)).ToList();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tm = new TokenMachine();

            var m1 = tm.AddToken(1);
            var m2 = tm.AddToken(2);

            Console.WriteLine($"Количество {m2.Tokens.Count}, значение первого: {m2.Tokens[0].Value}, значение второго: {m2.Tokens[1].Value}");

            tm.Revert(m1);
            Console.WriteLine($"Количество {m1.Tokens.Count}, значение первого: {m1.Tokens[0].Value}");

            var t = new Token(3);
            tm.AddToken(t);
            tm.AddToken(4);
            var m3 = tm;

            Console.WriteLine($"Количество {m3.Tokens.Count}, " +
                $"значение первого: {m3.Tokens[0].Value}, " +
                $"значение второго: {m3.Tokens[1].Value}, " +
                $"значение третьего: {m3.Tokens[2].Value}");

            tm.Revert(m2);

            Console.WriteLine($"Количество {m2.Tokens.Count}, значение первого: {m2.Tokens[0].Value}, значение второго: {m2.Tokens[1].Value}");
        }
    }
}
