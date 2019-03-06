using Crud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Services
{
    public interface IPersonService
    {
        Person GetPersonById(int id);
        Task<Person> GetPersonByIdAsync(int id);

        IEnumerable<Person> GetAllPersons();
        Task<IEnumerable<Person>> GetAllPersonsAsync();

        void AddPerson(Person person);
        Task AddPersonAsync(Person person);

        void UpdatePerson(Person person);
        Task UpdatePersonAsync(Person person);

        void DeletePerson(Person person);
        Task DeletePersonAsync(Person person);

        void DeletePersonById(int id);
        Task DeletePersonByIdAsync(int id);
    }
}
