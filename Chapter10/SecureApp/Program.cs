﻿using System;
using static System.Console;
using Packt.Shared;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Claims;


namespace SecureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Protector.Register("Alice", "Pa$$word", new[] { "Admins" });
            Protector.Register("Bob", "Pa$$word", new[] { "Sales", "TeamLeads" });
            Protector.Register("Eve", "Pa$$word");
            Write("Enter your username: ");
            string username = ReadLine();
            Write("Enter your password: ");
            string password = ReadLine();

            Protector.LogIn(username, password);
            if (Thread.CurrentPrincipal == null)
            {
                WriteLine("The login failed");
                return;
            }
            var p = Thread.CurrentPrincipal;
            WriteLine(
            $"IsAuthenticated: {p.Identity.IsAuthenticated}");
            WriteLine(
            $"AuthenticationType: {p.Identity.AuthenticationType}");
            WriteLine($"Name: {p.Identity.Name}");
            WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
            WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");
            if (p is ClaimsPrincipal)
            {
                WriteLine(
                $"{p.Identity.Name} has the following claims:");
                foreach (Claim claim in (p as ClaimsPrincipal).Claims)
                {
                    WriteLine($"{claim.Type}: {claim.Value}");
                }
            }

        }
    }
}
