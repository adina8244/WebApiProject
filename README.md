# 🛒 DisneyShop Web API

A **production-style ASP.NET Core Web API** implementing a scalable backend for an online store.  
The project demonstrates **clean architecture, separation of concerns, dependency injection, and full automated testing coverage**.

The system manages **users, products, categories, and orders** while following modern backend engineering practices.

---

# ✨ Key Features

- RESTful Web API built with **ASP.NET Core**
- **Layered architecture** (Controllers → Services → Repositories → Database)
- **Entity Framework Core** for database access
- **AutoMapper** for DTO ↔ Entity mapping
- **Dependency Injection** across all layers
- **Swagger / OpenAPI documentation**
- **Secure password validation**
- **Logging support**
- **100% automated test coverage**

---


# 🏗 Architecture

The project follows a **clean layered architecture** to ensure maintainability, testability, and scalability.

```
Client
│
▼
Controllers (API Layer)
│
▼
Services (Business Logic)
│
▼
Repositories (Data Access)
│
▼
Entity Framework Core
│
▼
SQL Server Database
```

## Layers Overview

| Layer | Responsibility |
|------|---------------|
| Controllers | Handle HTTP requests and responses |
| Services | Implement business logic |
| Repositories | Data access abstraction |
| Entities | Database models |
| DTOs | API data contracts |

---

# 📁 Project Structure

```
DisneyShop.sln
│
├── DisneyShop
│   ├── Controllers
│   │   ├── UserController.cs
│   │   ├── ProductController.cs
│   │   ├── CategoryController.cs
│   │   └── OrderController.cs
│   │
│   ├── Program.cs
│   └── wwwroot
│
├── Services
│
├── Repositories
│
├── Entities
│
├── DTO
│
└── TestProject
    ├── Unit Tests
    └── Integration Tests
```
---

# 🔧 Technologies Used

- **C#**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **AutoMapper**
- **Swagger / OpenAPI**
- **xUnit**
- **Moq**
- **Fluent Assertions**

---

# 🧪 Testing

The project includes **comprehensive automated testing** to ensure reliability and maintainability.

## Test Types

- Unit Tests
- Integration Tests

## Coverage

✅ **100% test coverage**

Testing ensures:

- Business logic correctness
- Repository behavior
- API endpoint functionality
- Service layer validation

### Tools used

- **xUnit**
- **Moq**
- **Fluent Assertions**

---

# 🚀 Running the Project

## Clone the repository

```bash
git clone https://github.com/adina8244/WebApiProject.git
cd WebApiProject
```

## Install dependencies

```bash
dotnet restore
```

## Run the API

```bash
dotnet run --project DisneyShop
```

## Open Swagger

```
https://localhost:5001/swagger
```

Swagger provides an interactive interface for exploring the API.

---

# 🧩 Engineering Practices

This project demonstrates several **software engineering best practices**:

- Clean separation of concerns  
- Dependency Injection  
- Repository pattern  
- DTO mapping with AutoMapper  
- Structured logging  
- Test-driven validation  
- Modular and maintainable architecture
