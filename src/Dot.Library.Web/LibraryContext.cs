using Dot.Library.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Web
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<BookReservation> BookReservation { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Author> Author { get; set; }


        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
    }
}
