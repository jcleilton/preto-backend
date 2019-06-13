using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessesAPI.Model;
using ProcessesAPI.Models;

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
            services.AddDbContext<MachineContext>(options =>
                options.UseMySql(connection));
            services.AddDbContext<ProcessContext>(options =>
                options.UseMySql(connection));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseMvc();
        }
    }
}
