using Npgsql;

namespace postgres_db_connector;

public class Queries
{
    private NpgsqlDataSource _database;

    public Queries(NpgsqlDataSource database)
    {
        _database = database;
    }

    public async void AllItems()
    {
        await using (var cmd = _database.CreateCommand("SELECT * FROM items"))
        await using (var reader = await cmd.ExecuteReaderAsync())
        while ( await reader.ReadAsync())
        {
            Console.WriteLine($"Id: {reader.GetInt32(0)}, " +
                              $"Name: {reader.GetString(1)}," +
                              $"Price: {reader.GetDouble(2)}," +
                              $"Stock: {reader.GetInt32(3)}");
        }
    }
    
}