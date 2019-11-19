using System;
using Xunit;
using PrimeFactorsConsole;

namespace PrimeFactorsUnitTests
{
    public class PrimeFactorsUnitTests
    {
        [Fact]
        public void Test()
        {
            // arrange
            int n = 315;
            string expected = "7";
            // act
            string output = PrimeFactors.primeFactors(n);
            // assert
            Console.WriteLine(output);
            Assert.Equal(expected, output);
        }
        [Fact]
        public void TestErrors()
        {
            // arrange
            int n = int.Parse("asdf");
            string expected = "I could not parse the input.";
            // act
            string output = PrimeFactors.primeFactors(n);
            // assert
            Console.WriteLine(output);
            Assert.Equal(expected, output);
        }
    }
}
