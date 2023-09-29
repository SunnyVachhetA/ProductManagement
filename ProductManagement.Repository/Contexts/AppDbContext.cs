using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.Entities;
using System.Reflection;

namespace ProductManagement.Repository.Contexts;

public class AppDbContext : DbContext
{
    #region Constructor

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    #endregion Constructor

    #region Db Sets

    public virtual DbSet<Product> Products { get; set; }

    #endregion

    #region Override DbContext OnModelCreating & SaveChangesAsync

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Reading all configuratrion file from configuration folder
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #endregion Override DbContext OnModelCreating & SaveChangesAsync
}