using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Services.Interfaces
{
    internal interface IContactServices <T>
    {
        public List<Contact> SearchContact(string name);

        public List<Contact> OrderByContactId(string ordertype);

        public List<Contact> GetAll();
    }
}
