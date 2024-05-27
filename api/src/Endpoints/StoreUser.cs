using Microsoft.EntityFrameworkCore;
using StoreFront.DataAccess;
using StoreFront.DataAccess.Models;
using StoreFront.Endpoints.Models;

namespace StoreFront.Endpoints;
static class StoreUser
{
    public static async Task<IResult> GetAllUsers(StoreContext db)
        => TypedResults.Ok(await db.Users.Select(u => new RegisteredUser(u.UserID, u.Username)).ToArrayAsync());
    public static async Task<IResult> GetUserById(int id, StoreContext db)
        => await db.Users.FindAsync(id) is User user ?
            TypedResults.Ok(new RegisteredUser(user.UserID, user.Username))
            : TypedResults.NotFound();
    public static async Task<IResult> DeleteUserById(int id, StoreContext db)
    {
        var user = await db.Users.FindAsync(id);
        if (user is null)
        {
            return TypedResults.NotFound();
        }
        db.Users.Remove(user);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }
    public static async Task<IResult> DeleteAllUsers(StoreContext db)
    {
        var users = await db.Users.ToArrayAsync();
        db.Users.RemoveRange(users);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }
}