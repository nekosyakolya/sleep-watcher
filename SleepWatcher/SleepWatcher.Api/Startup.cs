using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SleepWatcher.Data.Context;
using SleepWatcher.Data.Repositories;
using SleepWatcher.Core.Interfaces;
using SleepWatcher.Core.Services;
using Microsoft.EntityFrameworkCore;
using SleepWatcher.Core.Entities.Common;

namespace SleepWatcher.Api
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


            services.AddDbContext<SleepWatcherContext>(options =>
                                options.UseSqlServer(
                                    Configuration.GetConnectionString("DefaultConnection"),
                                    b => b.MigrationsAssembly("SleepWatcher.Data")),
                                ServiceLifetime.Transient,
                                ServiceLifetime.Singleton)

                    .AddSingleton<Func<SleepWatcherContext>>(srv => () => srv.GetService<SleepWatcherContext>())
                    .AddTransient<IUserService, UserService>()
                    .AddSingleton<Func<UserService>>(x => () => x.GetService<UserService>())
                    .AddSingleton<IRepositoryFactory<IUserRepository>, RepositoryFactory>()
                    .AddTransient<IUsersToSleepService, UsersToSleepService>()
                    .AddSingleton<Func<UsersToSleepService>>(x => () => x.GetService<UsersToSleepService>())
                    .AddSingleton<IRepositoryFactory<IUsersToSleepRepository>, RepositoryFactory>()
                    
                    
                    .AddTransient<ISender>(s => new VkSender(Configuration["Tokens:VkMessageToken"]))
                    .AddTransient<IResponseHandler, VkResponseHandler>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
