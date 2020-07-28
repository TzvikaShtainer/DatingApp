using DatingApp.API.Controllers.Models;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){} //קונסטרקטור

        public DbSet<Value> Values { get; set; } // משתנה לדאטא של ווליוז
        public DbSet<User> Users { get; set; }
    }
}