using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using daw.Data;

namespace daw {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            var sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");

            MySql.Data.MySqlClient.MySqlConnection conn;

            try {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = sqlConnectionString;
                conn.Open();
            } catch (MySql.Data.MySqlClient.MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

            services.AddDbContext < MyContext > (options =>
                options.UseMySQL(sqlConnectionString));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}