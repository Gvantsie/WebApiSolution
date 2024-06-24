namespace Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
    public int CategoryId { get; set; }  
    public decimal Price { get; set; }   

    public Category Category { get; set; } = new Category();
}