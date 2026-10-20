using System;

public class Inventory
{
	public List<Product> Products { get;} = new();
	public Inventory()
	{
	}

    public Product addProduct(string name, int quantity, decimal price)
    {
        if (Products.Any(product => product.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            throw new Exception("Product already exists");
        Product newProduct = new Product(name, quantity, price);
        Products.Add(newProduct);
        return newProduct;
    }
}
