# WebApiSolution

WebApiSolution is a comprehensive web API project designed to provide a robust and scalable framework for building and consuming web services. This project demonstrates best practices for structuring, developing, and testing a web API using modern technologies.

## Introduction

The WebApiSolution project aims to deliver a reliable and efficient web API solution that can be easily integrated into various applications. Whether you are building a new application from scratch or enhancing an existing one, this project provides the necessary tools and frameworks to get started quickly.

## Features

- RESTful API design
- CRUD operations
- Error handling and logging
- Unit and integration testing
- API documentation with Swagger
- Support for multiple environments

## Technologies

- **.NET Core**: The core framework for building the web API
- **Entity Framework Core**: ORM for database operations
- **Swagger**: For API documentation
- **XUnit**: Testing framework
- **AutoMapper**: For object-to-object mapping
- **Serilog**: For logging

## Installation

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) 3.1 or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other supported database

### Steps

1. Clone the repository:
    ```bash
    git clone https://github.com/Gvantsie/WebApiSolution.git
    ```
2. Navigate to the project directory:
    ```bash
    cd WebApiSolution
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```
4. Update the database:
    ```bash
    dotnet ef database update
    ```

## Usage

1. Build the project:
    ```bash
    dotnet build
    ```
2. Run the project:
    ```bash
    dotnet run
    ```
3. The API will be available at `https://localhost:5001` or `http://localhost:5000`. You can access the Swagger documentation at `https://localhost:5001/swagger`.

## Configuration

Configuration settings for the application can be found in the `appsettings.json` file. This includes settings for the database connection, logging, and other application-specific settings.

## Testing

To run the tests, use the following command:
    ```bash
    dotnet test
    ```
