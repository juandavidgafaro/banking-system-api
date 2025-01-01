namespace BankingSystem.Infrastructure.Repositories;
public class LegalRepresentativeRepository : SqlServerBase<LegalRepresentativeEntity>, ILegalRepresentative
{
    public LegalRepresentativeRepository(IOptions<InfrastructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }

    public async Task<LegalRepresentativeDomainEntity> Create(LegalRepresentativeDomainEntity legalRepresentative)
    {
        string sql = sqlstatements.insert_legal_representative;

        try
        {
            LegalRepresentativeEntity insertionResult = await SingleInsert<LegalRepresentativeEntity>(sql, new
            {
                legalRepresentative.Name,
                legalRepresentative.IdentificationNumber,
                legalRepresentative.IdentificationType,
                legalRepresentative.Phone
            });

            return insertionResult;
        }
        catch (Exception ex)
        {
            throw new InfrastructureException($"Error al intentar crear el representante legal con numero de identificación: {legalRepresentative.IdentificationNumber}, detalle:{ex.Message}");
        }
    }
}