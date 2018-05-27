using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Application;
using TicketManagement.Application.Infrastructure;
using TicketManagement.Domain.Event;
using TicketManagement.Infrastructure.Db;
using TicketManagement.Infrastructure.EventDispatching;

namespace TicketManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("TicketManagementDbContext");

            services.AddDbContext<TicketManagementDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<InternalDomainEventDispatcher>(x => new InternalDomainEventDispatcher(services.BuildServiceProvider(),
                typeof(Event).Assembly, typeof(OrderEventHandlers).Assembly));
            services.AddScoped<CommandExecutor, CommandExecutor>();
            services.AddScoped<QueryExecutor, QueryExecutor>();
            services.AddScoped<UnitOfWork, UnitOfWork>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
