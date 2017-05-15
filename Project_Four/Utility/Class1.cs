using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class IO
    {
        public static decimal GetDecimal()

        {
            Console.WriteLine("\nEnter decimal number \n");
            return Convert.ToDecimal(Console.ReadLine());

        }
        
        public static float GetRealNum()
        {
            Console.WriteLine("\nEnter a real number");
            return Convert.ToSingle(Console.ReadLine());
        }
    }
}
