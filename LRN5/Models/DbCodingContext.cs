using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LRN5.Models
{
    public class DbCodingContext : DbContext
    {
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Method> Methods { get; set; }
        public virtual DbSet<FunctionArgument> FunctionArguments { get; set; }
        public virtual DbSet<MethodArgument> MethodArguments { get; set; }

        public DbCodingContext(DbContextOptions<DbCodingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
