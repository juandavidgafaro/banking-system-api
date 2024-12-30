namespace BankingSystem.Api.Application.Models;

public class HeaderRequestModel
{
    [FromHeader(Name = "user")]
    public string User { get; set; }

    [FromHeader(Name = "source")]
    public string Source { get; set; }
}