﻿using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.Models.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>opts):base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasOne(a => a.studentAddress)
                .WithOne(a => a.Student)
                .HasForeignKey<StudentAddress>(a => a.StudentId);
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get;set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<StudentAddress> StudentAddress {  get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Book> Book { get; set; }
    }
}
