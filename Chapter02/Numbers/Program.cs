using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // unsigned integer means positive whole number including 0
            //uint naturalNumber = 23;

            // integer means negative or positive whole number including 0
            //int integerNumber = -23;

            // float means single-precision floating point
            // F suffix makes it a float literal
            //float realNumber = 2.3F;

            // double means double-precision floating point
            //double anotherRealNumber = 2.3; // double literal

            // three variables that store the number 2 million
            //int decimalNotation = 2_000_000;
            //int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
            //int hexadecimalNotation = 0x_001E_8480;

            // check the three variables have the same value
            // both statements output true
            // Console.WriteLine ($"{decimalNotation == binaryNotation}");
            // Console.WriteLine ($"{decimalNotation == hexadecimalNotation}");

            Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}");
            Console.WriteLine($"int uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}");
            Console.WriteLine($"int uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}");

            Console.WriteLine("Using doubles:");

            double a = 0.1;
            double b = 0.2;

            if (a + b == 0.3)
            {
                Console.WriteLine($"{a} + {b} equals 0.3");
            }
            else
            {
                Console.WriteLine($"{a} + {b} does NOT equal 0.3");

            }
            // because they do not equal, only use doubles when accuracy isn't important
            Console.WriteLine("Using doubles:");

            decimal c = 0.1M; // M Suffix means a decimal literal value
            decimal d = 0.2M;

            if (c + d == 0.3M)
            {
                Console.WriteLine($"{a} + {b} equals 0.3");
            }
            else
            {
                Console.WriteLine($"{a} + {b} does NOT equal 0.3");
            }
            // decimals store value as a whole number then shift the decimal position. 29.99 is 2999, move the decimal
            // int for whole numbers, double for real numbers not to be compared, and decimal for money, engineering, anything needing accuracy

        }
    }
}