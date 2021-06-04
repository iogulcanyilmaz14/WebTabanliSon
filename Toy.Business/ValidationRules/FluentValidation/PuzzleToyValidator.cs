using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Toy.Entities.Concrete;

namespace Toy.Business.ValidationRules.FluentValidation
{
   public class PuzzleToyValidator : AbstractValidator<PuzzleToy>
    {
        public PuzzleToyValidator()
        {
            RuleFor(pu => pu.Name).MinimumLength(4);
            RuleFor(pu => pu.Name).NotEmpty();
            RuleFor(pu => pu.UnitPrice).GreaterThanOrEqualTo(100);
            RuleFor(pu => pu.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
