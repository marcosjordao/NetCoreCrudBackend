using Crud.Domain.Entities;
using System;
using Xunit;

namespace Crud.Tests.Domain.Entities
{
    public class PersonTest
    {
        [Fact]
        public void Should_set_name_in_the_constructor()
        {
            string name = "Person Name";

            Person person = new Person(name);
            Assert.Equal(name, person.Name);
        }

    }
}
