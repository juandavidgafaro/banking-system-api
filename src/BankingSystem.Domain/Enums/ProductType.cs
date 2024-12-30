namespace BankingSystem.Domain.Enums;
public class ProductType : Enumeration
{
    private const string _INVALID_TYPE_ERROR_MESSAGE = "El tipo del producto no es valido.";

    public static ProductType SavingsAccount = new ProductType(1, "Cuenta ahorros");
    public static ProductType CheckingAccount = new ProductType(2, "Cuenta corriente");
    public static ProductType CertificateOfDeposit = new ProductType(3, "CDT");

    public ProductType(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<ProductType> List()
    {
        return new[]
        {
            SavingsAccount,
            CheckingAccount,
            CertificateOfDeposit
        };
    }

    public static ProductType FromName(string name)
    {
        var type = List().SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (type == null)
        {
            throw new DomainException(_INVALID_TYPE_ERROR_MESSAGE);
        }

        return type;
    }

    public static ProductType FromId(int id)
    {
        var type = List().SingleOrDefault(s => s.Id == id);

        if (type == null)
        {
            throw new DomainException(_INVALID_TYPE_ERROR_MESSAGE);
        }

        return type;
    }
}
