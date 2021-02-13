using System;
using System.Text;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class CodeBuilder
    {
        public class Element
        {
            public string Field, Text;
            public List<Element> elements = new List<Element>();

            public Element()
            {

            }
            public Element(string field, string text)
            {
                Field = field;
                Text = text;
            }

            public string ToStringImpl(int indent)
            {
                StringBuilder sb = new StringBuilder();
                if (indent == 0)
                    sb.Append(Field);

                foreach (var e in elements)
                {
                    sb.Append("\n\n");
                    sb.AppendFormat("  public {0} {1};", e.Text, e.Field);
                    sb.Append(e.ToStringImpl(indent + 1));
                }

                if (indent == 0)
                    sb.Append("\n}");

                return sb.ToString();
            }
            public override string ToString()
            {
                return ToStringImpl(0);
            }
        }

        protected Element root = new Element();
        public CodeBuilder(string className)
        {
            root.Field = "public class " + className + "\n{";
        }
 
        public CodeBuilder AddField(string field, string type)
        {
            var e = new Element(field, type);
            root.elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public static implicit operator Element(CodeBuilder builder)
        {
            return builder.root;
        }
    }

    class Program
    {
        static void Main()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
