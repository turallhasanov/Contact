using ContactApp.Data;
using ContactApp.Helpers.Exceptions;
using ContactApp.Models;
using ContactApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Services
{
    internal class ContactServices : IContactServices<Contact>
    {
        public  List<Contact> SearchContact(string name)
        {
                var contac = AppDbContact<Contact>.Contacts.Where(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
                return contac;
        }

        public List<Contact> OrderByContactId(string ordertype)
        {
                if (ordertype == "asc")
                {
                    return AppDbContact<Contact>.Contacts.OrderBy(m => m.Id).ToList();
                }
                if (ordertype == "desc")
                {
                    return AppDbContact<Contact>.Contacts.OrderByDescending(m => m.Id).ToList();
                }
                if (ordertype is null)
                {
                    throw new ContactNotFoundException("Contact Not Found");
                }
                return null;
            
        }

        public List<Contact> GetAll()
        {
            return AppDbContact<Contact>.Contacts.ToList();
        }

    }
}
