using Domain.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FluentValidationDTOs
{
    public class CreateProductDTOValidator:AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MinimumLength(3).WithMessage("Product name must be at least 3 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");

            RuleFor(x => x.CategoryIds)
                .NotNull().WithMessage("At least one category must be selected")
                .Must(list => list.Count > 0).WithMessage("At least one category must be selected");
        }
    }
}

