using System;

public class Inventory
{
	public readonly List<Product> Products = new();
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
    public IReadOnlyList<Product> getAllProducts()
    {
        return Products.AsReadOnly();
    }
    public Product? getProductByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }
        return Products.FirstOrDefault(Products => Products.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));  
    }
    public Product? EditProduct(string searchName,string finalName,int finalQuantity,decimal finalPrice)
    {
        Product? product = getProductByName(searchName);
        if (product == null)
        {
            return null;
        }
        bool isNameChanged = !product.Name.Equals(finalName, StringComparison.OrdinalIgnoreCase);
        if (isNameChanged)
        {
            bool isNameAlreadyTaken = Products.Any(p =>
                p.Name.Equals(finalName, StringComparison.OrdinalIgnoreCase));

            if (isNameAlreadyTaken)
            {
                return null;
            }
        }
        product.Name = finalName;
        product.Quantity = finalQuantity;
        product.Price = finalPrice;
        return product;
    }
}
