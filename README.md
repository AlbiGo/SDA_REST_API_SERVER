A simple .NET Core-based REST API for managing an online shopping system. This API allows users to add items to their shopping cart, calculate the total of their cart, and perform other e-commerce-related operations.

Features
Add products to a shopping cart.
Recalculate the total price of the cart based on the items added.
Simple interaction with the database using Entity Framework Core.
Technologies Used
.NET Core 6.0+: The backend framework for building the API.
Entity Framework Core: For database interaction and ORM.
SQL Server: Assumed as the database (though other databases like MySQL or PostgreSQL can be used).
Setup
Prerequisites
Before setting up the project, make sure you have the following installed:

.NET 6.0 SDK or higher
A SQL database (e.g., SQL Server, SQLite) for data storage.
Installation
Clone the repository:

bash
Copy
git clone https://github.com/AlbiGo/SDA_REST_API_SERVER.git
cd SDA_REST_API_SERVER
Install dependencies:

bash
Copy
dotnet restore
Set up your database connection in appsettings.json (located in the root of the project) under the ConnectionStrings section.

Run database migrations (if any):

bash
Copy
dotnet ef database update
Run the API:

bash
Copy
dotnet run
The API should now be running locally.

Usage
Add Product to Cart
To add a product to the cart, send a POST request to /api/cart/add with the necessary product data. The userID must be provided, and the system will automatically check if the user already has an active cart.

Recalculate Cart Total
After adding products to the cart, the system will automatically recalculate the total price for you. You can call the ReKalkuloTotalin method to manually trigger the total calculation.

Example Endpoints
POST /api/cart/add: Add an item to the cart.

Request Body:
json
Copy
{
  "fatura": {
    "Cmimi": 100,
    "Sasia": 2,
    "ArtikullID": 1
  },
  "userID": 123
}
GET /api/cart/total/{userID}: Get the total amount of the user's active cart.


