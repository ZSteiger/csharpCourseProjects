using System;
using System.Numerics;
using static System.Console;

namespace WorkingWithNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var largest = ulong.MaxValue;
            // the 40 represents right-align 40 characters, N0 means use thousand separators and zero decimal places
            WriteLine($"{largest,40:N0}");
            var atomsInTheUniverse = BigInteger.Parse("123456789012345678901234567890");
            WriteLine($"{atomsInTheUniverse,40:N0}");
        }
    }
}
