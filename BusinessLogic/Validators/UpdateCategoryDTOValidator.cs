using Domain.CategoryDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FluentValidationDTOs
{
    public class UpdateCategoryDTOValidator:AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        { 
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name required")
                .MinimumLength(2).WithMessage("Category name must be at least 2 characters");
        }
    }
}
