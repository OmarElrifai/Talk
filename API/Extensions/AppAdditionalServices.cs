using API.Data;
using API.Helper;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class AppAdditionalServices
    {
        public static IServiceCollection AppAdditionals(this IServiceCollection services , IConfiguration _config)
        {
              services.AddScoped<ITokenInterface,TokenService>();
              services.AddScoped<IUserRepository,UserRepository>();
              services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<userdata>
            ( options => {options.UseSqlite(_config.GetConnectionString("DefaultConnection")); } );

            return services;
               
        }
        
    }
}