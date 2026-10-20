
Inventory inventory = new();
inventory.addProduct("laptop", 2, 34);
inventory.addProduct("iphone", 3, 44);
inventory.addProduct("camera", 2, 34);
displayAllProducts();


void DisplayAllProducts()
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
void HandleEditProduct()
{

}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();