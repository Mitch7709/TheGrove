using API.Extensions;
using Core.Features.ClassTypes.Create;
using Core.Features.ClassTypes.Delete;
using Core.Features.ClassTypes.Read;
using Core.Features.ClassTypes.Update;
using Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Modules
{
    public class ClassTypeModule : IModule
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/class-types")
                .WithTags("Class Types")
                .RequireAuthorization(Security.NonStudentPolicy);

            group.MapGet("", GetClassTypes);
            group.MapGet("/{id}", GetClassTypeById);

            group.MapPost("", CreateClassType)
                .Validator<CreateClassTypeRequest>();              

            group.MapPut("/{id}", UpdateClassType)
                .Validator<UpdateClassTypeRequest>();

            group.MapDelete("/{id}", DeleteClassType);
        }

        private static async Task<Ok<IReadOnlyList<ClassTypeResponse>>> GetClassTypes(ClassTypeReadService service)
        {
            var result = await service.GetAllAsync();
            return TypedResults.Ok(result);
        }

        private static async Task<Results<Ok<ClassTypeResponse>, NotFound<string>>> GetClassTypeById(int id, ClassTypeReadService service)
        {
            var result = await service.GetByIdAsync(id);
            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.NotFound(result.ErrorMessage);
        }

        private static async Task<Results<Ok<CreateClassTypeResponse>, BadRequest<string>, Conflict<string>>>
            CreateClassType(CreateClassTypeRequest request, CreateClassTypeUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(request);
            if (result.IsSuccess)
                return TypedResults.Ok(result.Value);

            return result.ErrorType == ErrorType.Conflict
                ? TypedResults.Conflict(result.ErrorMessage)
                : TypedResults.BadRequest(result.ErrorMessage);
        }

        private static async Task<Results<Ok<UpdateClassTypeResponse>, NotFound<string>>>
            UpdateClassType(int id, UpdateClassTypeRequest request, UpdateClassTypeUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(id, request);
            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.NotFound(result.ErrorMessage);
        }

        private static async Task<Results<NoContent, NotFound<string>, BadRequest<string>>> DeleteClassType(int id, DeleteClassTypeUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(id);
            if (result.IsSuccess)
                return TypedResults.NoContent();

            return result.ErrorType == ErrorType.NotFound
                ? TypedResults.NotFound(result.ErrorMessage)
                : TypedResults.BadRequest(result.ErrorMessage);
        }
    }
}
