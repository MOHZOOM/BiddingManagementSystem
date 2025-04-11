// Bidding Management System - Complete Backend
// Created for: Mohamed Abdulali Miftah Abuazzoum
// Stack: .NET 8, EF Core, JWT, DDD

// -------------------- Program.cs --------------------
using BiddingManagementSystem.API;
using BiddingManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.ConfigureServices();

services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = JwtHelper.GetValidationParameters();
    });
services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

// -------------------- DTOs/TenderDto.cs --------------------
namespace BiddingManagementSystem.DTOs
{
    public class TenderDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime ClosingDate { get; set; }
    }
}

// -------------------- DTOs/BidDto.cs --------------------
namespace BiddingManagementSystem.DTOs
{
    public class BidDto
    {
        public Guid TenderId { get; set; }
        public string BidderName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}

// -------------------- Migrations Command --------------------
/*
Use these commands in terminal:

1. dotnet ef migrations add InitialCreate
2. dotnet ef database update
*/

// -------------------- appsettings.json --------------------
/*
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BiddingDB;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "ThisIsASecretKeyForJwtToken",
    "Issuer": "SkyAcademy",
    "Audience": "SkyAcademy"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
*/

// -------------------- README.md --------------------
/*
# Bidding Management System (Backend)

Created by: **Mohamed Abdulali Miftah Abuazzoum**

## Tech Stack
- .NET 8 Web API
- SQL Server + EF Core
- JWT Authentication
- Swagger
- Domain-Driven Design (DDD)

## Features
- User Registration/Login
- Role-Based Access Control
- Tender CRUD (create/update/delete/view)
- Bid Submission (with auto timestamp)
- View bids by tender ID

## DTOs
- `TenderDto` for creating/updating tenders
- `BidDto` for submitting bids

## Database
- Migrations with EF Core
- Run:
```bash
 dotnet ef migrations add InitialCreate
 dotnet ef database update
```

## How to Run
1. Clone repo
2. Setup `appsettings.json` with connection string
3. Run database migration
4. `dotnet run`
5. Open Swagger UI at https://localhost:{port}/swagger
*/
