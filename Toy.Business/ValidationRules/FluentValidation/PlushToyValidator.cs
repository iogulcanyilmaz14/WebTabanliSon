using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Toy.Entities.Concrete;

namespace Toy.Business.ValidationRules.FluentValidation
{
   public class PlushToyValidator : AbstractValidator<PlushToy>
    {
        public PlushToyValidator()
        {
            RuleFor(p => p.Name).MinimumLength(4);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(100);
            RuleFor(p => p.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
