namespace BankingSystem.Api.Application.DTOs;

public record BadRequestResponseDTO
{
    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("traceId")]
    public string? TraceId { get; set; }

    [JsonProperty("errors")]
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}
