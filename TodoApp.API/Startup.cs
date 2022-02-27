using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using TodoApp.API.Filters;
using TodoApp.Core.Configuration;
using TodoApp.Core.Constants;
using TodoApp.Core.Extensions;
using TodoApp.Core.Model;
using TodoApp.Repository;
using TodoApp.Service.TokenExtension;
using TodoApp.Service.Validations;

namespace TodoApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        private readonly string MyAllowOrigigs = "_myAllowOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
            });

            

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "_myAllowOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "https://localhost:4200", "https://localhost:44318")
                            .AllowAnyHeader().AllowAnyMethod();
                    }
                    );
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
       


            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(Messages.GetConnectionStringSql), sqloptions =>
                {
                    sqloptions.MigrationsAssembly(Messages.TodoAppRepository);
                });
            });
            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.Configure<CustomTokenOptions>(Configuration.GetSection(Messages.TokenOptions));
            services.Configure<List<Client>>(Configuration.GetSection(Messages.Clients));
            var tokenOptions = Configuration.GetSection(Messages.TokenOptions).Get<CustomTokenOptions>();
            services.AddCustomTokenAuth(tokenOptions);


            services.UseCustomValidationResponse();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Messages.AddSwaggerGenSwaggerDoc, new OpenApiInfo { Title = Messages.OpenApiInfoTitle, Version = Messages.OpenApiInfoVersion });
                c.AddSecurityDefinition(Messages.AddSwaggerGenAddSecurityDefinition, new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = Messages.AddSecurityDefinitionDescription,
                    Name = Messages.AddSecurityDefinitionName,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = Messages.AddSecurityRequirementId
                            },
                            Scheme = Messages.AddSecurityRequirementScheme,
                            Name = Messages.AddSecurityRequirementName,
                            In = ParameterLocation.Header,
                        },
                        new string[] { }
                    }
                });
            });


            services.AddScoped(typeof(NotFoundFilter<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint(Messages.SwaggerEndpointUrl, Messages.SwaggerEndpointName));
            }

            app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowOrigigs);
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
