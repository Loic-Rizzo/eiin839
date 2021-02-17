
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace MyBasicServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //if HttpListener is not supported by the Framework
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }


            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();

            // get args 
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            // Trap Ctrl-C on console to exit 
            Console.CancelKeyPress += delegate {
                // call methods to close socket and exit
                listener.Stop();
                listener.Close();
                Environment.Exit(0);
            };


            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }

                GetUrlInfo(request);

                //get params un url. After ? and between &

                GetUrlParam(request);

                //
                Console.WriteLine(documentContents);

                object[] requestParam = new object[2];
                requestParam[0] = HttpUtility.ParseQueryString(request.Url.Query).Get("param1");
                requestParam[1] = HttpUtility.ParseQueryString(request.Url.Query).Get("param2");


                // exemple d'url : http://localhost:8081/mardi/aprem/MyMethod?param1=Cindy&param2=Loic
                // http://localhost:8080/mardi/aprem/ExternalMethod?param1=Loic&param2=Cindy

                string result = "";

                Type type = typeof(Mymethods); //récupération de la Class
                MethodInfo method = type.GetMethod(request.Url.Segments[request.Url.Segments.Length - 1]); //récupération de la la method
                if (method != null)
                {
                    Mymethods c = new Mymethods();
                    result = (string)method.Invoke(c, requestParam);
                    Console.WriteLine(result);
                }

                ConstructAndWriteResponse(context, result);
            }
            // Httplistener neither stop ... But Ctrl-C do that ...
            // listener.Stop();
        }

        private static void GetUrlParam(HttpListenerRequest request)
        {
            Console.WriteLine(request.Url.Query);

            //parse params in url
            Console.WriteLine("param1 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param1"));
            Console.WriteLine("param2 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param2"));
            Console.WriteLine("param3 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param3"));
            Console.WriteLine("param4 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param4"));
        }

        private static void GetUrlInfo(HttpListenerRequest request)
        {
            // get url 
            Console.WriteLine($"Received request for {request.Url}");

            //get url protocol
            Console.WriteLine(request.Url.Scheme);
            //get user in url
            Console.WriteLine(request.Url.UserInfo);
            //get host in url
            Console.WriteLine(request.Url.Host);
            //get port in url
            Console.WriteLine(request.Url.Port);
            //get path in url 
            Console.WriteLine(request.Url.LocalPath);

            // parse path in url 
            foreach (string str in request.Url.Segments)
            {
                Console.WriteLine(str);
            }
        }

        private static void ConstructAndWriteResponse(HttpListenerContext context, string result)
        {
            // Obtain a response object.
            HttpListenerResponse response = context.Response;

            // Construct a response.
            string responseString = result;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
        }
    }
}