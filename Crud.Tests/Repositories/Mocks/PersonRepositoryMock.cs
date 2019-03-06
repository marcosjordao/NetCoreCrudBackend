using Crud.Domain.Entities;
using Crud.Domain.Repositories;
using Crud.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Tests.Repositories.Mocks
{
    class PersonRepositoryMock : IPersonRepository
    {
        private List<Person> persons;

        public PersonRepositoryMock()
        {
            var person1 = new Person("First Person");
            person1.Id = 1;

            var person2 = new Person("Second Person");
            person2.Id = 2;

            var person3 = new Person("Third Person");
            person3.Id = 3;

            persons = new List<Person>();
            persons.Add(person1);
            persons.Add(person2);
            persons.Add(person3);
        }

        public void Add(Person entity)
        {
            int id = 0;
            if (this.persons.Count > 0)
                id = this.persons.Max(f => f.Id);
            id++;
            entity.Id = id;

            this.persons.Add(entity);
        }

        public void Update(Person entity)
        {
            this.persons.Remove(entity);
            this.persons.Add(entity);
        }

        public void Delete(Person entity)
        {
            this.persons.Remove(entity);
        }

        public Person Get(int id)
        {
            return this.persons.SingleOrDefault(f => f.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return this.persons;
        }


        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await Task.FromResult(this.GetAll());
        }

        public async Task<Person> GetAsync(int id)
        {
            return await Task.FromResult(this.Get(id));
        }

        public async Task AddAsync(Person entity)
        {
            this.Add(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Person entity)
        {
            this.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Person entity)
        {
            this.Delete(entity);
            await Task.CompletedTask;
        }

    }
}
