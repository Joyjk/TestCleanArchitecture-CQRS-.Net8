using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.IRepository;
using Test.Infracture.DBContext;
using Test.Infracture.Repository;

namespace Test.Infracture
{
    public static class InfractureDependencyInjection
    {
        public static IServiceCollection AddInfractureDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<DatabaseDbContext>();

            return services;
        }
    }
}
