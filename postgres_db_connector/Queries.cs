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
        await using (var cmd = _database.CreateCommand("SELECT * FROM items")) // Skapa vårt kommand/query
        await using (var reader = await cmd.ExecuteReaderAsync()) // Kör vår kommando/query och inväntar resultatet.
        while ( await reader.ReadAsync()) // Läser av 1 rad/objekt i taget ifrån resultatet och kommer avsluta loopen när det inte finns fler rader att läsa. 
        {
            Console.WriteLine($"Id: {reader.GetInt32(0)}, " +
                              $"Name: {reader.GetString(1)}," +
                              $"Price: {reader.GetDouble(2)}," +
                              $"Stock: {reader.GetInt32(3)}");
        }
    }

    public async void OneItemById(string id)
    {
        await using (var cmd = _database.CreateCommand($"SELECT * FROM items WHERE id = {id}"))
        await using (var reader = await cmd.ExecuteReaderAsync())
            
            while ( await reader.ReadAsync())
            {
                Console.WriteLine(reader.GetDataTypeName(0));
                Console.WriteLine($"Id: {reader.GetInt32(0)}, " +
                                  $"Name: {reader.GetString(1)}," +
                                  $"Price: {reader.GetDouble(2)}," +
                                  $"Stock: {reader.GetInt32(3)}");
            }        
    }
    
    public async void AllItemWithoutId()
    {
        await using (var cmd = _database.CreateCommand("SELECT * FROM items_without_id")) // items_without_id - är en view
        await using (var reader = await cmd.ExecuteReaderAsync())
            while ( await reader.ReadAsync()) 
            {
                Console.WriteLine($"Name: {reader.GetString(0)}," +
                                  $"Price: {reader.GetDouble(1)}," +
                                  $"Stock: {reader.GetInt32(2)}");
            }
    }
    
}