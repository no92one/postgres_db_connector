namespace postgres_db_connector;

class Program
{
    static void Main(string[] args)
    {
        Database db = new();

        Queries queries = new(db.Connection());
        
        // queries.AllItems();

        // while (true)
        // {   
        //     Console.WriteLine("Skriv in ett id: ");
        //     String id = Console.ReadLine();
        //     queries.OneItemById(id);
        // }
        
        // queries.AllItemWithoutId();
        
        // String name = Console.ReadLine();
        // double price = Convert.ToDouble(Console.ReadLine());
        // int stock = Convert.ToInt32(Console.ReadLine());
        // queries.AddItem(name, price, stock);

        // Console.WriteLine("id: ");    
        // int id = Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine("name: ");    
        // String name = Console.ReadLine();
        // Console.WriteLine("price: ");    
        // double price = Convert.ToDouble(Console.ReadLine());
        // Console.WriteLine("stock: ");    
        // int stock = Convert.ToInt32(Console.ReadLine());
        //
        // queries.UpdateItem(id, name, price, stock);
        
        Console.WriteLine("id: ");    
        int id = Convert.ToInt32(Console.ReadLine());
        
        queries.DeleteItem(id);
        
    }
}