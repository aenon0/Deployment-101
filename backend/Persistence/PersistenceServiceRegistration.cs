using System.Text;
using Application.Contracts.Identity;
using Application.Models;
using Domain.Entites;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.Identity;


namespace Persistence;

public  static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,IConfiguration configuration){

            services.AddDbContext<ContestManagementDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ContestManagementConnectionString")));
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.Configure<ServerSettings>(configuration.GetSection("ServerSettings"));

            services.AddScoped<IAuthService,AuthService>();
            // services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddIdentity<MainUser, IdentityRole>()
                .AddEntityFrameworkStores<ContestManagementDbContext>()
                // .AddPasswordValidator<UserPasswordValidator>()
                .AddDefaultTokenProviders();
                
            
            services.AddAuthorization();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                        opt.TokenLifespan = TimeSpan.FromHours(2));
                        
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true, 
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };
                });
            return services;
    }
}
