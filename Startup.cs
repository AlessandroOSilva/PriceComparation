using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PricesComparation.Business;
using PricesComparation.Business.Implementation;
using PricesComparation.Models.Context;
using PricesComparation.Repositories.Generics;
using PricesComparation.Services;

namespace PricesComparation
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
            var connection = Configuration.GetConnectionString("MySQLConnection");
            services.AddDbContextPool<PricesComparationContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            services.AddControllers().AddNewtonsoftJson(opt => 
            opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PricesComparation", Version = "v1" });
            });


            services.AddScoped<SeedingService>();
            services.AddScoped<IShopBusiness, ShopBusinessImplementation>();
            services.AddScoped<IProductBusiness, ProductBusinesImplementation>();
            services.AddScoped<IBrandBusiness, BrandBusinessImplementation>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment())
            {
                seedingService.Seed();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PricesComparation v1"));
            }

            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controllers=value}/{id?}");
            });
        }
    }
}
