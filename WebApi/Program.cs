using System.Text;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.UserManagement.Repository;
using Infrastructure.Options;
using Infrastructure.Services.Abstractions;
using Infrastructure.Services.Implementations;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using WebApi.Middleware;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var services = builder.Services;

            services.AddControllers()
                .AddMvcOptions(options =>
                {
                    options.Conventions.Add(new RouteTokenTransformerConvention(new LowercaseRouteTransformer()));
                });
            services.AddOpenApi();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddFluentValidation([typeof(Program).Assembly]);

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration[$"{nameof(JwtOptions)}:{nameof(JwtOptions.Issuer)}"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration[$"{nameof(JwtOptions)}:{nameof(JwtOptions.Audience)}"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration[$"{nameof(JwtOptions)}:{nameof(JwtOptions.Secret)}"]!)),
                        ValidateIssuerSigningKey = true
                    };
                });

            services.AddOptions<DatabaseOptions>()
                .Bind(configuration.GetSection(DatabaseOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddOptions<JwtOptions>()
                .Bind(configuration.GetSection(JwtOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.Title = "my-ancestry.com";
                    options.Theme = ScalarTheme.Kepler;
                    options.HideDownloadButton = true;
                });
            }
            app.UseCustomExceptionMiddleware();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public class LowercaseRouteTransformer : IOutboundParameterTransformer
        {
            public string? TransformOutbound(object? value)
            {
                return value?.ToString()?.ToLowerInvariant();
            }
        }
    }
}
