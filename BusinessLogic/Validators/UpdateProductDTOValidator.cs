using Domain.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FluentValidationDTOs
{
    public class UpdateProductDTOValidator:AbstractValidator<UpdateProductDTO>
    {
       public UpdateProductDTOValidator()
       {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MinimumLength(3).WithMessage("Product name must be at least 3 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");
       }
    }
}

