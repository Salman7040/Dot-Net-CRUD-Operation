using CRUD_Opration.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Opration.Data
{
    public class ApplicationDbContext : DbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 

        }

        public DbSet<Student> Students{ get; set; }        
    }
}
