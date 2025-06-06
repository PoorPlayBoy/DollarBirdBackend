namespace backend.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public decimal PriceUSD { get; set; }
    public decimal PriceZAR { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public Category Category { get; set; }
}
