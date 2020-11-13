using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SubProject.DataServices;
using SubProject.Middleware;

namespace SubProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ITitleBasicsDS, TitleBasicsDS>();
            services.AddSingleton<ISearchDS, SearchDS>();
            services.AddSingleton<IMoviesDS, MoviesDS>();
            services.AddSingleton<IActorDS, ActorDS>();
            services.AddSingleton<IBookMarkDS, BookMarkDS>();
            services.AddSingleton<IFavoriteDS, FavoriteDS>();
            services.AddSingleton<IUserDS, UserDS>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseJwtAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
