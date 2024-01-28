using Microsoft.EntityFrameworkCore;
using StudyProject.Data.Models;

namespace StudyProject.Data
{
    public class KubernetesListingDbContext : DbContext
    {
        public KubernetesListingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<KubeConfigFile> KubeConfigFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
