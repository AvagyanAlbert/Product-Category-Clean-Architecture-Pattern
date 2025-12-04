using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CategoryDTOs;
using FluentValidation;

namespace Domain.FluentValidationDTOs
{
    public class CreateCategoryDTOValidator:AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name required")
                .MinimumLength(2).WithMessage("Category name must be at least 2 characters");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Category description required")
                .MinimumLength(3).WithMessage("Category description must be at least 3 characters");
        }
    }
}
