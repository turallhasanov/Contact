using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Data;
using ContactApp.Models;
using ContactApp.Services;
using ContactApp.Services.Interfaces;

namespace ContactApp.Controllers
{
    internal class ContactController
    {
        public void ExecuteCreate()
        {
            Console.WriteLine("Adini Daxil edin");
        Contac: string contactName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(contactName))
            {
                Console.WriteLine("Input Required");
                goto Contac;
            }

            Console.WriteLine("Soyadini Daxil edin");
        Surname: string contactSurname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(contactSurname))
            {
                Console.WriteLine("Input Required");
                goto Surname;
            }

            Console.WriteLine("Nomreni Daxil edin");
        Phone: string contactNumber = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(contactNumber))
            {
                Console.WriteLine("Input Required");
                goto Phone;
            }
            bool isCorrectFormat = int.TryParse(contactNumber, out int number);
            if (!isCorrectFormat)
            {
                Console.WriteLine("Output required");
                goto Phone;
            }
            Contact contact = new()
            {
                Name = contactName,
                Surname = contactSurname,
                Number = contactNumber
            };
            
        }
        public void ExecuteDelete()
        {
            Console.WriteLine("Silmek istediyiniz Idni Daxil Edin");
        ClientId: string clientId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(clientId))
            {
                Console.WriteLine("Input required");
                goto ClientId;
            }
            BaseServices
        }
    }
}
