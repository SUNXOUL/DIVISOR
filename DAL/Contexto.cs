using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Divisor.Models;

namespace Divisor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Team>? Teams { get; set; }
        public Contexto(DbContextOptions<Contexto> Options) : base(Options) { }
    }
}