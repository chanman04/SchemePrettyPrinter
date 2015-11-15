// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree
{
    public class StringLit : Node
    {
        private string stringVal;

        //added
        private bool printQuotes;

        public StringLit(string s)
        {
            stringVal = s;
        }

        //added
        public StringLit(string str, bool b)
        {
            stringVal = str;
            printQuotes = b;
        }

        public override void print(int n)
        {
            Printer.printStringLit(n, stringVal);
        }

        public override bool isString()
        {
            return true;
        }

        //added
        public override String getStrVal()
        {
            return stringVal;
        }

        //added
        public Node eval(Node t, Environment env)
        {
            return this;
        }
    }
}

