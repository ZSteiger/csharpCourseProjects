using System;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // What happens when you divide int by 0?
            double a = 1;
            double b = 0;
            Console.WriteLine($"{a / b}");
            // System.DivideByZero exception
            // What happens when you divide a double by 0?
            // You receive an 'infinity' symbol
            // What happens when you set an int variable beyond its range?
            // It starts at the beginning of int, or the negative minimum value
            // What's the difference between x = y++ and x = ++y? Postfix, prefix operators, when to increment during runtime
            // Break - Break out and end the loops, Continue - Continue iterating through the next statement, Return - return to the beginning of the loops
            // 3 parts of a for loops, which are required? Initializer, Conditional, iterator, only the intializer and the conditional
            // = : assignment operator, == : comparison operator
            // Does the following statement compile?
            //for (; true;) ; // compiles but never breaks, always true
            // Underscore represents default in a switch expression
            // What interface must an object implement in order to be enumerated over by using a foreach statement? Ienumerable

            // this code goes bananas without the checked block, answer to 3.2
            // try
            // {
            //     checked
            //     {

            //         int max = 500;
            //         for (byte i = 0; i < max; i++)
            //         {
            //             Console.WriteLine(i);
            //         }
            //     }
            // }
            // catch (System.Exception)
            // {

            //     throw;
            // }
            // 3.3
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {

                    Console.WriteLine(i);
                }
            }

            // Exercise 4
            Console.WriteLine("Enter a number between 0 and 255");
            string input1 = Console.ReadLine();
            Console.WriteLine("Enter a number between 0 and 255");
            string input2 = Console.ReadLine();
            try
            {
                byte c = byte.Parse(input1);
                byte d = byte.Parse(input2);
                var answer = c / d;
                Console.WriteLine($"{c} divided by {d} is {answer}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
            }
        }


    }
}
