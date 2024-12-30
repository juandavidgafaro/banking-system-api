namespace BankingSystem.Domain.Enums;
public class TransactionType : Enumeration
{
    private const string _TRANSACTION_TYPE_INVALID_ERROR_MESSAGE = "El tipo de transacción no es valida.";

    public static TransactionType Create = new TransactionType(0, "Crear");
    public static TransactionType Deposit = new TransactionType(1, "Depositar");
    public static TransactionType Withdraw = new TransactionType(2, "Retirar");
    public static TransactionType Cancel = new TransactionType(3, "Cancelar");

    public TransactionType(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<TransactionType> List()
    {
        return new[]
        {
            Deposit,
            Withdraw,
            Cancel
        };
    }

    public static TransactionType FromName(string name)
    {
        var type = List().SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (type == null)
        {
            throw new DomainException(_TRANSACTION_TYPE_INVALID_ERROR_MESSAGE);
        }

        return type;
    }

    public static TransactionType FromId(int id)
    {
        var type = List().SingleOrDefault(s => s.Id == id);

        if (type == null)
        {
            throw new DomainException(_TRANSACTION_TYPE_INVALID_ERROR_MESSAGE);
        }

        return type;
    }
}