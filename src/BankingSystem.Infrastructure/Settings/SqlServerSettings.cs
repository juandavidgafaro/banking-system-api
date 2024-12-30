namespace BankingSystem.Infrastructure.Settings;

public class SqlServerSettings
{
    public required ConnectionStrings ConnectionStrings { get; set; }
}

public class ConnectionStrings
{
    public required string BankingSystemDataServer { get; set; }
}