using Microsoft.EntityFrameworkCore;

namespace AspDotNetCore_Pagination.Models
{
    public class DBCtx : DbContext
    {
        public DBCtx(DbContextOptions<DBCtx> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
