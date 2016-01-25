﻿using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace ConsoloBooks.Models
{
    //dev/qa/uat only
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Book.Any())
            {
                var austen = context.Author.Add(
                    new Author { LastName = "Austen", FirstName = "Jane" }).Entity;
                var dickens = context.Author.Add(
                    new Author { LastName = "Dickens", FirstName = "Charles" }).Entity;
                var cervantes = context.Author.Add(
                    new Author { LastName = "Cervantes", FirstName = "Miguel" }).Entity;

                context.Book.AddRange(
                    new Book()
                    {
                        Title = "Pride and Prejudice",
                        Year = 1813,
                        Author = austen,
                        Price = 9.99M,
                        Genre = "Comedy of manners"
                    },
                    new Book()
                    {
                        Title = "Northanger Abbey",
                        Year = 1817,
                        Author = austen,
                        Price = 12.95M,
                        Genre = "Gothic parody"
                    },
                    new Book()
                    {
                        Title = "David Copperfield",
                        Year = 1850,
                        Author = dickens,
                        Price = 15,
                        Genre = "Bildungsroman"
                    },
                    new Book()
                    {
                        Title = "Don Quixote",
                        Year = 1617,
                        Author = cervantes,
                        Price = 8.95M,
                        Genre = "Picaresque"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
