using Crud.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Services.Validators
{
    public class EmailValidator: AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(e => e.Address).Length(5, 60)
                                   .EmailAddress();
        }
    }
}
