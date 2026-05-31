using ContactApp.Data;
using ContactApp.Helpers.Constans;
using ContactApp.Helpers.Exceptions;
using ContactApp.Models;
using ContactApp.Services;
using ContactApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactApp.Controllers
{
    internal class ContactController
    {
        private readonly IContactServices<Contact> _contactServices;
        private readonly IBaseServices<Contact> _baseServices;

        public ContactController()
        {
            _contactServices = new ContactServices();
            _baseServices = new BaseServices<Contact>();
        }
        public void ExecuteCreate()
        {
            Console.WriteLine("Adini Daxil edin");
        Contac: string contactName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(contactName))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto Contac;
            }
            string pattern = @"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+$";
            if (!Regex.IsMatch(contactName, pattern))
            {
                ConsoleColor.Red.WriteToConsole("Ancaq Herf girmelisiniz");
                goto Contac;
            }


            Console.WriteLine("Soyadini Daxil edin");
        Surname: string contactSurname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(contactSurname))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto Surname;
            }
            string patternSurname = @"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+$";
            if (!Regex.IsMatch(contactSurname, patternSurname))
            {
                ConsoleColor.Red.WriteToConsole("Ancaq Herf girmelisiniz");
                goto Surname;
            }

            Console.WriteLine("Nomreni Daxil edin");
        Phone: string contactNumber = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(contactNumber))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto Phone;
            }
            string patternNumber = @"^\+?\d+$";

            if (!Regex.IsMatch(contactNumber, patternNumber))
            {
                ConsoleColor.Red.WriteToConsole("Ancaq Reqem Girmelisiniz");
                goto Phone;
            }
            bool isCorrectFormat = int.TryParse(contactNumber, out int number);
            if (!isCorrectFormat)
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.Format);
                goto Phone;
            }
            Contact contact = new()
            {
                Name = contactName,
                Surname = contactSurname,
                Number = contactNumber
            };

            _baseServices.Create(contact);

            ConsoleColor.Green.WriteToConsole("Created Success");

        }
        public void ExecuteDelete()
        {
            Console.WriteLine("Silmek istediyiniz Idni Daxil Edin");
        ClientId: string clientId = Console.ReadLine();
            string patternNumber = @"^\d+$";

            if (!Regex.IsMatch(clientId, patternNumber))
            {
                ConsoleColor.Red.WriteToConsole("Ancaq Reqem Girmelisiniz");
                goto ClientId;
            }
            bool isCorrectFormat = int.TryParse(clientId, out int number);
            if (!isCorrectFormat)
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.Format);
                goto ClientId;
            }
            if (string.IsNullOrWhiteSpace(clientId))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto ClientId;
            }
            
            _baseServices.Delete(number);

        }

        public void ExecuteUpdate()
        {
            Console.WriteLine("Idni Daxil Edin");
        ContactId: string contactId = Console.ReadLine();
            string patternNumber = @"^\d+$";

            if (!Regex.IsMatch(contactId, patternNumber))
            {
                ConsoleColor.Red.WriteToConsole("Ancaq Reqem Girmelisiniz");
                goto ContactId;
            }
            if (string.IsNullOrWhiteSpace(contactId))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto ContactId;
            }
            bool isCorrectFormat = int.TryParse(contactId, out int id);
            if (!isCorrectFormat)
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
            }
            Console.WriteLine("Adini Daxil Edin");
        Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto Name;
            }
            string pattern = @"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+$";
            if (!Regex.IsMatch(name, pattern))
            {
                ConsoleColor.Red.WriteToConsole("Ancaq Herf girmelisiniz");
                goto Name;
            }
            Console.WriteLine("Soyadini Daxil edin");
        Surname: string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto Surname;
            }
            string patternSurname = @"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+$";
            if (!Regex.IsMatch(surname, patternSurname))
            {
                ConsoleColor.Red.WriteToConsole("Ancaq Herf girmelisiniz");
                goto Surname;
            }
            Console.WriteLine("Nomresini Daxil edin");
        Number: string number = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(number))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto Number;
            }
            string patternNumberr = @"^\+?\d+$";

            if (!Regex.IsMatch(number, patternNumberr))
            {
                ConsoleColor.Red.WriteToConsole("Ancaq Reqem Girmelisiniz");
                goto Number;
            }

            Contact contact = new()
            {
                Name = name,
                Surname = surname,
                Number = number
            };

            _baseServices.Update(id,contact);

            ConsoleColor.Green.WriteToConsole("Update success: ");
        }

        public void ExecuteSearchContact()
        {
            Console.WriteLine("Axtarmaq istediyiniz Adi daxil edin: ");
        Name1: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto Name1;
            }
            string pattern = @"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+$";
            if (!Regex.IsMatch(name, pattern))
            {
                ConsoleColor.Red.WriteToConsole("Ancaq Herf girmelisiniz");
                goto Name1;
            }
            var result = _contactServices.SearchContact(name);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Surname} {item.Number}");
            }
            ConsoleColor.Green.WriteToConsole("Search Success");
        }

        public void ExecuteOrderContact()
        {
            Console.WriteLine("Siralamaq ucun daxil edin: ");
        Short: string shortId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(shortId))
            {
                ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
                goto Short;
            }
            var result = _contactServices.OrderByContactId(shortId);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Surname} {item.Number}");
            }

            ConsoleColor.Green.WriteToConsole("Short success");
        }

        public void ExecuteGetAll()
        {
            var result = _contactServices.GetAll();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Surname} {item.Number}");
            }
        }
    }
}
