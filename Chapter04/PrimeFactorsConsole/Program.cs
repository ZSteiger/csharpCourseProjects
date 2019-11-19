using System;
using static System.Console;

namespace PrimeFactorsConsole
{
    public class PrimeFactors
    {
        public static string primeFactors(int n)
        {
            // print out the number of 2s that divide n
            while (n % 2 == 0)
            {
                Write(2 + " ");
                n /= 2;
            }
            // n must be odd at this point so we can skip one element
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                // while i divides n, print i and divide n
                while (n % i == 0)
                {
                    Write(i + " ");
                    n /= i;
                }
            }
            if (n > 2)
            {
                Write(n);
            }
            return n.ToString();
        }
    }
    class Program
    {
        /* 4.1 Question / Answers
        1. What does void mean? A: The method does not return a value
        2. How many parameters can a method have? A: "The moment readability suffers, it has too many" Generally, 3-4 is the max. Any more than that and the method might have too many responsibilities. 
        3. In VSCode, what is the difference between pressing F5, Ctrl+F5, and Ctrl+Shift+F5? A: F5 starts debugging, Ctrl+F5 starts without debugging, ctrl+shift+f5 stops debugging
        4. Where does Trace.WriteLine method write its output to? A: To the TraceListener, such as DefaultTraceListener, or TextWriterTraceListener which can write to a file after buffering
        5. What are the five trace levels? A: 0, or Off, This will output nothing. 1, or Error, This will output only errors. 2, or Warning, This will output errors and warnings. 3, or Info, This will output errors, warnings, and information. 4, or Verbose, This will output all levels
        6. What is the difference between debug and trace? A: Debug is used to add logging that gets written during development, Trace is used to add logging in both development and runtime
        7. When writing a unit test, what are the three A's? A: Arrange, or declare and instantiate variables for IO. Act, meaning execute the unit that you are testing. Assert, Make some assertions about the output, things you know must be write to pass; if the assertion is not true, the test has failed.
        8. When writing a unit test with xUnit, what attribute must you decorate the test methods with? A: [Fact], to declare that this test should evaluate to true
        9. What dotnet command executes xUnit tests? A: dotnet test
        10. What is TDD? A: Test driven development, or the process of writing tests before your code to ensure maximum code quality
         */

        static void Main(string[] args)
        {
            WriteLine("Enter a number to find its prime factors: ");
            int n;
            string input = ReadLine();
            if (int.TryParse(input, out n))
            {
                PrimeFactors.primeFactors(n);
            }
            else
            {
                WriteLine("I could not parse the input.");
            }

        }
    }
}
