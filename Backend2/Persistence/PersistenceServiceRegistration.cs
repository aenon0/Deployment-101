using System.Text;
using Application.Contracts.Identity;
using Application.DTO.Identity;
using Domain;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Services;
using Application.Contracts.ContestCreation;
using Application.Contracts.ContestSummary;
using Persistence.Repositories.ContestRepo;
using Persistence.Repositories.ContestSummary;
using Application.Contracts.GroupFormation;
using Persistence.Repositories.GroupRepo;

namespace Persistence;


public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<ContestCentralDbContext>(options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("ContestCentralConnectionString"));
                    
                }
            );

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ContestCentralDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IContestRepository, ContestRepository>();
            services.AddTransient<IUpdateContestSummary, UpdateContestSummary>();
            services.AddTransient<IContestSummaryRepository, ContestSummaryRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
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


            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            return services;

        }
    }
