using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using ShopTraining.Data;
using ShopTraining.Services;
using Swashbuckle.AspNetCore.Swagger;
using AppContext = ShopTraining.Data.AppContext;

namespace ShopTraining
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

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped(sp => OrderService.GetBasket(sp));
            //services.AddMemoryCache();
            //services.AddSession();


            services.AddDbContext<Data.AppContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("CommanderConnection")));

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(
                p => p.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddScoped<IProductRepo, SqlProductRepo>();
            services.AddScoped<IOrderRepo, SqlOrderRepo>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            //services.AddDbContext<AppContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("CommanderConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            //app.UseSession();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
