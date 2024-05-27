namespace StoreFront.DataAccess.Models;
class Purchase
{
    public int PurchaseID { get; set; }
    public required string ProductName { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public int UserID { get; set; }
    public User User { get; set; } = null!;
}