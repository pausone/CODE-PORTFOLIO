using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearningTool.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<QuestionAndAnswer> QuestionAndAnswers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}