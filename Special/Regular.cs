 // Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        public Regular() { }

        //added
        public override void print(Node t, int n, bool p)
        {
            Printer.printRegular(t, n, p);
        }

        //added
        public override Node eval(Node t, Environment env)
        {
            Node first;
            Node args;

            first = t.getCar();
            args = evalNode(t.getCdr(), env);

            while (first.isSymbol())
            {
                first = env.lookup(first);
            }

            if (first == null || first.isNull())
            {
                return null;
            }
            if (first.isProcedure())
            {
                return first.apply(args);
            }
            else
            {
                return first.eval(env).apply(args);
            }

        }

        //added
        
        public Node evalNode(Node t, Environment env)
        {
            if (t == null || t.isNull())
            {
                Node list = new Cons(new Nil(), new Nil());
                return list;
            }
            else
            {
                Node arg1, rest;
                arg1 = t.getCar();
                rest = t.getCdr();

                if (arg1.isSymbol())
                {
                    arg1 = env.lookup(arg1);
                }
                if (arg1 == null || arg1.isNull())
                {
                    return null;
                }
                Node list = new Cons(arg1.eval(env), evalNode(rest, env));
                return list;
            }
            
        }
    }
}


