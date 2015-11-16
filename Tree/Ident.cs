// Ident -- Parse tree node class for representing identifiers

using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;

        public Ident(string n)
        {
            name = n;
        }

        public override void print(int n)
        {
            Printer.printIdent(n, name);
        }

        public override String getName()
        {
            return name;
        }

        public override bool isSymbol()
        {
            return true;
        }

        //added
        public String getSymbol()
        {
            return name;
        }

        //added
        public Node eval(Node t, Environment env)
        {
            Node args;
            Node a = new Cons(new Ident(t.getName()), new Nil());
            args = eval_list(a, env);
            if (!args.isNull())
            {
                if (args.getCar().isPair())
                {
                    if (Environment.errorMessages.Count == 0)
                    {
                        Printer.printQuote(args, 0, true);
                    }
                    else
                    {
                        String newErr = "";
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
                else if (args.getCar().isNumber())
                {
                    return new IntLit(args.getCar().getVal());
                }
                else if (args.getCar().isString())
                {
                    return new StringLit(args.getCar().getStrVal());
                }
                else if (args.getCar().isBool())
                {
                    return new BoolLit(args.getCar().getBool());
                }
                else
                {
                    Console.WriteLine("placeholder");
                    return new Nil();
                }
            }
            else
            {
                return null;
            }
            return new StringLit("");
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
                Node arg1;
                Node rest;
                arg1 = t.getCar();
                rest = t.getCdr();

                if (arg1.isSymbol())
                {
                    arg1 = env.lookup(arg1);
                }
                if (arg1 == null || arg1.isNull())
                {
                    return new Nil();
                }
                Node list = new Cons(arg1.eval(env), eval_list(rest, env));
                return list;
            }
        }
    }
}

