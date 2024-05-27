namespace StoreFront.DataAccess.Models;
class User
{
    public int UserID { get; set; }
    public string Username { get; set; } = "DefaultUserName";
    public List<Purchase> Purchases { get; } = [];
}