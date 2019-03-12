using Crud.Domain.Entities;
using Crud.Domain.Repositories;
using Crud.Domain.Services;
using Crud.Services.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Services
{
    public class PersonService: IPersonService
    {

        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person GetPersonById(int id)
        {
            return _personRepository.Get(id);
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            Person person = await _personRepository.GetAsync(id);
            return person;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _personRepository.GetAll();
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            IEnumerable<Person> persons = await _personRepository.GetAllAsync();
            return persons;
        }

        public void AddPerson(Person person)
        {
            PersonValidator validator = new PersonValidator();
            validator.ValidateAndThrow(person);

            this._personRepository.Add(person);
        }

        public async Task AddPersonAsync(Person person)
        {
            PersonValidator validator = new PersonValidator();
            validator.ValidateAndThrow(person);

            await this._personRepository.AddAsync(person);
        }


        public void UpdatePerson(Person person)
        {
            PersonValidator validator = new PersonValidator();
            validator.ValidateAndThrow(person);

            this._personRepository.Update(person);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            PersonValidator validator = new PersonValidator();
            validator.ValidateAndThrow(person);

            await this._personRepository.UpdateAsync(person);
        }


        public void DeletePerson(Person person)
        {
            this._personRepository.Delete(person);
        }

        public async Task DeletePersonAsync(Person person)
        {
            await this._personRepository.DeleteAsync(person);
        }

        public void DeletePersonById(int id)
        {
            Person personToDelete = this.GetPersonById(id);

            if (personToDelete == null)
                throw new KeyNotFoundException();
            else
            {
                this.DeletePerson(personToDelete);
            }
        }

        public async Task DeletePersonByIdAsync(int id)
        {
            Person personToDelete = await this.GetPersonByIdAsync(id);
            
            if (personToDelete == null)
                throw new KeyNotFoundException();
            else
            {
                await this.DeletePersonAsync(personToDelete);
            }
        }
    }
}
