using CleanCore.Application.Interfaces;
using CleanCore.Application.Mappings;
using CleanCore.Application.Services;
using CleanCore.Domain.Entities;
using CleanCore.Infra.Data.Context;
using CleanCore.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCore.Infra.IoC; 
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration) {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISupplierService, SupplierService>();

        services.AddAutoMapper(typeof(ProductProfile));
        services.AddAutoMapper(typeof(CategoryProfile));
        services.AddAutoMapper(typeof(SupplierProfile));

        return services;
    }
}

