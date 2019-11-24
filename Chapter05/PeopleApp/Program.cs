using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatusOfZeusAtOlympia;
            var alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };

            WriteLine(format: "{0} was born on {1: dddd, d MMMM yyyy}",
            arg0: bob.Name,
            arg1: bob.DateOfBirth);

            WriteLine(format: "{0} was born on {1:dd MMM yy}", arg0: alice.Name,
            arg1: alice.DateOfBirth);
            WriteLine(format: "{0}'s favorite wonder is {1}. Its integer is {2}.", arg0: bob.Name, arg1: bob.FavoriteAncientWonder, arg2: (int)bob.FavoriteAncientWonder);

            bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            // Another option is to set the value by casting 18 to the enum type, but this is more difficult to read
            // bob.BucketList = (WondersOfTheAncientWorld)18;
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            bob.Children.Add(new Person { Name = "Alfred" });
            bob.Children.Add(new Person { Name = "Zoe" });
            WriteLine($"{bob.Name} has {bob.Children.Count} children:");
            for (int child = 0; child < bob.Children.Count; child++)
            {
                WriteLine($"{bob.Children[child].Name}");
            }
            // as a bonus, use a foreach statement
            foreach (var children in bob.Children)
            {
                WriteLine($"{children.Name}");
            }

            BankAccount.InterestRate = 0.012M; // store a shared value
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;

            WriteLine(format: "{0} earned {1:C} interest.", arg0: jonesAccount.AccountName, arg1: jonesAccount.Balance * BankAccount.InterestRate);
            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;

            WriteLine(format: "{0} earned {1:C} interest", arg0: gerrierAccount.AccountName, arg1: gerrierAccount.Balance * BankAccount.InterestRate);
            WriteLine($"{bob.Name} is a {Person.Species}");
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");
            var blankPerson = new Person();
            WriteLine(format:
            "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: blankPerson.Name,
            arg1: blankPerson.HomePlanet,
            arg2: blankPerson.Instantiated);

            var gunny = new Person("Gunny", "Mars");
            WriteLine(format:
            "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: gunny.Name,
            arg1: gunny.HomePlanet,
            arg2: gunny.Instantiated);

            // methods
            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());

            // using tuples
            (string, int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are");

            // named tuples
            var fruitNamed = bob.GetNamedFruit();
            WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");
            var thing1 = ("Neville", 4);

            // inferring tuple names
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
            var thing2 = (bob.Name, bob.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count} children.");

            // deconstructed
            (string fruitName, int fruitNumber) = bob.GetFruit();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

            // passing parameters to methods + overloading methods
            WriteLine(bob.SayHello());
            WriteLine(bob.SayHello("Emily"));

            // optional parameters
            WriteLine(bob.OptionalParameters());
            // inferred by position
            WriteLine(bob.OptionalParameters("Jump!", 98.5));
            // select using named params
            WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));
            // use named parameters to skip over optional params
            WriteLine(bob.OptionalParameters("Poke!", active: false));

            // controlling how parameters are passed
            int a = 10;
            int b = 20;
            int c = 30;

            WriteLine($"Before a = {a}, b = {b}, c = {c}");
            bob.PassingParameters(a, ref b, out c);
            WriteLine($"After: a = {a}, {b} = b, c = {c}");
            int d = 10;
            int e = 20;
            WriteLine($"Before d = {d}, e = {e}, f doesn't exist yet!");
            // simplified C# 7.0 syntax for out parameter
            bob.PassingParameters(d, ref e, out int f);
            WriteLine($"After: d = {d}, e = {e}, f = {f}");
            var sam = new Person
            {
                Name = "Sam",
                DateOfBirth = new DateTime(1972, 1, 27)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);
            sam.FavoriteIceCream = "Chocolate Fudge";
            WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
            sam.FavoritePrimaryColor = "Red";
            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

        }
    }
}
