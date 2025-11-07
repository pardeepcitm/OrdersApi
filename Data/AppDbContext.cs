using Microsoft.EntityFrameworkCore;

namespace OrdersApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Product> Products { get; set; }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}