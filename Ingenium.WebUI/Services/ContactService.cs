using Ingenium.WebAPI.Contracts.Models;
using Ingenium.WebAPI.Contracts.Requests;
using Ingenium.WebUI.Services.Contracts;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Ingenium.WebUI.Services;

public sealed class ContactService : IContactService
{
    private readonly HttpClient _httpClient;

    public ContactService(HttpClient httpClient) 
    { 
        _httpClient = httpClient;
    }

    public async Task<ContactModel> GetByIdAsync(long id)
    {
        var contact = await _httpClient.GetFromJsonAsync<ContactModel>($"api/Contacts/{id}");

        return contact;
    }

    public async Task<List<ContactModel>> GetAllAsync()
    {
        var contacts = await _httpClient.GetFromJsonAsync<List<ContactModel>>("api/Contacts");

        return contacts;
    }

    public async Task<List<ContactModel>> SearchAsync(
        string? nameQuery,
        string? telQuery,
        DateTime? fromQuery,
        DateTime? toQuery,
        bool? isActiveQuery)
    {
        var request = new SearchContactsRequest
        {
            NameQuery = nameQuery,
            TelQuery = telQuery,
            FromQuery = fromQuery,
            ToQuery = toQuery,
            IsActiveQuery = isActiveQuery
        };

        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("api/Contacts/Search", content);
        
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var contacts = JsonConvert.DeserializeObject<List<ContactModel>>(jsonResponse);

        return contacts;
    }

    public async Task CreateContactAsync(ContactModel contact)
    {
        var request = new CreateContactRequest
        {
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            IsActive = contact.IsActive,
            BirthDate = contact.BirthDate,
            Email = contact.Email,
            TelephoneNumber = contact.TelephoneNumber,
        };

        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await _httpClient.PutAsync("api/Contacts", content);
    }

    public async Task UpdateContactAsync(ContactModel contact)
    {
        var request = new UpdateContactRequest
        {
            Contact = contact
        };

        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await _httpClient.PostAsync("api/Contacts", content);
    }
}