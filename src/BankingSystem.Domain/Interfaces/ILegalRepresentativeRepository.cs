namespace BankingSystem.Domain.Interfaces;
public interface ILegalRepresentativeRepository
{
    Task<LegalRepresentativeDomainEntity> Create(LegalRepresentativeDomainEntity legalRepresentative);
}