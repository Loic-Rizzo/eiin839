using Client.MathsOperations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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




            Console.WriteLine(" MathsOperations Client pour RestEndPnt1 ");
            Console.WriteLine("REST Call : Add (8 + 12)");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/Rest/Add?x=8&y=12");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readerStream = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
            string responseString = readerStream.ReadToEnd();
            readerStream.Close();
            Console.WriteLine(responseString);

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
