using ContactApp.Controllers;
using ContactApp.Helpers.Constans;
using ContactApp.Helpers.Enums;
using ContactApp.Helpers.Exceptions;
using System.ComponentModel;

ContactController contactController = new();

while (true)
{
	ConsoleColor.Yellow.WriteToConsole("Select Operators: 1- Create Contact, 2 -Delete Conctact, 3 -Update Contact, 4- Order Contact, 5- Search Contac, 6 - Get All");
Contact: string contact = Console.ReadLine();
	if (string.IsNullOrWhiteSpace(contact))
	{
		ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
		goto Contact;
	}
	bool isCorrectFormat = int.TryParse(contact, out int contactid);
	if (!isCorrectFormat)
	{
		ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
		goto Contact;
	}
	switch (contactid)
	{
		case (int)Operations.CreateContact:
			contactController.ExecuteCreate();
			break;
		case (int)Operations.DeleteContact:
            contactController.ExecuteDelete();
            break;
        case (int)Operations.UpdateContact:
            contactController.ExecuteUpdate();
            break;
        case (int)Operations.OrderContact:
            contactController.ExecuteOrderContact();
            break;
        case (int)Operations.SearchContact:
            contactController.ExecuteSearchContact();
            break;
		case (int)Operations.GetAllContact:
			contactController.ExecuteGetAll();
			break;
        default:
			ConsoleColor.Red.WriteToConsole(ValidationsMessage.InputRequired);
			break;
	}

}