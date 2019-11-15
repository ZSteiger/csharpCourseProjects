// #nullable enable
// #nullable disable // Enables || disables at file level

using System;

namespace NullHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // int thisCannotBeNull = 4;
            // thisCannotBeNull = null; compile error!

            int? thisCouldBeNull = null;
            Console.WriteLine(thisCouldBeNull); // prints blank line because value is null
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

            thisCouldBeNull = 7;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

        }
    }
}
