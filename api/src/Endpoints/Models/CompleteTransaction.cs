namespace StoreFront.Endpoints.Models;

public record CompleteTransaction(
    int UserID,
    int PurchaseID,
    string ProductName,
    decimal Price,
    int Quantity
);