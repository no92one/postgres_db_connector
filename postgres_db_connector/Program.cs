namespace postgres_db_connector;

class Program
{
    static void Main(string[] args)
    {
        Database db = new();

        Queries queries = new(db.Connection());
        
        // queries.AllItems();

        while (true)
        {   
            Console.WriteLine("Skriv in ett id: ");
            String id = Console.ReadLine();
            queries.OneItemById(id);
        }
        
        // queries.AllItemWithoutId();
    }
}