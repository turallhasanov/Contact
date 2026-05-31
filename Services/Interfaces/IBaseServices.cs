using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Services.Interfaces
{
    internal interface IBaseServices<T>
    {
        public void Create(Contact contact);
        public void Update(int id, Contact contact);
        public void Delete(int id);
        

    }
}
