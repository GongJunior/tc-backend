using Microsoft.EntityFrameworkCore;
using StoreFront.Endpoints.Models;
using StoreFront.DataAccess;
using StoreFront.DataAccess.Models;

namespace StoreFront.Endpoints;
class StoreTransaction
{
    private static readonly string _endpoint = "transactions";
    public static async Task<IResult> AddUserTransaction(int id, NewTransaction transaction, StoreContext db)
    {
        var user = await db.Users.FindAsync(id);
        if (user is null)
        {
            return TypedResults.NotFound();
        }

        var purchase = new Purchase
        {
            ProductName = transaction.ProductName,
            Price = transaction.Price,
            Quantity = transaction.Quantity
        };
        user.Purchases.Add(purchase);
        await db.SaveChangesAsync();
        return TypedResults.Created(
            $"/{_endpoint}/{purchase.PurchaseID}",
            new CompleteTransaction(user.UserID, purchase.PurchaseID, purchase.ProductName, purchase.Price, purchase.Quantity)
            );
    }

    public static async Task<IResult> AddNewUserTransaction(NewTransaction transaction, StoreContext db, ILogger<StoreTransaction> logger)
    {
        logger.LogInformation("HELLO WORLD!!!!");
        var newUser = new User() { Username = transaction.UserName ?? "DefaultUserName" };
        await db.Users.AddAsync(newUser);
        var purchase = new Purchase
        {
            ProductName = transaction.ProductName,
            Price = transaction.Price,
            Quantity = transaction.Quantity
        };
        newUser.Purchases.Add(purchase);
        await db.SaveChangesAsync();
        return TypedResults.Created(
            $"/{_endpoint}/{purchase.PurchaseID}",
            new CompleteTransaction(newUser.UserID, purchase.PurchaseID, purchase.ProductName, purchase.Price, purchase.Quantity)
            );
    }

    public static async Task<IResult> GetAllTransactions(StoreContext db)
        => TypedResults.Ok(await db.Purchases.Select(p => new CompleteTransaction(p.UserID, p.PurchaseID, p.ProductName, p.Price, p.Quantity)).ToArrayAsync());

    public static async Task<IResult> GetTransactionById(int id, StoreContext db)
        => await db.Purchases.FindAsync(id) is Purchase purchase ?
            TypedResults.Ok(new CompleteTransaction(purchase.UserID, purchase.PurchaseID, purchase.ProductName, purchase.Price, purchase.Quantity))
            : TypedResults.NotFound();
    public static async Task<IResult> GetAllUserTransactions(int id, StoreContext db)
    {
        var user = await db.Users.Include(u => u.Purchases).Where(u => u.UserID == id).SingleAsync();
        if (user is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(user.Purchases.Select(p => new CompleteTransaction(p.UserID, p.PurchaseID, p.ProductName, p.Price, p.Quantity)).ToArray());
    }
    public static async Task<IResult> DeleteTransactionById(int id, StoreContext db)
    {
        var purchase = await db.Purchases.FindAsync(id);
        if (purchase is null)
        {
            return TypedResults.NotFound();
        }
        db.Purchases.Remove(purchase);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }
    public static async Task<IResult> DeleteAllTransactions(StoreContext db)
    {
        var purchases = await db.Purchases.ToArrayAsync();
        db.Purchases.RemoveRange(purchases);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }
}