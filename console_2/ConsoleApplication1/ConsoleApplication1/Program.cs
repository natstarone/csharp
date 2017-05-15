using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Sharp
    {
        static void Main(string[] args)
        {

       
        
        
        // String c = Console.ReadLine();
        // Console.WriteLine("Welcome to C sharp {0} {1:c2}" ,c,400000);

        Console.Write("Enter a real number ");
        String  s = Console.ReadLine();
        float x = Convert.ToSingle(s);
        
        // decimal x = Convert.ToDecimal(s); // float x = Convert.ToSingle(s); //int x = Convert.ToInt32(s);

        Console.Write("Enter another real number ");
        s = Console.ReadLine();
        float y = Convert.ToSingle(s);
        
        // decimal y = Convert.ToDecimal(s); // float y = Convert.ToSingle(s);//int y = Convert.ToInt32(s);


        Console.WriteLine("Sum:{0,10:f2}", x + y); //f indicates basic number no dollar sign or decimal
        Console.WriteLine("Difference:{0,10:f2}", x - y);
        Console.WriteLine("Product:{0,10:f2}", x * y);
        Console.WriteLine("Divison:{0,10:f2}", x / y);
        Console.WriteLine("Modulus:{0,10:f2}", x % y);



        Console.Write("Enter a decimal ");
        String o = Console.ReadLine();
        decimal l = Convert.ToDecimal(o);

        // decimal x = Convert.ToDecimal(s); // float x = Convert.ToSingle(s); //int x = Convert.ToInt32(s);

        Console.Write("Enter another decimal ");
        o = Console.ReadLine();
        decimal k = Convert.ToDecimal(o);




        Console.WriteLine("Sum:{0,10:c2}", l + k); 
        Console.WriteLine("Difference:{0,10:c2}", l - k);
        Console.WriteLine("Product:{0,10:c2}", l * k);
        Console.WriteLine("Divison:{0,10:c2}", l / k);
        Console.WriteLine("Modulus:{0,10:c2}", l % k);

    }
    }

