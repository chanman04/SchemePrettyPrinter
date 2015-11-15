// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
	public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            Printer.printCond(t, n, p);
        }

        //added
        public override Node eval(Node t, Environment env)
        {
            Node exp;
            exp = t.getCdr();

            while ((!(exp.getCar()).getCar().eval(env).getBool())
                    && (!exp.isNull()))
            {
                exp = exp.getCdr();
            }

            if (exp.isNull())
            {
                return new Nil();
            }
            else
            {
                return (exp.getCar().getCdr().getCar().eval(env));
            }
        }
    }
}


