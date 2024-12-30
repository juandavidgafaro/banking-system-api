namespace BankingSystem.Domain.Enums;
public class ProductStatus : Enumeration
{
    private const string _STATUS_INVALID_ERROR_MESSAGE = "El estado del producto no es valido.";

    public static ProductStatus Canceled = new ProductStatus(0, "Cancelado");
    public static ProductStatus Active = new ProductStatus(1, "Activo");

    public ProductStatus(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<ProductStatus> List()
    {
        return new[]
        {
            Canceled,
            Active
        };
    }

    public static ProductStatus FromName(string name)
    {
        var status = List().SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (status == null)
        {
            throw new DomainException(_STATUS_INVALID_ERROR_MESSAGE);
        }

        return status;
    }

    public static ProductStatus FromId(int id)
    {
        var status = List().SingleOrDefault(s => s.Id == id);

        if (status == null)
        {
            throw new DomainException(_STATUS_INVALID_ERROR_MESSAGE);
        }

        return status;
    }
}
