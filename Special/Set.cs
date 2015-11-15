// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            Printer.printSet(t, n, p);
        }

        //added
        public override Node eval(Node t, Environment env)
        {
            Node id;
            Node exp;
            id = t.getCdr().getCar();
            exp = t.getCdr().getCdr().getCar();
            env.define(id, exp.eval(env));
            return new StringLit("");
        }
    }
}

