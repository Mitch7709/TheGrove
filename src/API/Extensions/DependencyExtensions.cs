using Core.Features.Instructors.Create;
using Core.Features.Instructors.Delete;
using Core.Features.Instructors.Read;
using Core.Features.Instructors.Update;
using Core.Features.Students.Create;
using Core.Features.Students.Delete;
using Core.Features.Students.Read;
using Core.Features.Students.Update;
using Core.Features.Users;
using Core.Features.Users.Register;
using Core.Shared;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.Identity;

namespace API.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddDepedencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, AppDbContext>();

            services.AddValidatorsFromAssemblyContaining<RegisterValidator>();            
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();            

            services.AddTransient<CreateStudentUseCase>();
            services.AddTransient<UpdateStudentUseCase>();
            services.AddTransient<StudentReadService>();
            services.AddTransient<DeleteStudentUseCase>();

            services.AddTransient<CreateInstructorUseCase>();
            services.AddTransient<UpdateInstructorUseCase>();
            services.AddTransient<InstructorReadService>();
            services.AddTransient<DeleteInstructorUseCase>();

            services.AddTransient<RegisterUseCase>();

            return services;
        }

    }
}
