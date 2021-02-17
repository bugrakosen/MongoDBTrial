using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDBTrial.Data.Abstract;
using MongoDBTrial.Data.Concrete;
using MongoDBTrial.Data.MongoSettings;
using MongoDBTrial.Middleware;
using MongoDBTrial.Services.Abstract;
using MongoDBTrial.Services.Concrete;

namespace MongoDBTrial
{
    public class Startup
    {

        /// <summary> Configuration value. </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor of <c>Startup</c>
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string mongoConnectionString = this.Configuration.GetConnectionString("MongoConnectionString");

            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<ITodoService, TodoService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapControllerRoute("Default", "{controller=Todos}/{action=Todo}/{id?}");
            });

            app.UseErrorMiddleware();
        }
    }
}
