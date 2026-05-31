using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Data;
using ContactApp.Helpers.Exceptions;
using ContactApp.Models;
using ContactApp.Services.Interfaces;

namespace ContactApp.Services
{
    internal class BaseServices<T> : IBaseServices<T> where T : BaseEntity
    {
        private readonly AppDbContact<T> _appDbContact;
        public BaseServices()
        {
            _appDbContact = new AppDbContact<T>();
        }
        public static int _idCount = 1;
        public void Create(Contact contact)
        {
            try
            {
                contact.Id = _idCount;
                AppDbContact<Contact>.Contacts.Add(contact);
                _idCount++;
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void Delete(int id)
        {
            try
            {
                var contac = AppDbContact<Contact>.Contacts.FirstOrDefault(m => m.Id == id);
                AppDbContact<Contact>.Contacts.Remove(contac);
                if (contac is null)
                {
                    throw new ContactNotFoundException("Contact is not found");
                }
            }
            catch (ContactNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(int id, Contact contact)
        {
            try
            {
                var result = AppDbContact<Contact>.Contacts.FirstOrDefault(m => m.Id == id);
                if (result == null)
                {
                    Console.WriteLine("Contact not Found");
                }
                if (result == null)
                {
                    throw new ContactNotFoundException("Contact Not Found");
                }
                result.Name = contact.Name;
                result.Surname = contact.Surname;
                result.Number = contact.Number;
            }
            catch (ContactNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }   
}
