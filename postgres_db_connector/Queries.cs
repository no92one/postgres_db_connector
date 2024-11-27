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

    public async void AddItem(String name, double price, int stock)
    {
        await using (var cmd = _database.CreateCommand("INSERT INTO ITEMS (name, price, stock) " +
                                                       "VALUES ($1, $2, $3)"))
        {
            cmd.Parameters.AddWithValue(name); // $1 = name 
            cmd.Parameters.AddWithValue(price); // $2 = price 
            cmd.Parameters.AddWithValue(stock); // $3 = stock 
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async void UpdateItem(int id, String name, double price, int stock)
    {
        await using (var cmd = _database.CreateCommand("UPDATE items " +
                                                       "SET name = $1, price = $2, stock = $3 " +
                                                       " WHERE id = $4"))
        {
            cmd.Parameters.AddWithValue(name);
            cmd.Parameters.AddWithValue(price);
            cmd.Parameters.AddWithValue(stock);
            cmd.Parameters.AddWithValue(id);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async void DeleteItem(int id)
    {
        await using (var cmd = _database.CreateCommand("DELETE FROM items WHERE id = $1"))
        {
            cmd.Parameters.AddWithValue(id);
            int result = await cmd.ExecuteNonQueryAsync();
            Console.WriteLine(result);
        }
    }
    
}