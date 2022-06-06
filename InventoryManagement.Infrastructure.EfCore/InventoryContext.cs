﻿using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EfCore
{
    public class InventoryContext :DbContext
    {
        public DbSet<Inventory > Inventotry { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}