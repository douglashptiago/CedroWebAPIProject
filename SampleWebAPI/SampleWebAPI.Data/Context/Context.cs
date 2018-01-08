using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWebAPI.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
             : base(options)
        { }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

    }
}
