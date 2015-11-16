# Scheme4101
Project 2 for CSC4101 Programming Languages

The two main packages to our project are Tree and Special. In the Regular class we implemented a eval() method and evalNode() method. We use eval() to inspect the parameter Node t's car variable. Then we are able to call evalNode() to check its cdr and the rest of the environment.

As for the apply() method we wrote gigantic if then else chain to check what the value of the BuiltIn or the value of the Node in the Tree Environment was and to create the corresponding object in the Tree whether Cons, IntLit, BooLit etc.

The rest was filling in the necessary override methods within the specific Tree classes to override the virtual methods within the Node class.

Finally we created the Environment and the top level envrionment as well as the read-eval print loop based on the hints you provided within your email. 

The project currently works correctly and correctly formats the print of the output we have tested and verified on the classes servers.

That's All Folks!
Group memebers in this Scheme endeavor:
Michael Chan
Kyle Martinez
