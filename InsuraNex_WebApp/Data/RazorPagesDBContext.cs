using Microsoft.EntityFrameworkCore;
using InsuraNex.Models.Domain;

namespace InsuraNex.Data
{
    public class RazorPagesDBContext : DbContext
    {
        public RazorPagesDBContext(DbContextOptions<RazorPagesDBContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<InsurancePlans> PolicyInformation { get; set; }

    }
}
