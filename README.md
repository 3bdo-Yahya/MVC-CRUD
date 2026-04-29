# LMS MVC

Simple Library Management System (LMS) built with ASP.NET Core MVC + EF Core + SQLite.

## Features

- Book CRUD (Create, Read, Update, Delete)
- Search books by title or author
- Dashboard summary (Total Books, Available Copies, Genres)
- Seeded sample books for quick demo

## Prerequisites

- .NET SDK 10

## One-time Setup

1) Ensure EF tools are installed (or updated):

```bash
dotnet tool update --global dotnet-ef
```

2) Create/update the SQLite database from migrations:

```bash
mkdir -p src/App_Data
dotnet ef database update --project src/Visual.csproj --startup-project src/Visual.csproj
```

## Run the App

```bash
dotnet run --project src/Visual.csproj
```

## Notes

- Development connection string is in `src/appsettings.Development.json`:
  - `Data Source=App_Data/app.db`
- SQLite files are ignored from git:
  - `src/App_Data/*.db`
  - `src/App_Data/*.db-shm`
  - `src/App_Data/*.db-wal`
