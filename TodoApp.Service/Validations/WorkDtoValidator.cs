using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TodoApp.Core.DTOs;

namespace TodoApp.Service.Validations
{
    public class WorkDtoValidator : AbstractValidator<WorkDto>
    {
        public WorkDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition is required");

            RuleFor(x => x.IsCompleted).NotEmpty().WithMessage("IsCompleted is required");
        }

    }
}
