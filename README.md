# 🎓 Student Report Card API

A clean, scalable .NET 9 Web API to manage and retrieve student report cards. Built with **Clean Architecture**, **Entity Framework Core**, and **MediatR** — supporting both **PostgreSQL** and **SQL Server** databases.

---

## 🏗️ Architecture

This project follows the **Clean Architecture** pattern with the following structure:

├── Domain // Core entities
├── Application // DTOs, Interfaces, CQRS (MediatR)
├── Infrastructure // EF Core DbContext, DB configurations
├── WebAPI // Controllers, Swagger, Dependency Injection


---

## 🔧 Technologies Used

- **.NET 8**
- **Entity Framework Core**
- **PostgreSQL** & **SQL Server** (switchable via config)
- **MediatR** for CQRS
- **Swagger / Swashbuckle**
- **Clean Architecture principles**

---

## ⚙️ Setup Instructions

### 🔁 1. Clone the Repository

```bash
cd student-report-card-api

🛠️ 2. Update Connection String
In appsettings.json, choose your DB:

✅ For SQL Server

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=StudentDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

✅ For PostgreSQL
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=StudentDb;Username=postgres;Password=yourpassword"
}

📦 3. Apply Migrations
🚀 4. Run the App

Swagger will be available at:
https://localhost:<port>/swagger

📮 API Endpoints
🌱 Seed Dummy Data
POST /api/reportcard/seed
📊 Get Report Cards by Student IDs
POST /api/reportcard
Body:
{
  "studentIds": ["guid-1", "guid-2"]
}
📁 Sample Features
Create a student with exam, subjects, and marks.

Get full report card including:

Student name, class, section, academic year

Exam info, subjects, marks

Total, percentage

📌 Notes
Supports both PostgreSQL and SQL Server (just switch the connection string + NuGet package).

Uses Guid as primary keys.

Implements CQRS using MediatR.

Designed for extensibility and testability.

👨‍💻 Author
Abishek S
.NET Full Stack Developer
