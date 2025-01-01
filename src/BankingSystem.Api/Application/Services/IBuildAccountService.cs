namespace BankingSystem.Api.Application.Services;
public interface IBuildAccountService
{
    AccountDomainEntity BuildByProductType(string productType, (double Balance, int TermMonth) initialData);
}