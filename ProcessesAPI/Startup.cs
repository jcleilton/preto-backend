using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessesAPI.Model;

namespace ProcessesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
            services.AddDbContext<CategoriaContext>(options =>
                options.UseMySql(connection));
            services.AddDbContext<CompetidorContext>(options =>
                options.UseMySql(connection));
            services.AddDbContext<EquipeContext>(options =>
                options.UseMySql(connection));
            services.AddDbContext<EventoContext>(options =>
                options.UseMySql(connection));
            services.AddDbContext<FaixaContext>(options =>
                options.UseMySql(connection));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseMvc();
        }
    }
}
