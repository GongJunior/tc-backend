using StoreFront.Endpoints;

namespace StoreFront.Extensions;

static class Endpoint
{
    public static void AddTransactionEndpoints(this WebApplication app)
    {
        var transactions = app.MapGroup("/transactions").WithTags("Transactions").WithOpenApi();
        transactions.MapPost("/", StoreTransaction.AddNewUserTransaction);
        transactions.MapPost("/{id:int}", StoreTransaction.AddUserTransaction);
        transactions.MapGet("/", StoreTransaction.GetAllTransactions);
        transactions.MapGet("/{id:int}", StoreTransaction.GetTransactionById);
        transactions.MapGet("/user/{id:int}", StoreTransaction.GetAllUserTransactions);
        transactions.MapDelete("/", StoreTransaction.DeleteAllTransactions);
        transactions.MapDelete("/{id:int}", StoreTransaction.DeleteTransactionById);
    }

    public static void AddUserEndpoints(this WebApplication app)
    {
        var users = app.MapGroup("/users").WithTags("Users").WithOpenApi();
        users.MapGet("/", StoreUser.GetAllUsers);
        users.MapGet("/{id:int}", StoreUser.GetUserById);
        users.MapDelete("/", StoreUser.DeleteAllUsers);
        users.MapDelete("/{id:int}", StoreUser.DeleteUserById);
    }
}