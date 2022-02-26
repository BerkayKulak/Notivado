using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TodoApp.API.Filters;
using TodoApp.Core.Configuration;
using TodoApp.Core.Constants;
using TodoApp.Core.DTOs;
using TodoApp.Core.Extensions;
using TodoApp.Repository.Repositories;
using TodoApp.Repository.UnitOfWorks;
using TodoApp.Service.Services;
using TodoApp.Core.Services;
using TodoApp.Core.Repositories;
using TodoApp.Core.UnitOfWorks;
using TodoApp.Repository;
using IAuthenticationnService = TodoApp.Core.Services.IAuthenticationnService;
using TodoApp.Core.Model;
using TodoApp.Service.Validations;
using TodoApp.Service.TokenExtension;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
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
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
