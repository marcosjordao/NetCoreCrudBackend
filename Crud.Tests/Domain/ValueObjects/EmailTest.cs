using Crud.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Crud.Tests.Domain.ValueObjects
{
    public class EmailTest
    {
        [Fact]
        public void Should_set_address_in_the_constructor()
        {
            string address = "valid@address.com";

            Email email = new Email(address);
            Assert.Equal(address, email.Address);
        }
    }
}
