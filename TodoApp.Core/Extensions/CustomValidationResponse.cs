using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TodoApp.Core.DTOs;

namespace TodoApp.Core.Extensions
{
    /// <summary>
    /// Our verification response class that returns a response as BadRequest
    /// </summary>
    public static class CustomValidationResponse
    {
        public static void UseCustomValidationResponse(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opts =>
            {
                opts.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage);

                    ErrorDto errorDto = new(errors.ToList(), true);

                    var response = Response<NoContentResult>.Fail(errorDto, 400);

                    return new BadRequestObjectResult(response);

                };
            });
        }
    }
}
