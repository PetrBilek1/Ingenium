namespace Ingenium.WebAPI.Contracts.Requests;

public sealed class SearchContactsRequest
{
    public string? NameQuery { get; set; }
    public string? TelQuery { get; set; }
    public DateTime? FromQuery { get; set; }
    public DateTime? ToQuery { get; set; }
    public bool? IsActiveQuery { get; set; }
}