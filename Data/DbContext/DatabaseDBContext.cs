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
    
    //To connect to MySql
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //Version of MySql and required data to connect to the database
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=Admin180403@.;Database=LearningCenterDB;",serverVersion);
        }
    }


    //To create the tables according our classes
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}