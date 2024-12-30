namespace BankingSystem.Infrastructure.Repositories;
public class LegalRepresentativeRepository : SqlServerBase<LegalRepresentativeEntity>, ILegalRepresentativeRepository
{
    public LegalRepresentativeRepository(IOptions<InfraestructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }


    public async Task Create(LegalRepresentativeDomainEntity legalRepresentative)
    {

    }
}