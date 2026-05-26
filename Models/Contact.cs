using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
    }
}
