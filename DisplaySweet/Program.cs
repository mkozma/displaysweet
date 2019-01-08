using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisplaySweet
{
    public class Navigation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Index { get; set; }
        public Guid ComponentId { get; set; }
        public virtual Component Components { get; set; }
        public string Type { get; set; }

    }

    public class Component
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public ICollection<object> Data { get; set; }
    }

    public class DisplaySweetDbContext : DbContext
    {
        public DbSet<Component> Components { get; set; }
        public DbSet<Navigation> Navigations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=DisplaySweet;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>()
                .Ignore(t => t.Data);


                
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
