namespace BankingSystem.Api.Application.Handlers;

public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientQueryResponseDTO>
{
    private readonly IClientRepository _clientRepository;

    public GetClientByIdHandler(IClientRepository clientInfrastructureRepository)
    {
        _clientRepository = clientInfrastructureRepository;
    }

    public async Task<ClientQueryResponseDTO> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var clientEntity = await _clientRepository.GetClientById(request.Id);

        if (clientEntity == default)
        {
            throw new NotFoundException(string.Format("El cliente con Id {0} no existe.", request.Id));
        }

        return new ClientQueryResponseDTO()
        {
            ClientId = clientEntity.Id,
            Name = clientEntity.Name,
            IdentificationNumber = clientEntity.IdentificationNumber,
            IdentificationType = clientEntity.IdentificationType,
            PersonType = clientEntity.PersonType,
            LegalRepresentativeId = clientEntity.LegalRepresentativeId,
        };
    }
}
