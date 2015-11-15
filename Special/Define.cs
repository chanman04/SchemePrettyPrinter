// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printDefine(t, n, p);
        }

        //added
        public override Node eval(Node t, Environment env)
        {
            Node id;
            Node val;

            id = t.getCdr().getCar();
            val = t.getCdr().getCdr().getCar();

            if (id.isSymbol())
            {
                env.define(id, val);
            }
            else
            {
                Closure func = new Closure(new Cons(t.getCdr().getCar().getCdr(), t
                        .getCdr().getCdr()), env);
                env.define(id.getCar(), func);
            }

            return new StringLit("; no values returned");
        }
    }
}


