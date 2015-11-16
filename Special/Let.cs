// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printLet(t, n, p);
        }

        //added
        public override Node eval(Node t, Environment env)
        {
            Node args;
            Node exp;
            Environment local = new Environment(env);
            args = t.getCdr().getCar();
            exp = t.getCdr().getCdr().getCar();
            args = evalBody(args, local);
            return exp.eval(local);
        }

        //added
        public Node evalBody(Node t, Environment env)
        {
            if (t == null || t.isNull())
            {
                Node list = new Cons(new Nil(), new Nil());
                return list;
            }
            else
            {
                Node arg, exp, rest;
                arg = t.getCar().getCar();
                exp = t.getCar().getCdr().getCar();
                rest = t.getCdr();

                if (arg.isSymbol())
                {
                    env.define(arg, exp.eval(env));
                    return evalBody(rest, env);
                }
                else if (arg.isPair())
                {
                    return arg.eval(env);
                }
                else if (arg == null || arg.isNull())
                {
                    return new Nil();
                }
            }
            return null;
        }
    }
}


