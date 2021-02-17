using System.Diagnostics;
using System.IO;

namespace MyBasicServer
{
    internal class Mymethods
    {
        public string MyMethod(string param1, string param2) // methode interne
        {
            return "<HTML><BODY> Hello " + param1 + " et " + param2 + "</BODY></HTML>";
        }

        public string ExternalMethod(string param1, string param2) // methode externe
        {
            //
            // Set up the process with the ProcessStartInfo class.
            // https://www.dotnetperls.com/process
            //
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"D:\Ecole\SI4\S8\SOC\TP\eiin839\TD2\WebDynamic\ExternalMethod\bin\Debug\netcoreapp3.1\ExternalMethod.exe"; // Specify exe name.
            start.Arguments = param1 + " " + param2; // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}