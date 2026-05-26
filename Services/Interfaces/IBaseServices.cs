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
        public void Create(T text);
        public void Update(T text);
        public void Delete(T text);

    }
}
