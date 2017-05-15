using System;
using Utility; 


class Program
    {
    
        static void Main(string[] args)
        {

        decimal x = IO.GetDecimal();
        decimal y = IO.GetDecimal();

        if (x > 0 && y > 0)
        {
            Console.WriteLine(String.Format("Sum :{0, 7:c2}", x + y));
        }
        
        float xx = IO.GetRealNum();
        float yy = IO.GetRealNum();

        if (xx > 0 || yy > 0)
        {
            Console.WriteLine(String.Format("\n Product: {0, 7:f2}\n", xx * yy));
        }

        else if (xx < 0 && yy < 0)
        {
            Console.WriteLine(String.Format("\n Quotient: {0, 7:f2} \n ", xx / yy));
        }

     }
  }






/*int x = IO.GetInt();
     int y = IO.GetInt();
     Console.WriteLine("Sum:{0}", x + y);*/
