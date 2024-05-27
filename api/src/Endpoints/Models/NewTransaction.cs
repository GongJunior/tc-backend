namespace StoreFront.Endpoints.Models;
record NewTransaction(
    string? UserName,
    string ProductName,
    int Quantity,
    decimal Price
);