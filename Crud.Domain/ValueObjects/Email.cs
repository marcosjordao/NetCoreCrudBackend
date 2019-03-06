using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Domain.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
    }

}
