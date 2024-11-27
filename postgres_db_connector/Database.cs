using Npgsql;

namespace postgres_db_connector;

public class Database
{
    private readonly string _host = "localhost";
    private readonly string _port = "5544"; // Default port brukar vara 5432
    private readonly string _username = "postgres";
    private readonly string _password = "abc123";
    private readonly string _database = "postgres_connector";
    private readonly string _schema = "";

    private NpgsqlDataSource _connection;

    public NpgsqlDataSource Connection()
    {
        return _connection;
    }

    public Database()
    {
        _connection = NpgsqlDataSource.Create($"Host={_host};Port={_port};Username={_username};Password={_password};Database={_database}");

        using var conn = _connection.OpenConnection();
    }
}