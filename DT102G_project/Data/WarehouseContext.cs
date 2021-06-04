using System;
using DT102G_project.Models;
using Microsoft.EntityFrameworkCore;

namespace DT102G_Moment_3_2.Data
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
