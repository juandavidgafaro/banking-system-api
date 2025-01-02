namespace BankingSystem.Domain.Enums;
public class Country : Enumeration
{
    private const string _COUNTRY_INVALID_ERROR_MESSAGE = "El país no es valido.";

    public static Country Colombia = new Country(1, "Colombia");

    public Country(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<Country> List()
    {
        return new[]
        {
            Colombia,
        };
    }

    public static Country FromName(string name)
    {
        var country = List().SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (country == null)
        {
            throw new DomainException(_COUNTRY_INVALID_ERROR_MESSAGE);
        }

        return country;
    }

    public static Country FromId(int id)
    {
        var country = List().SingleOrDefault(s => s.Id == id);

        if (country == null)
        {
            throw new DomainException(_COUNTRY_INVALID_ERROR_MESSAGE);
        }

        return country;
    }
}