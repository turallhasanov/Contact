using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Data
{
    internal class AppDbContact<T>
    {

        public static List<T> Contacts = new List<T>();
    }
}
