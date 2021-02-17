using System;

namespace ExternalMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("<HTML><BODY> Hello " + args[0] + " et " + args[1] + "</BODY></HTML>");
            }
            else
                Console.WriteLine("<HTML><BODY> Error : Expected 2 arguments </BODY></HTML>");
        }
    }
}
