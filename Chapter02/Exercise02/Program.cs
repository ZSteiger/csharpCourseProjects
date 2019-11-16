using System;
using static System.Console;

namespace Exercise02 {
    class Program {
        static void Main (string[] args) {
            /*
                Which type would you choose for the following numbers?
                1. Telephone number : String
                2. Height : Double
                3. Age : uint
                4. Salary : Decimal
                5. Book ISBN : string
                6. Price : Decimal
                7. Weight : String
                8. Population : int
                9. Stars in the universe : long
                10. Employees in a small-mid sized business : uint
            */
            // WriteLine ($"int uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}");
            WriteLine ("--------");
            WriteLine ("{0, -20} {1, -8} {2, 12} {3, 20}", "Type", "Byte(s) of memory", "Min", "Max");
            WriteLine ("--------");
            WriteLine ($"sbyte {sizeof(sbyte), -8} {sbyte.MinValue, 12} {sbyte.MaxValue,20}");
            WriteLine ($"byte {sizeof(byte), -8} {byte.MinValue, 12} {byte.MaxValue,20}");
            WriteLine ($"short {sizeof(short), -8} {short.MinValue, 12} {short.MaxValue,20}");
            WriteLine ($"ushort {sizeof(ushort), -8} {ushort.MinValue, 12} {ushort.MaxValue,20}");
            WriteLine ($"int {sizeof(int), -8} {int.MinValue, 12} {int.MaxValue,20}");
            WriteLine ($"uint {sizeof(uint), -8} {uint.MinValue, 12} {uint.MaxValue,20}");
            WriteLine ($"long {sizeof(long), -8} {long.MinValue, 12} {long.MaxValue,20}");
            WriteLine ($"ulong {sizeof(ulong), -8} {ulong.MinValue, 12} {ulong.MaxValue,20}");
            WriteLine ($"float {sizeof(float), -8} {float.MinValue, 12} {float.MaxValue,20}");
            WriteLine ($"double {sizeof(double), -8} {double.MinValue, 12} {double.MaxValue,20}");
            WriteLine ($"decimal {sizeof(decimal), -8} {decimal.MinValue, 12} {decimal.MaxValue,20}");
        }

    }
}