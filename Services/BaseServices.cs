using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Data;
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
        public void Create(T text)
        {
            text.Id = _idCount;
            AppDbContact<T>.Contacts.Add(text);
            _idCount++;
        }
        public void Delete(T text)
        {
            AppDbContact<T>.Contacts.Remove(text);
        }

        public void Update(T text)
        {
            T LastData = AppDbContact<T>.Contacts.FirstOrDefault(x => x.Id == text.Id);
            if (LastData != null)
            {
                int index = AppDbContact<T>.Contacts.IndexOf(LastData);
                AppDbContact<T>.Contacts[index] = LastData;
            }
        }
    }
}
