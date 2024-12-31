namespace BankingSystem.Api.Application.Queries;

public record GetClientByIdQuery(int Id) : IRequest<ClientQueryResponseDTO>;