namespace BankingSystem.Api.Application.Services.Implementations;
public interface IBuildAccountService
{
    AccountDomainEntity BuildByProductType(string productType, (double Balance, int TermMonth) initialData);
}