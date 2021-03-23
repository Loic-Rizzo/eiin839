using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathsLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class MathsOperations : IMathsOperations
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new Exception("Divise by 0 !");
            }
            else
            {
                return x / y;
            }
        }
    }
}
