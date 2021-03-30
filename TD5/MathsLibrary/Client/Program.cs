using Client.MathsOperations;
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
            Console.WriteLine(" MathsOperations Client pour SoapEndPnt1 ");
            MathsOperationsClient mathsOperationsClient_1 = new MathsOperationsClient("SoapEndPnt1");
            simpleTest(mathsOperationsClient_1);
            mathsOperationsClient_1.Close();


            Console.WriteLine(" MathsOperations Client pour SoapEndPnt2 ");
            MathsOperationsClient mathsOperationsClient_2 = new MathsOperationsClient("SoapEndPnt2");
            simpleTest(mathsOperationsClient_2);
            mathsOperationsClient_2.Close();


            Console.WriteLine(" MathsOperations Client pour SoapEndPnt3 ");
            MathsOperationsClient mathsOperationsClient_3 = new MathsOperationsClient("SoapEndPnt3");
            simpleTest(mathsOperationsClient_3);
            mathsOperationsClient_3.Close();

            Console.ReadLine();
        }

        private static void simpleTest(MathsOperationsClient mathsOperationsClient)
        {
            Console.WriteLine("--- 8 + 12 ---");
            Console.WriteLine(mathsOperationsClient.Add(8, 12));
            Console.WriteLine("--- 20 - 10 ---");
            Console.WriteLine(mathsOperationsClient.Subtract(20, 10));
            Console.WriteLine("--- 5 * 2.5 ---");
            Console.WriteLine(mathsOperationsClient.Multiply(5, 2.5));
            Console.WriteLine("--- 20 / 2 ---");
            Console.WriteLine(mathsOperationsClient.Divide(50, 2));
        }
    }
}
