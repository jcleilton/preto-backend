using Microsoft.EntityFrameworkCore;

namespace ProcessesAPI.Model
{
    public class CategoriaContext: DbContext
    {
        public CategoriaContext(DbContextOptions<CategoriaContext> opt) : base(opt)
        {

        }

        public DbSet<ProcessesAPI.Model.Categoria> CategoriaObject { get; set; }
    }
}
