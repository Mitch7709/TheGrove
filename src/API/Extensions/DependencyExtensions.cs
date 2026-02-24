using Core.Features.Students.Create;
using Core.Features.Students.Delete;
using Core.Features.Students.Read;
using Core.Features.Students.Update;
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
            services.AddValidatorsFromAssemblyContaining<UpdateStudentValidator>();
            services.AddTransient<CreateStudentUseCase>();
            services.AddTransient<UpdateStudentUseCase>();
            services.AddTransient<StudentReadService>();
            services.AddTransient<DeleteStudentUseCase>();

            return services;
        }

    }
}
