using System;

using System.Collections.Generic;

using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Firebase.Authentication.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingCartApi.Conventions;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services;
using Swashbuckle.AspNetCore.Swagger;
namespace ShoppingCartApi

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

            services.AddDbContext<ShoppingCartDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ShoppingCartDbConnectionString"))
            );
            services.Configure<StkSetting>(options => Configuration.GetSection("StkSetting").Bind(options));
            services.AddTransient<IRepository<Order>, OrdersManager>();
            services.AddTransient<IRepository<ShipmentMethod>, ShipmentMethodManager>();
            services.AddTransient<IRepository<PaymentMethod>, PaymentMethodsManager>();
            services.AddTransient<IRepository<Product>, ProductsManager>();
            services.AddTransient<IRepository<Shopper>, ShoppersManager>();
            services.AddTransient<IRepository<Manufacturer>, ManufacturersManager>();
            services.AddTransient<IRepository<ProductCategory>, ProductCategoryManager>();
            services.Configure<ShoppingCartStkPushKey>(options => Configuration.GetSection("ShoppingCartStkPushKey").Bind(options));
            services.AddMvc(options =>
            {
                options.Conventions.Add(new ComplexTypeConvention());
            });

            services
     .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
         options.Authority = Configuration["Jwt:Issuer"];
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidIssuer = Configuration["Jwt:Issuer"],
             ValidateAudience = true,
             ValidAudience = Configuration["Jwt:aud"],
             ValidateLifetime = true
         };
     });
            services.AddSwaggerGen(c =>

            {

                c.SwaggerDoc("v1", new Info { Title = "Shopping Cart Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                                                 {
                                       { "Bearer", new string[] { } }
                                    });

            });



        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)

        {

            if (env.IsDevelopment())

            {



                app.UseDeveloperExceptionPage();

            }

            app.UseCors(builder =>
            {

                builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().Build();

            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>

            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping Cart V1");

            });
            app.UseAuthentication();
            app.UseMvc();

        }

    }

}