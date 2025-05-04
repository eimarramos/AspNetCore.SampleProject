# 🚀 ASP.NET Core 8 Clean Architecture + React Sample

### Built with ASP.NET Core 8 using EF Core 8, React SPA Proxy, and MediatR following Clean Architecture principles

This is a modern ASP.NET Core Web API project demonstrating the **Clean Architecture** approach. It integrates **Entity Framework Core 8 + SQL Server**, **React SPA (via Microsoft.AspNetCore.SpaProxy)**, and popular tools like **AutoMapper**, **FluentValidation**, **Ardalis.GuardClauses**, and **MediatR** for clean, scalable, and testable code.

---

## 🧰 Tech Stack

- 🔧 **ASP.NET Core 8**
- 🎨 **React (with React Router 7.5.3)**
- 🔀 **Microsoft.AspNetCore.SpaProxy**
- 🗃️ **Entity Framework Core 8 + SQL Server**
- 🧭 **NSwag** (Swagger/OpenAPI)
- 🔄 **AutoMapper**
- 🛡️ **Ardalis.GuardClauses**
- 📏 **FluentValidation**
- 📬 **MediatR**
- ⚙️ **Dependency Injection**
- 🔄 **EF Core Migrations**
- 🧼 **Clean Architecture**

---

## 📦 Features

- ✅ **Clean separation of layers following Clean Architecture**
- ✅ **SPA Proxy via Microsoft.AspNetCore.SpaProxy**
- ✅ **React with React Router 7.5.3**
- ✅ **CQRS with MediatR**
- ✅ **Robust validation with FluentValidation**
- ✅ **Guard clauses via Ardalis.GuardClauses**
- ✅ **Automatic mapping with AutoMapper**
- ✅ **Full Swagger/OpenAPI integration using NSwag**
- ✅ **EF Core 8 + SQL Server with support for Migrations**

---

## 🧱 Project Structure
```
/src
├── Application # Application layer (CQRS, validation, contracts)
├── Domain # Domain models and core logic
├── Infrastructure # EF Core, external services
├── Web # ASP.NET Core + React frontend (served via SpaProxy)
```
---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/eimarramos/AspNetCore.SampleProject.git
```
### 2. Build Project

```bash
cd src/Web
dotnet build
````

### 3. Start the Project

```bash
cd src/Web
dotnet run
````

### Example EF Core Migrations

``` bash
dotnet ef migrations add "InitialCreate" --project src\Infrastructure --startup-project src\Web --output-dir Data\Migrations
dotnet ef database update --project src\Infrastructure --startup-project src\Web
```

## 📸 Screenshots

![Captura de pantalla 2025-05-04 212219](https://github.com/user-attachments/assets/8fa68579-a10e-4a9f-a65d-46e1ca515de4)
