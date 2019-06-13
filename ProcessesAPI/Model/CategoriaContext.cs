using Microsoft.EntityFrameworkCore;
using ProcessesAPI.Models;

namespace ProcessesAPI.Model
{
    public class CategoriaContext: DbContext
    {
        public CategoriaContext(DbContextOptions<CategoriaContext> opt) : base(opt)
        {

        }

        public DbSet<Categoria> CategoriaObject { get; set; }
    }
}
