// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        public Regular() { }

        //public override void print(Node t, int n, bool p)
        //{
        //    Printer.printRegular(t, n, p);
        //}

        //added
        public override void print(Node t, int n, bool p)
        {
            // Printer.printRegular(t, n, p);
            if (Environment.errorMessages.Count == 0)
            {
                Printer.printQuote(t, n, true);
                //Console.Write(")");
                //Console.WriteLine();
            }
            else
            {
                String newErr = "";

                while (Environment.errorMessages != null)
                {
                    for (int i = 0; i < Environment.errorMessages.Count; i++)
                    {
                        string s = Environment.errorMessages[i];
                        string tmp = s;
                        if (!tmp.Equals(newErr))
                        {
                            Console.WriteLine(s);
                        }
                        else
                        {
                            newErr = tmp;
                        }
                    }
                }
            }
        }

        //added
        public override Node eval(Node t, Environment env)
        {
            Node first;
            Node args;

            first = t.getCar();
            args = eval_list(t.getCdr(), env);

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
        public Node eval_list(Node t, Environment env)
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
                Node list = new Cons(arg1.eval(env), eval_list(rest, env));
                return list;
            }
        }
    }
}


