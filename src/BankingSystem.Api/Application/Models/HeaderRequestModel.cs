namespace BankingSystem.Api.Application.Models;

public record HeaderRequestModel
{
    [FromHeader(Name = "source")]
    public required string Source { get; set; }

}
