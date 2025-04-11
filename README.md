# BiddingManagementSystem
Sky Academy Final Project - Mohamed Abdulali Miftah Abuazzoum
## Tech Stack
- .NET 8 Web API
- SQL Server + EF Core
- JWT Authentication
- Swagger for API Documentation
- Domain-Driven Design (DDD)

## Features
- **User Registration/Login**: Allows users to register and log in.
- **Role-Based Access Control**: Secure endpoints based on user roles.
- **Tender Management**: CRUD operations for tenders (create, update, delete, view).
- **Bid Submission**: Allows users to submit bids, with automatic timestamps.
- **Bid Viewing**: View bids submitted for a specific tender using the tender ID.

## API Endpoints
- **POST /tenders**: Create a new tender (requires authentication).
- **GET /tenders/{id}**: Get a specific tender by ID.
- **PUT /tenders/{id}**: Update a tender by ID (requires authentication).
- **DELETE /tenders/{id}**: Delete a tender by ID (requires authentication).
- **POST /bids**: Submit a bid for a specific tender (requires authentication).
- **GET /bids/{tenderId}**: View all bids for a specific tender.

## DTOs
- **TenderDto**: Used for creating/updating tenders. Contains the following properties:
  - `Title`: The title of the tender.
  - `Description`: The description of the tender.
  - `Budget`: The budget allocated for the tender.
  - `Category`: The category of the tender.
  - `ClosingDate`: The closing date for the tender submission.

- **BidDto**: Used for submitting bids. Contains the following properties:
  - `TenderId`: The ID of the tender being bid on.
  - `BidderName`: The name of the bidder.
  - `Amount`: The amount bid.

## Database
- **Migrations**: This project uses EF Core for database management.
  - To add an initial migration:
    ```bash
    dotnet ef migrations add InitialCreate
    ```
  - To apply the migration and update the database:
    ```bash
    dotnet ef database update
    ```
