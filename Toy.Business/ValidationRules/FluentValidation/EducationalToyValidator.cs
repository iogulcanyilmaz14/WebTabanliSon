using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Toy.Entities.Concrete;

namespace Toy.Business.ValidationRules.FluentValidation
{
   public class EducationalToyValidator : AbstractValidator<EducationalToy>
    {
        public EducationalToyValidator()
        {
            RuleFor(e => e.Name).MinimumLength(4);
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.UnitPrice).GreaterThanOrEqualTo(100);
            RuleFor(e => e.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
