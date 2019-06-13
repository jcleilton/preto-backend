using Microsoft.EntityFrameworkCore;
using ProcessesAPI.Models;

namespace ProcessesAPI.Model
{
    public class CompetidorContext: DbContext
    {
        public CompetidorContext(DbContextOptions<CompetidorContext> opt) : base(opt)
        {

        }

        public DbSet<Competidor> CompetidorObject { get; set; }
    }
}