using DWD.Shared;
using Microsoft.EntityFrameworkCore;

namespace EF.BasicCrud;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Person>? People { get; }
}