using Microsoft.EntityFrameworkCore;
using Saitynai.API.Models;

namespace Saitynai.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<AppUser> Users{ get; set; }
    }
}