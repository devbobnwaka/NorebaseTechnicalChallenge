# Article Like API

This API provides a simple "Like" feature for articles, allowing users to fetch the like count for a specific article and increment it when a "Like" button is clicked. This project is built with .NET 6, Entity Framework Core, and SQL Server.

## Features

- **Get Like Count**: Retrieve the current like count for an article.
- **Increment Like Count**: Increment the like count by 1 when a user clicks "Like."
- **Seeded Data**: For testing purposes, the application is pre-seeded with 6 sample articles in the database.

## Table of Contents

- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Testing Seeded Data](#testing-seeded-data)
- [Scalability and Resilience](#scalability-and-resilience)
- [Technologies Used](#technologies-used)

## Getting Started

### Prerequisites

- **.NET 6 SDK**: Required to build and run the application.
- **SQL Server**: Required as the database for this project.
- **Entity Framework Core**: For database migrations and interactions.

### Setup

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-repo/article-like-api.git
   cd article-like-api
   ```

2. **Configure the Database Connection**:
   - In the `appsettings.json` file, set up your SQL Server connection string under `ConnectionStrings:DefaultConnection`.
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NorbaseTechChallengeDb;Trusted_Connection=True;"
     }
   }
   ```

3. **Run Migrations**:
   - Apply migrations to set up the database schema and seed data:
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```

5. **Access Swagger**:
   - Open [https://localhost:7229/swagger](https://localhost:7229/swagger) in your browser to view and interact with the API documentation.

## API Endpoints

### 1. Get Like Count
- **Endpoint**: `GET /api/articles/{articleId}/likes`
- **Description**: Retrieves the current like count for a specific article.
- **Response**:
  ```json
  {
    "likes": 10
  }
  ```

### 2. Increment Like Count
- **Endpoint**: `POST /api/articles/{articleId}/like`
- **Description**: Increments the like count by 1 for a specific article.
- **Response**:
  ```json
  {
    "status": "success"
  }
  ```

## Testing Seeded Data

For testing purposes, six articles are pre-seeded in the database when migrations are applied. You can query these articles using their `ArticleId` values from 1 to 6.

Sample articles include:
- Article with `ArticleId = 1`: "Getting Started with the Like Button"
- Article with `ArticleId = 2`: "Understanding Article Popularity"
- Article with `ArticleId = 3`: "Scaling Social Interactions"
- Article with `ArticleId = 4`: "Database Optimization for Likes"
- Article with `ArticleId = 5`: "Resilience Against Like Spam"
- Article with `ArticleId = 6`: "Performance Metrics and Monitoring"

## Scalability and Resilience

This application is designed to handle scalability and resilience in the following ways:
- **Caching**: Implemented caching for frequently accessed like counts to reduce database load.
- **Rate Limiting**: Protects against spamming the "Like" feature.
  
## Technologies Used

- **.NET 6**: Core application framework.
- **Entity Framework Core**: ORM for database access and migrations.
- **SQL Server**: Relational database management system.
- **Swagger**: API documentation and testing.
- **AspNetCoreRateLimit**: Offers IP-based and client-based rate limiting for ASP.NET Core.