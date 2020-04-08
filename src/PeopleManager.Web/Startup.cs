using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeopleManager.Data;
using PeopleManager.Web.ControllerLogic;
using PeopleManager.Web.Controllers;
using PeopleManager.Web.Data;

namespace PeopleManager.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ManagementContext>(oa =>
                oa.UseSqlServer(Configuration.GetConnectionString("ManagementDatabase")));
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IAddPersonControllerLogic, AddPersonControllerLogic>();
            services.AddScoped<ISearchControllerLogic, SearchControllerLogic>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AddPerson}/{action=Index}");
            });
        }
    }
}
