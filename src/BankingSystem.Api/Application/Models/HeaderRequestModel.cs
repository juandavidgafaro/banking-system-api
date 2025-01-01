namespace BankingSystem.Api.Application.Models;

public class HeaderRequestModel
{
    [FromHeader(Name = "user")]
    public required string User { get; set; }

    [FromHeader(Name = "source")]
    public required string Source { get; set; }
}