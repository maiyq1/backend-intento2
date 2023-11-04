using Data.Model;

namespace Data.DbContext;
using Microsoft.EntityFrameworkCore;

public class DatabaseDBContext : DbContext
{
     //This is by default, just put it :u
    public DatabaseDBContext()
    {
    }
    
    public DatabaseDBContext(DbContextOptions<DatabaseDBContext> options) : base(options)
    {
    }
    
    //To manipulate our tables from everywhere
    public DbSet<User> Users { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    
    //To connect to MySql
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //Version of MySql and required data to connect to the database
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=Admin180403@.;Database=databasedb;",serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("users");

        builder.Entity<User>().HasKey(p => p.Id);

        builder.Entity<User>().Property(p => p.username).IsRequired();
        builder.Entity<User>().Property(p => p.username).HasMaxLength(60);
        
        builder.Entity<User>().Property(p => p.password).IsRequired();
        builder.Entity<User>().Property(p => p.password).HasMaxLength(60);
        builder.Entity<User>().Property(p => p.isActive).HasDefaultValue(true);

        builder.Entity<Supplier>().ToTable("suppliers");
        builder.Entity<Supplier>().HasKey(p => p.Id);
        builder.Entity<Supplier>().Property(p => p.firstName).IsRequired();
        builder.Entity<Supplier>().Property(p => p.firstName).HasMaxLength(60);
        builder.Entity<Supplier>().Property(p => p.lastName).IsRequired();
        builder.Entity<Supplier>().Property(p => p.lastName).HasMaxLength(60);
        builder.Entity<Supplier>().Property(p => p.address).HasMaxLength(60);
        builder.Entity<Supplier>().Property(p => p.phone).HasMaxLength(9);
        builder.Entity<Supplier>().Property(p => p.email).HasMaxLength(60);
        builder.Entity<Supplier>().Property(p => p.businessName).HasMaxLength(60);
        builder.Entity<Supplier>().Property(p => p.users_id).IsRequired();

    }
}