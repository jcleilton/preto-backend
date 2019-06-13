using Microsoft.EntityFrameworkCore;
using ProcessesAPI.Models;

namespace ProcessesAPI.Model
{
    public class FaixaContext: DbContext
    {
        public FaixaContext(DbContextOptions<FaixaContext> opt) : base(opt)
        {

        }

        public DbSet<Faixa> FaixaObject { get; set; }
    }
}