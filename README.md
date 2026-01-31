# MovieAPI

A simple **ASP.NET Core Web API** to manage movies using **SQLite**.  
Supports basic CRUD operations and Swagger for testing.

## Features

- Get all movies or by ID
- Filter movies for adults (18+) or minors
- Create, update, and delete movies
- Swagger UI support

## Tech Stack

- ASP.NET Core 10
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Setup

1. Clone the repo:

```bash
git clone https://github.com/your-username/MovieAPI.git
cd MovieAPI
Restore packages:

dotnet restore
Apply migrations and create the database:

dotnet ef database update
Run the API:

dotnet run
Open Swagger UI:

http://localhost:5119/swagger
Endpoints
GET /api/Movies – all movies

GET /api/Movies/{id} – movie by ID

GET /api/Movies/Adults – movies 18+

GET /api/Movies/Minors – movies under 18

POST /api/Movies – create movie

PUT /api/Movies/{id} – update movie

DELETE /api/Movies/{id} – delete movie

Author
Mateo - Junior Developer

