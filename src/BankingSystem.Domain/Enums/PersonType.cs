namespace BankingSystem.Domain.Enums;
public class PersonType : Enumeration
{
    private const string _STATUS_INVALID_ERROR_MESSAGE = "El tipo del cliente no es valido.";

    public static PersonType Personal = new PersonType(0, "Persona");
    public static PersonType Business = new PersonType(1, "Empresarial");

    public PersonType(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<PersonType> List()
    {
        return new[]
        {
            Personal,
            Business
        };
    }

    public static PersonType FromName(string name)
    {
        var type = List().SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (type == null)
        {
            throw new DomainException(_STATUS_INVALID_ERROR_MESSAGE);
        }

        return type;
    }

    public static PersonType FromId(int id)
    {
        var type = List().SingleOrDefault(s => s.Id == id);

        if (type == null)
        {
            throw new DomainException(_STATUS_INVALID_ERROR_MESSAGE);
        }

        return type;
    }
}