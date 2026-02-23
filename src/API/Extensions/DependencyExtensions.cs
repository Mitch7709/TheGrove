using Core.Features.Students.Create;
using Core.Shared;
using FluentValidation;
using Infrastructure.Database;

namespace API.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddDepedencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, AppDbContext>();

            services.AddValidatorsFromAssemblyContaining<CreateStudentValidator>();
            services.AddTransient<CreateStudentUseCase>();

            return services;
        }

    }
}
