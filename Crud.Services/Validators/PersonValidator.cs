using Crud.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Services.Validators
{
    public class PersonValidator: AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                                .Length(3, 70);

            RuleFor(p => p.Phone).MaximumLength(20);

            RuleFor(p => p.Email).SetValidator(new EmailValidator());
        }
    }
}
