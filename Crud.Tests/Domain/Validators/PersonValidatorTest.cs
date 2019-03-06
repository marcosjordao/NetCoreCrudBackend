using Crud.Domain.Entities;
using Crud.Services.Validators;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Crud.Tests.Domain.Validators
{
    public class PersonValidatorTest
    {
        private readonly PersonValidator validator;

        public PersonValidatorTest()
        {
            this.validator = new PersonValidator();
        }

        [Theory]
        [InlineData("a")]
        [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
        public void Should_invalid_wrong_name(string name)
        {
            Person person = new Person(name);

            ValidationResult results = validator.Validate(person);

            Assert.False(results.IsValid);
        }

        [Fact]
        public void Should_invalid_null_name()
        {
            Person person = new Person(null);

            ValidationResult results = validator.Validate(person);

            Assert.False(results.IsValid);
        }

        [Fact]
        public void Should_valid_null_phone()
        {
            Person person = new Person("Name");
            person.Phone = null;

            ValidationResult results = validator.Validate(person);

            Assert.True(results.IsValid);
        }


        [Fact]
        public void Should_invalid_wrong_phone()
        {
            Person person = new Person("Name");
            person.Phone = "012345678901234567890123456789";

            ValidationResult results = validator.Validate(person);

            Assert.False(results.IsValid);
        }


        [Fact]
        public void Should_have_email_validator()
        {
            validator.ShouldHaveChildValidator(p => p.Email, typeof(EmailValidator));
        }
    }
}
