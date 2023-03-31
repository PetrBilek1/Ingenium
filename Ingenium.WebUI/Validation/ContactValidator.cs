using Ingenium.WebAPI.Contracts.Models;
using System.Text.RegularExpressions;

namespace Ingenium.WebUI.Validation;

public static class ContactValidator
{
    public static List<string> Validate(ContactModel contact)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(contact.FirstName))
        {
            errors.Add("First Name can't be empty.");
        }

        if (string.IsNullOrWhiteSpace(contact.LastName))
        {
            errors.Add("Last Name can't be empty.");
        }

        var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        if (string.IsNullOrWhiteSpace(contact.Email))
        {
            errors.Add("Email can't be empty.");
        }
        else if (!emailRegex.IsMatch(contact.Email))
        {
            errors.Add("Email has invalid format.");
        }

        var telRegex = new Regex(@"^(\+420)? ?[1-9][0-9]{2} ?[0-9]{3} ?[0-9]{3}$");
        if (string.IsNullOrWhiteSpace(contact.TelephoneNumber))
        {
            errors.Add("Telephone number can't be empty.");
        }
        else if (!telRegex.IsMatch(contact.TelephoneNumber))
        {
            errors.Add("Telephone number has invalid format.");
        }

        return errors;
    }
}