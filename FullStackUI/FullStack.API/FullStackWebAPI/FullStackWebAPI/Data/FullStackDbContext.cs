using FullStackWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackWebAPI.Data
{
    public class FullStackDbContext:DbContext
    {
        public FullStackDbContext(DbContextOptions<FullStackDbContext> Option) : base(Option) { }
        public DbSet<Employee> Employees { get; set; }  
        
    }
}
