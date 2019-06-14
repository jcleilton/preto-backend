using Microsoft.EntityFrameworkCore;

namespace ProcessesAPI.Model
{
    public class EventoContext: DbContext
    {
        public EventoContext(DbContextOptions<EventoContext> opt) : base(opt)
        {

        }

        public DbSet<Evento> EventoObject { get; set; }
    }
}