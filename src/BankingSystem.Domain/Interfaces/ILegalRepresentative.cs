namespace BankingSystem.Domain.Interfaces;
public interface ILegalRepresentative
{
    Task<LegalRepresentativeDomainEntity> Create(LegalRepresentativeDomainEntity legalRepresentative);
}