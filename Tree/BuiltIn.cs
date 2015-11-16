// BuiltIn -- the data structure for built-in functions

// Class BuiltIn is used for representing the value of built-in functions
// such as +.  Populate the initial environment with
// (name, new BuiltIn(name)) pairs.

// The object-oriented style for implementing built-in functions would be
// to include the C# methods for implementing a Scheme built-in in the
// BuiltIn object.  This could be done by writing one subclass of class
// BuiltIn for each built-in function and implementing the method apply
// appropriately.  This requires a large number of classes, though.
// Another alternative is to program BuiltIn.apply() in a functional
// style by writing a large if-then-else chain that tests the name of
// the function symbol.

using System;
using Parse;

namespace Tree
{
    public class BuiltIn : Node
    {
        private Node symbol;            // the Ident for the built-in function

        //added
        protected static Environment interaction_environment = new Environment();

        public BuiltIn(Node s)		{ symbol = s; }

        public Node getSymbol()		{ return symbol; }

        // TODO: The method isProcedure() should be defined in
        // class Node to return false.
        public override bool isProcedure()	{ return true; }

        //added
        public BuiltIn(Environment env)
        {
            interaction_environment = env;
        }

        public override void print(int n)
        {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.Write("#{Built-in Procedure ");
            if (symbol != null)
                symbol.print(-Math.Abs(n));
            Console.Write('}');
            if (n >= 0)
                Console.WriteLine();
        }

        // TODO: The method apply() should be defined in class Node
        // to report an er  ror.  It should be overridden only in classes
        // BuiltIn and Closure.

        //added
        public override Node apply(Node args)
        {
            if (args == null)
            {
                return null;
            }
            String symbolName = symbol.getName();
            Node arg1 = args.getCar();
            if (arg1 == null || arg1.isNull())
            {
                arg1 = new Nil();
            }

            Node arg2 = args.getCdr();
            if (arg2 == null || arg2.isNull())
            {
                arg2 = new Nil();
            }
            else
            {
                arg2 = arg2.getCar();
            }
            if (symbolName.Equals("b+"))
            {
                if (arg1.isNumber() && arg2.isNumber())
                {
                    int x = arg1.getVal();
                    int y = arg2.getVal();
                    return new IntLit(x + y);
                }
                else
                {
                    Console.WriteLine("Error: Bad argument for b+");
                    return new StringLit("");
                }
            }
            else if (symbolName.Equals("b-"))
            {
                if (arg1.isNumber() && arg2.isNumber())
                {
                    int x = arg1.getVal();
                    int y = arg2.getVal();
                    return new IntLit(x - y);
                }
                else
                {
                    Console.WriteLine("Error: Bad argument for b-");
                    return new StringLit("");
                }
            }
            else if (symbolName.Equals("b*"))
            {
                if (arg1.isNumber() && arg2.isNumber())
                {
                    int x = arg1.getVal();
                    int y = arg2.getVal();
                    return new IntLit(x * y);
                }
                else
                {
                    Console.WriteLine("Error: Bad argument for b*");
                    return new StringLit("");
                }
            }
            else if (symbolName.Equals("b/"))
            {
                if (arg1.isNumber() && arg2.isNumber())
                {
                    int x = arg1.getVal();
                    int y = arg2.getVal();
                    return new IntLit(x / y);
                }
                else
                {
                    Console.WriteLine("Error: Bad argument for b/");
                    return new StringLit("");
                }
            }
            else if (symbolName.Equals("b="))
            {
                if (arg1.isNumber() && arg2.isNumber())
                {
                    int x = arg1.getVal();
                    int y = arg2.getVal();
                    return new BoolLit(x == y);
                }
                else
                {
                    Console.WriteLine("Error: Bad argument for b=");
                }
            }
            else if (symbolName.Equals("b<"))
            {
                if (arg1.isNumber() && arg2.isNumber())
                {
                    int x = arg1.getVal();
                    int y = arg2.getVal();
                    return new BoolLit(x < y);
                }
                else
                {
                    Console.WriteLine("Error: Bad argument for b<");
                }
            }
            else if (symbolName.Equals("b>"))
            {
                if (arg1.isNumber() && arg2.isNumber())
                {
                    int x = arg1.getVal();
                    int y = arg2.getVal();
                    return new BoolLit(x > y);
                }
                else
                {
                    Console.WriteLine("Error: Bad argument for b>");
                }
            }
            else if (symbolName.Equals("car"))
            {
                if (arg1.isNull())
                {
                    return arg1;
                }
                return arg1.getCar();
            }
            else if (symbolName.Equals("cdr"))
            {
                if (arg1.isNull())
                {
                    return arg1;
                }
                return arg1.getCdr();
            }
            else if (symbolName.Equals("cons"))
            {
                return new Cons(arg1, arg2);
            }
            else if (symbolName.Equals("set-car!"))
            {
                arg1.setCar(arg2);
                return arg1;
            }
            else if (symbolName.Equals("set-cdr!"))
            {
                arg1.setCdr(arg2);
                return arg1;
            }
            else if (symbolName.Equals("symbol?"))
            {
                return new BoolLit(arg1.isSymbol());
            }
            else if (symbolName.Equals("number?"))
            {
                return new BoolLit(arg1.isNumber());
            }
            else if (symbolName.Equals("null?"))
            {
                return new BoolLit(arg1.isNull());
            }
            else if (symbolName.Equals("pair?"))
            {
                return new BoolLit(arg1.isPair());
            }
            else if (symbolName.Equals("eq?"))
            {
                if (arg1.isBool() && arg2.isBool())
                {
                    return new BoolLit(arg1.getBool() == arg2.getBool());
                }
                else if (arg1.isNumber() && arg2.isNumber())
                {
                    return new BoolLit(arg1.getVal() == arg2.getVal());
                }
                else if (arg1.isString() && arg2.isString())
                {
                    return new BoolLit(arg1.getStrVal().Equals(arg2.getStrVal()));
                }
                else if (arg1.isSymbol() && arg2.isSymbol())
                {
                    return new BoolLit(arg1.getName().Equals(arg2.getName()));
                }
                else if (arg1.isNull() && arg2.isNull())
                {
                    return new BoolLit(true);
                }
                else if (arg1.isPair() && arg2.isPair())
                {
                    Node frontArgs = new Cons(arg1.getCar(), new Cons(
                            arg2.getCar(), new Nil()));
                    Node backArgs = new Cons(arg1.getCdr(), new Cons(arg2.getCdr(),
                            new Nil()));
                    return new BoolLit(apply(frontArgs).getBool()
                            && apply(backArgs).getBool());
                }
                return new BoolLit(false);
            }
            else if (symbolName.Equals("procedure?"))
            {
                return new BoolLit(arg1.isProcedure());
            }
            else if (symbolName.Equals("display"))
            {
                return arg1;
            }
            else if (symbolName.Equals("newline"))
            {
                return new StringLit("", false);
            }
            else if (symbolName.Equals("exit") || symbolName.Equals("quit"))
            {
                System.Environment.Exit(1);
            }
            else if (symbolName.Equals("write"))
            {
                arg1.print(0);
                return new StringLit("");
            }
            else if (symbolName.Equals("eval"))
            {
                return arg1;
            }
            else if (symbolName.Equals("apply"))
            {
                return arg1.apply(arg2);
            }
            else if (symbolName.Equals("read"))
            {
                Scanner scanner = new Scanner(Console.In);
                TreeBuilder builder = new TreeBuilder();
                Parser parser;
                parser = new Parser(scanner, builder);
                Node a = (Node)parser.parseExp();
                return a;
            }
            else if (symbolName.Equals("interaction-environment"))
            {
                interaction_environment.print(0);
            }
            else
            {
                arg1.print(0);
                return new Nil();
            }
            return new StringLit(">");
        }
    }    
}

