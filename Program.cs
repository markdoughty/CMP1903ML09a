using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMP1903ML09a
{
    //declare a delegate
    public delegate void Output(int value);

    class Program
    {
        static void Main(string[] args)
        {
            //Point the delegate at OutputNumber method
            Output handler = OutputNumber;
            //Call the OutputNumber method through the delegate
            handler(100);

            //Change the method the delgate points to to OutputMoney
            handler = OutputMoney;
            //Call the OutputMoney method through the delegate
            handler(100);

            //Use delegates to call method from different class
            handler = Print.OutputNumber;
            handler(300);

            //Pass delegate as a method parameter
            //The method for the delegate to point to is included
            OutputHelper(Print.OutputNumber, 400);

            Console.WriteLine("*******************");
            Console.WriteLine("Multicast delegate");

            handler = OutputNumber;
            handler += OutputMoney;
            handler(40);

            handler -= OutputNumber;
            handler(60);


        }

        public static void OutputNumber(int value)
        {
            Console.WriteLine($"Number: {value}");
        }
        public static void OutputMoney(int value)
        {
            Console.WriteLine("Amount: {0:C}", value);
        }

        //passing the delegate as a method parameter
        public static void OutputHelper(Output delegateMethod, int value)
        {
            delegateMethod(value);
        }
    }
}

