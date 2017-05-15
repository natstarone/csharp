using System;
using System.Runtime.Remoting.Messaging;
using Utility;
class Program
    {
    static void Main(string[] args)
        {

        int x = Helper.GetInt();

        int y = Helper.GetInt();

        if (x>0)Console.WriteLine("Sum {0}", x + y);
        if (x > 0 & y>0) Console.WriteLine("Sum {0}", x + y);
        if (x>0 && y>0) Console.WriteLine("Sum {0}", x + y);
        if (x > 0) Console.WriteLine("1st not pos");
        else Console.WriteLine("1st not pos");
        if (x > 0) if (y > 0) Console.WriteLine();


    }
}

