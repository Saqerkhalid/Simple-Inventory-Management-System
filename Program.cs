
Inventory inventory = new();
inventory.addProduct("laptop", 2, 34);
inventory.addProduct("iphone", 3, 44);
inventory.addProduct("camera", 2, 34);
DisplayAllProducts();

bool isRunning = true;
while (isRunning)
{
    Console.Clear();
    Console.WriteLine("=====================================");
    Console.WriteLine("     INVENTORY MANAGEMENT SYSTEM     ");
    Console.WriteLine("=====================================");
    Console.WriteLine("1. View All Products");
    Console.WriteLine("2. Add New Product");
    Console.WriteLine("3. Edit Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Search Product");
    Console.WriteLine("0. Exit");
    Console.WriteLine("=====================================");
    Console.Write("Enter your choice: ");
    string? choice = Console.ReadLine()?.Trim();

    Console.WriteLine();

    try
    {
        switch (choice)
        {
            case "1":
                DisplayAllProducts();
                break;

            case "2":
                HandleAddProduct();
                break;

            case "3":
                HandleEditProduct();
                break;

            case "4":
                HanldeDelete();
                break;

            case "5":
                HandleSerach();
                break;

            case "0":
                Console.WriteLine("Exiting program... Goodbye!");
                isRunning = false;
                continue;

            default:
                Console.WriteLine("Invalid choice! Please select a valid number from the menu.");
                break;
        }
        Console.WriteLine("\nPress any key to return to main menu...");
        Console.ReadKey();
    }
    catch (Exception e) { Console.WriteLine(e.ToString()); }
    }

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
void HandleAddProduct()
{
    Console.WriteLine("--- Add New Product ---\n");

    Console.Write("Enter product name: ");
    string? name = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(name))
    {
        Console.Write("Name cannot be empty! Enter valid name: ");
        name = Console.ReadLine();
    }
    name = name.Trim();

    Console.Write("Enter quantity: ");
    string? quantityInput = Console.ReadLine();
    int quantity;
    while (!int.TryParse(quantityInput, out quantity) || quantity < 0)
    {
        Console.Write("Invalid quantity! Enter a non-negative integer: ");
        quantityInput = Console.ReadLine();
    }

    Console.Write("Enter price: ");
    string? priceInput = Console.ReadLine();
    decimal price;
    while (!decimal.TryParse(priceInput, out price) || price < 0)
    {
        Console.Write("Invalid price! Enter a positive decimal number: ");
        priceInput = Console.ReadLine();
    }

    try
    {
        Product created = inventory.addProduct(name, quantity, price);
        Console.WriteLine($"\nProduct '{created.Name}' added successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError: {ex.Message}");
    }
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
    if (string.IsNullOrWhiteSpace(nameInput))
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
    if (string.IsNullOrWhiteSpace(nameInput))
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