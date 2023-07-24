using Microsoft.EntityFrameworkCore;
using WebApiFroms.Model;

namespace WebApiFroms.Database
{
    public class FormsDbContext : DbContext
    {
        public FormsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<FormModel> forms { get; set; }
    }
}
