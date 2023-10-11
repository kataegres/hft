using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDB
{
    class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=|DataDirectory|\books.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book("1", "Rowling, J.K.", "Harry Potter and the Philosopher's Stone", "Fantasy", 4.65, "1994-06-24", "asdasd"),
                new Book("2", "Tolkien, J. R. R.", "Lord of the Rings", "Fantasy", 11.39, "1954-07-29", "asdasd"),
                new Book("3", "Hoover, Colleen", "It Ends with Us", "Romance", 1.65, "2018-05-21", "asdasd")
            });
        }

    }
}
