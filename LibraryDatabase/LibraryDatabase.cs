using System;
using System.Collections.Generic;
using System.Text;
using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryDatabase
{
    public class LibraryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Book> Books { set; get; }
        public virtual DbSet<BookGenre> Genres { set; get; }
    }
}
