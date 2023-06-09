using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_Core_Sithec.Seeds;
using Test_Core_Sithec.Services;

namespace Test_Core_Sithec.Models;

public partial class HumanContext : DbContext
{
    public HumanContext(DbContextOptions<HumanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Human> Humans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("AppDb");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HumanConfiguration());
    }
}
