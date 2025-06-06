namespace backend.Models;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public Product Product { get; set; }
}
