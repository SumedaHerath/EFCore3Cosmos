using Microsoft.EntityFrameworkCore;

namespace EFCore3Cosmos
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
             "https://q-test-document.documents.azure.com:443",
             "Sc0SEZIF4uANZMOCxVo9XayoEdAHl5M2vnwM6e9BpRiAiaEqTQPVk08YZprB6PxpJK7wwwGq838Mri7exaZbYw==",
             "q-test-document");
        }
    }
}
