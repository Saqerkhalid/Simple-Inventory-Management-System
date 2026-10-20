
Inventory inventory = new();
inventory.addProduct("laptop", 2, 34);
inventory.addProduct("iphone", 3, 44);
inventory.addProduct("camera", 2, 34);
DisplayAllProducts();


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
    Console.Write("Enter product name you want to edit: ");
    string? searchName = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(searchName))
    {
        Console.Write("Name cannot be empty. Please enter a valid name: ");
        searchName = Console.ReadLine();
    }

    Product? product = inventory.getProductByName(searchName);
    if (product == null)
    {
        Console.WriteLine("No product found with this name.");
        return;
    }

    Console.WriteLine("\nCurrent Product Details:");
    Console.WriteLine(product);
    Console.WriteLine("\n(Press Enter to keep the original value for any field)\n");

    // 1. New Name
    Console.Write($"Enter new Name (current: {product.Name}): ");
    string? nameInput = Console.ReadLine();
    string finalName = string.IsNullOrWhiteSpace(nameInput)
        ? product.Name
        : nameInput.Trim();

    // 2. New Quantity
    Console.Write($"Enter new Quantity (current: {product.Quantity}): ");
    string? quantityInput = Console.ReadLine();
    int finalQuantity = product.Quantity;

    if (!string.IsNullOrWhiteSpace(quantityInput))
    {
        while (!int.TryParse(quantityInput, out finalQuantity) || finalQuantity < 0)
        {
            Console.Write("Invalid quantity! Enter a non-negative number: ");
            quantityInput = Console.ReadLine();
        }
    }

    // 3. New Price
    Console.Write($"Enter new Price (current: {product.Price}): ");
    string? priceInput = Console.ReadLine();
    decimal finalPrice = product.Price;

    if (!string.IsNullOrWhiteSpace(priceInput))
    {
        while (!decimal.TryParse(priceInput, out finalPrice) || finalPrice < 0)
        {
            Console.Write("Invalid price! Enter a positive decimal number: ");
            priceInput = Console.ReadLine();
        }
    }

    // 4. Update via Inventory
    Product? Updated = inventory.EditProduct(searchName, finalName, finalQuantity, finalPrice);
    if (Updated !=null)
    {
        Console.WriteLine("\nProduct updated successfully!\n"+Updated);
    }
    else
    {
        Console.WriteLine("\nUpdate failed: The new product name already exists in inventory.");
    }
}
void HanldeDelete()
{
    Console.WriteLine("Enter product name you want to delete");
    string nameInput = Console.ReadLine();
    if (nameInput.Trim() == null)
    {
        Console.WriteLine("empty name !");
        return;
    }
    if (inventory.getProductByName(nameInput) == null)
    {
        Console.WriteLine("product with this name not found !");
        return;
    }
    bool isDeleted= inventory.DeleteProduct(nameInput);
    if (isDeleted) {
        Console.WriteLine("deleted succesfully");
    }
    else
    {
        Console.WriteLine("error while delete");

    }
}
void HandleSerach()
{
    Console.WriteLine("Enter product name you want to search");
    string nameInput = Console.ReadLine();
    if (nameInput.Trim() == null)
    {
        Console.WriteLine("empty name!");
        return;
    }
    if (inventory.getProductByName(nameInput) == null)
    {
        Console.WriteLine("product with this name not found !");
        return;
    }else
    {
        Console.WriteLine(inventory.getProductByName(nameInput));
    }
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();