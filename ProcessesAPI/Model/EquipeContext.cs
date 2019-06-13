using Microsoft.EntityFrameworkCore;
using ProcessesAPI.Models;

namespace ProcessesAPI.Model
{
    public class EquipeContext: DbContext
    {
        public EquipeContext(DbContextOptions<EquipeContext> opt) : base(opt)
        {

        }

        public DbSet<Equipe> EquipeObject { get; set; }
    }
}