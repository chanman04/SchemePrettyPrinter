// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printIf(t, n, p);
        }

        //added
        public override Node eval(Node t, Environment env)
        {
            Node cond;
            Node exp;
            cond = t.getCdr().getCar();
            if (cond.eval(env).getBool())
            {
                exp = t.getCdr().getCdr().getCar();
                return exp.eval(env);
            }
            else if (!(t.getCdr().getCdr().getCdr()).isNull())
            {
                exp = t.getCdr().getCdr().getCdr().getCar();
                return exp.eval(env);
            }
            else
            {
                Console.WriteLine("No Else Expression");
                return new Nil();
            }
        }
    }
}

