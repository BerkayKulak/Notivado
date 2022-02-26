using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoApp.Core.Constants;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;
using TodoApp.Core.Services;

namespace TodoApp.API.Filters
{
    public class NotFoundFilter<T, Tdto> : IAsyncActionFilter where Tdto : class where T : BaseEntity
    {

        private readonly IServiceGeneric<T, Tdto> _service;

        public NotFoundFilter(IServiceGeneric<T, Tdto> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(Response<NoDataDto>.Fail(Messages.IdNotFount, 404, true));
            
        }
    }
}
