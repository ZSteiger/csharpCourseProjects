﻿using System;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WorkingWithEFCore
{
    class Program
    {
        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have:");
                // a query to get all categories and their related products
                IQueryable<Category> cats = db.Categories
                    .Include(c => c.Products);
                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }
        static void Main(string[] args)
        {
            QueryingCategories();
        }
    }
}