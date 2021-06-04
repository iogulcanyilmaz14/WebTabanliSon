using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Entities.Concrete;

namespace Toy.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(4);
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).Must(StartWithA).WithMessage("Kişiler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
