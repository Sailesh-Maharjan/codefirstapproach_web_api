using codefirst_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace codefirst_web_api.Repository // In next practise make this class in Models 
{
    public class studentDbContext : DbContext
    {
        public studentDbContext(DbContextOptions<studentDbContext> option) : base(option)
        { }


        public DbSet<student> students { get; set; }
    }
}
