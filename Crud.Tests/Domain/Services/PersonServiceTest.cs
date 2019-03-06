using Crud.Domain.Entities;
using Crud.Domain.Services;
using Crud.Domain.ValueObjects;
using Crud.Services;
using Crud.Tests.Repositories.Mocks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Crud.Tests.Domain.Services
{
    public class PersonServiceTest
    {

        private IPersonService _personService = new PersonService(new PersonRepositoryMock());

        [Fact]
        public async void Should_add_new_Person()
        {
            Person personToAdd = new Person("Complete Name");
            await _personService.AddPersonAsync(personToAdd);

            int id = personToAdd.Id;

            Person personAdded = await _personService.GetPersonByIdAsync(id);

            Assert.NotNull(personAdded);
            Assert.Equal(id, personAdded.Id);
        }


        [Fact]
        public async void Should_throw_exception_on_add_invalid_Person()
        {
            Person personToAdd = new Person(null);

            await Assert.ThrowsAsync<ValidationException>(() => _personService.AddPersonAsync(personToAdd));
        }

        [Fact]
        public async void Should_update_Person()
        {
            var persons = await _personService.GetAllPersonsAsync();
            int id = persons.First().Id;

            Person personToUpdate = await _personService.GetPersonByIdAsync(id);
            personToUpdate.Email = new Email("mail@test.com");

            await _personService.UpdatePersonAsync(personToUpdate);

            Person personUpdated = await _personService.GetPersonByIdAsync(id);

            Assert.Equal("mail@test.com", personUpdated.Email.Address);
        }


        [Fact]
        public async void Should_throw_exception_on_update_invalid_Person()
        {
            var persons = await _personService.GetAllPersonsAsync();

            Person personToUpdate = persons.First();
            personToUpdate.Email = new Email("invalid");

            await Assert.ThrowsAsync<ValidationException>(() => _personService.UpdatePersonAsync(personToUpdate));
        }

        [Fact]
        public async void Should_delete_Person()
        {
            var persons = await _personService.GetAllPersonsAsync();
            int id = persons.First().Id;

            Person personToDelete = await _personService.GetPersonByIdAsync(id);
            await _personService.DeletePersonAsync(personToDelete);

            Person personDeleted = await _personService.GetPersonByIdAsync(id);

            Assert.Null(personDeleted);
        }
    }
}
