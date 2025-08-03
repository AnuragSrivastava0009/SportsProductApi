# SportsProductApi

**SportsProductApi** is an ASP.NET Core Web API for managing sports-related products such as cricket bats, shoes, rackets, etc. The API provides basic CRUD operations along with stock management features.

## Technologies Used

- ASP.NET Core 6/7
- C#
- Entity Framework Core (in-memory or DB based)
- Swagger (OpenAPI)
- Visual Studio 2022

---

##  Getting Started

### Prerequisites

- [.NET 6/7 SDK](https://dotnet.microsoft.com/en-us/download)
- Visual Studio 2022 (or any IDE of your choice)
- Git

### Steps to Run Locally

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/SportsProductApi.git
   cd SportsProductApi

Restore dependencies
 - dotnet restore

Run the application
 - dotnet run

Open in browser
Visit: https://localhost:7193/swagger

API Endpoints
Method	    Endpoint	                                       Description
GET	        /api/products	                                   Get all products
GET	        /api/products/{id}	                             Get product by ID
POST	      /api/products	                                   Add new product
PUT	        /api/products/{id}	                             Update product
DELETE	    /api/products/{id}	                             Delete product
PUT	        /api/products/decrement-stock/{id}/{quantity}    Decrease stock
PUT	        /api/products/add-to-stock/{id}/{quantity}	     Increase stock

Sample Product JSON
{
  "name": "Cricket Bat",
  "price": 2499,
  "stockAvailable": 20,
  "description": "Kookaburra English Willow",
  "category": "Cricket",
  "brand": "SG",
  "player": "Virat Kohli"
}

Testing API (Using Bruno)
 - Base URL: https://localhost:7193
 - Accept SSL certificate warning (if prompted)
 - Set Content-Type: application/json
 - Use correct method (GET, POST, PUT, DELETE) and endpoint

Folder Structure

SportsProductApi/
│
├── Controllers/
│   └── ProductsController.cs
│
├── Models/
│   └── Product.cs
│
├── Services/
│   └── ProductService.cs
│
├── Program.cs
└── Startup.cs (if applicable)

Unit Tests
- Unit test classes are created using xUnit and cover the product service layer.

Author
Anurag Srivastava
Built with using Visual Studio 2022

