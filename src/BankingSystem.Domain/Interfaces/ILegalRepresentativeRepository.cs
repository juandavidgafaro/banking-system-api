namespace BankingSystem.Domain.Interfaces;
public interface ILegalRepresentativeRepository
{
    Task Create(LegalRepresentativeDomainEntity legalRepresentative);
}