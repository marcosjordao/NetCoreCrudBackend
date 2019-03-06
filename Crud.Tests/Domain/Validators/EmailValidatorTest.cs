using Crud.Domain.ValueObjects;
using Crud.Services.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Crud.Tests.Domain.Validators
{
    public class EmailValidatorTest
    {
        private readonly EmailValidator validator;
        public EmailValidatorTest()
        {
            this.validator = new EmailValidator();
        }

        [Theory]
        [InlineData("invalid")]
        [InlineData("a@")]
        [InlineData("abcdefghijklmnopqrstuvwxyz@abcdefghijklmnopqrstuvwxyz.abcdefghijklmnopqrstuvwxyz")]
        public void Should_invalid_wrong_address(string address)
        {
            Email email = new Email(address);

            ValidationResult results = validator.Validate(email);

            Assert.False(results.IsValid);
        }


        [Fact]
        public void Should_valid_correct_address()
        {
            Email email = new Email("correct@address.com");

            ValidationResult results = validator.Validate(email);

            Assert.True(results.IsValid);
        }
    }
}
