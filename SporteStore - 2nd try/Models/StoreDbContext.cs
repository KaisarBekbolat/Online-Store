using System;
using Microsoft.EntityFrameworkCore;

namespace SporteStore___2nd_try.Models;

public class StoreDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {}
    public StoreDbContext(){}
}
