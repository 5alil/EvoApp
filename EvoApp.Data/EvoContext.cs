using EvoApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvoApp.Data
{
    public class EvoContext : DbContext
    {
        public EvoContext(DbContextOptions<EvoContext> options) : base(options)
        {

        }
        public DbSet<Evo> Evos { get; set; }

    }
}
