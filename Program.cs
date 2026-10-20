
Inventory inv1 = new();
inv1.addProduct("laptop", 2, 34);
inv1.addProduct("iphone", 3, 44);
inv1.addProduct("camera", 2, 34);
displayAllProducts(inv1);
Console.WriteLine(inv1.getAllProducts());



void displayAllProducts(Inventory inventory )
{
    var products= inventory.getAllProducts();
    if(!products.Any())
    {
        Console.WriteLine("Your inventory is empty");
        return;
    }
    Console.WriteLine("Inventory items : ");

    foreach (var product in products)
    {
        Console.WriteLine(product);
    }
    Console.WriteLine("---------------------------");



}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();