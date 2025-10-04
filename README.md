# CardHub => Overview
CardHub is a modular ASP.NET Core 9.0 solution designed with Clean Architecture principles.
The project is structured into multiple layers to ensure scalability, maintainability, and separation of concerns.
Currently, the MVC layer (CardHub.WebApp) is scaffolded but not yet populated with controllers, views, or UI logic.
The focus so far has been on setting up the domain model, infrastructure, and database migrations.

🏗️ Project Structure
CardHub
 ┣ ApplicationLayer        → Business rules, service interfaces
 ┣ DomainLayer             → Core entities and domain logic
 ┣ InfrastructureLayer     → EF Core DbContext, repositories, migrations
 ┣ CardHub.WebApp          → ASP.NET Core MVC (UI layer, not yet implemented)
 ┗ CardHub.sln             → Solution file



🔑 Key Features (Planned)
- Domain-driven design with clear separation of layers
- Entity Framework Core 9.0 for data access
- Code-First Migrations (already working)
- MVC UI (to be implemented) for managing credit cards and payments
- Scalable architecture ready for modular extensions

🚀 Getting Started
Prerequisites
- .NET 9.0 SDK
- SQL Server (or another supported database)
- Visual Studio 2022 / VS Code
Setup
- Clone the repository
- Set CardHub.WebApp as the startup project
- Apply migrations:
Update-Database -StartupProject CardHub.WebApp -Project InfrastructureLayer
- Run the application

📌 Current Status
- ✅ Solution and layered architecture created
- ✅ AppDbContext configured in InfrastructureLayer
- ✅ Initial migration applied → database and CreditCards table created
- ⏳ MVC controllers, views, and UI logic not yet implemented

🛠️ Next Steps
- Add MVC controllers and views for CreditCards
- Implement validation and ViewModels
- Introduce services in ApplicationLayer
- Expand domain with Payments, Transactions, etc.

📄 License
This project is for educational and development purposes.
