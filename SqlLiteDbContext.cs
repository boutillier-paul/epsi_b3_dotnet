using Microsoft.EntityFrameworkCore;

public class SqlLiteDbContext : DbContext
{
    public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options)
        : base(options)
    {
    }

    public DbSet<Commande> Commandes { get; set; }
    public DbSet<Plat> Plats { get; set; }
}
