using System;
public class Product
{
	public string Name { get; 
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Name must be provided and not white spaces");
			}
			field = value.Trim();
		}
			
	} = string.Empty;

	public int Quantity { get;
		set
		{ 
			if (value < 0)
				{
				throw new ArgumentOutOfRangeException(nameof(value), "Quantity must be greater or equal than zero");
				}
			field = value;
		}
	}

	public decimal Price { get;
		set
		{
			if (value < 0)
				{
				throw new ArgumentOutOfRangeException(nameof(value), "Price must be greater or equal than zero");
				}
			field = value;
		} 
	}

    public Product(string name,int quantity,decimal price)
	{
		Name= name;
		Price = price;
		Quantity = quantity;
	}
	public override string ToString() {
		return $" Product: Name: {Name} | Price: {Price:C} | Quantity: {Quantity} ";
	}
}