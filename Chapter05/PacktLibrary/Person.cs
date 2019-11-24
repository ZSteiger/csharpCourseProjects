﻿using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public partial class Person : object
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();
        // constants
        public const string Species = "Homo Sapien";
        // read-only fields
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        // constructors
        public Person()
        {
            // set default values for fields including readonly fields
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }
        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        // methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }
        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}";
        }

        // tuples
        public (string, int) GetFruit()
        {
            return ("Apples", 5);
        }
        // tuples with named fields
        public (string Name, int Number) GetNamedFruit()
        {
            return (Name: "Apples", Number: 5);
        }

        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }
        public string SayHello(string name)
        {
            return $"{Name} says 'Hello {name}!";
        }

        public string OptionalParameters(
            string command = "Run!",
            double number = 0.0,
            bool active = true)
        {
            return string.Format(
            format: "command is {0}, number is {1}, active is {2}",
            arg0: command, arg1: number, arg2: active);
        }

        public void PassingParameters(int x, ref int y, out int z)
        {
            // out parameters cannot have a default AND must be initialized inside the method
            z = 99;

            // increment each parameter
            x++;
            y++;
            z++;
        }

        // Chapter 06
        // static method to "multiply"
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }
        // instance method to "multiply"
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        // operator to "multiply"
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }

    }
}
