using E_commAPI.models;

namespace E_commAPI.Database.Context;

using Microsoft.EntityFrameworkCore;

public sealed class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}