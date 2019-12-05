using System;
using System.Xml.Linq;
using static System.Console;
using Packt.Shared;
using DialectSoftware.Collections;
using DialectSoftware.Collections.Generics;

namespace AssembliesAndNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            /* var doc = new XDocument();
            string s1 = "Hello";
            string s2 = "World"; */
            // Part 2
            /* Write("Enter a color value in hex: ");
            string hex = ReadLine();
            WriteLine("Is {0} a valid color value? {1}",
            arg0: hex, arg1: hex.IsValidHex());
            Write("Enter a XML tag: ");
            string xmlTag = ReadLine();
            WriteLine("Is {0} a valid XML tag? {1}",
            arg0: xmlTag, arg1: xmlTag.IsValidXmlTag());
            Write("Enter a password: ");
            string password = ReadLine();
            WriteLine("Is {0} a valid password? {1}",
            arg0: password, arg1: password.IsValidPassword()); */

            // Part 3
            var x = new Axis("x", 0, 10, 1);
            var y = new Axis("y", 0, 4, 1);
            var matrix = new Matrix<long>(new[] { x, y });
            for (int i = 0; i < matrix.Axes[0].Points.Length; i++)
            {
                matrix.Axes[0].Points[i].Label = "x" + i.ToString();
            }
            for (int i = 0; i < matrix.Axes[1].Points.Length; i++)
            {
                matrix.Axes[1].Points[i].Label = "y" + i.ToString();
            }
            foreach (long[] c in matrix)
            {
                matrix[c] = c[0] + c[1];
            }
            foreach (long[] c in matrix)
            {
                WriteLine("{0},{1} ({2},{3}) = {4}",
                matrix.Axes[0].Points[c[0]].Label,
                matrix.Axes[1].Points[c[1]].Label,
                c[0], c[1], matrix[c]);
            }

        }
    }
}

/*
------- Exercise 7.1 -------
1. What is the difference between a namespace and an assembly?
Assemblies are where the type is stored, a namespace is the address of that type.

2. How do you reference another project in a .csproj file? A: In the ItemGroup tag, add a PackageReference tag then the name of the package in the Include property

3. What is the difference between a package and a metapackage? Give an
example of each. A: A package is a single assembly of the same name, i.e. System.Collections, which contains the System.Collections.dll assembly. A metapackage can be a package that installs a series of packages or boilerplate for a project depending on the needs of the project

4. Which .NET type does the C# float alias represent? System.Single

5. What is the difference between the packages named NETStandard.Library
and Microsoft.NETCore.App? A: The NETStandard library is a collection of .NET APIs that are prescribed to be used and supported together, the NETCore.App is a set of APIs included in the .NET Core Application Model

6. What is the difference between framework-dependent and self-contained
deployments of .NET Core applications? A: Framework dependent might require some additional dependencies to be installed for the application to work, where as a self-contained application will have a large folder size, but is gauranteed to work. 

7. What is a RID? A: A Runtime Identifier identifies the target platforms in which the application runs.

8. What is the difference between the dotnet pack and dotnet publish
commands? A: pack creates a NuGet package for the project, while publish compiles then publishes the project either with dependencies or as a self-contained application

9. What types of applications written for the .NET Framework can be ported to
.NET Core? A: ASP.NET Core MVC, ... Core Web API services, Console applications, Windows forms, windows presentation foundation, and Universal Windows Platform

10. Can you use packages written for .NET Framework with .NET Core? A: Sometimes, though the compiler might through warnings, the code can still work in certain cases. 
*/
