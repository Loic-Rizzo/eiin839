using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperations.IMathsOperations mathsOperations = new MathsOperations.MathsOperationsClient();
            Console.WriteLine("--- 8 + 12 ---");
            Console.WriteLine(mathsOperations.Add(8, 12));
            Console.WriteLine("--- 20 - 10 ---");
            Console.WriteLine(mathsOperations.Subtract(20, 10));
            Console.WriteLine("--- 5 * 2.5 ---");
            Console.WriteLine(mathsOperations.Multiply(5, 2.5));
            Console.WriteLine("--- 20 / 2 ---");
            Console.WriteLine(mathsOperations.Divide(50, 2));
            Console.ReadLine();
        }
    }
}
