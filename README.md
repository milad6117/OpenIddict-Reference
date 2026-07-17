
![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![C#](https://img.shields.io/badge/C%23-13-blue)
![.NET CI](https://img.shields.io/badge/.NET_CI-Passing-success?style=flat)
![Docker_CI](https://img.shields.io/badge/Docker_CI-Passing-success?style=flat)
![OpenIddict](https://img.shields.io/badge/OpenIddict-7.x-green)
![OAuth2.1](https://img.shields.io/badge/OAuth-2.1-red)
![OpenID Connect](https://img.shields.io/badge/OpenID%20Connect-OIDC-orange)
![Authorization Code](https://img.shields.io/badge/Authorization_Code-Supported-success?style=flat)
![PKCE](https://img.shields.io/badge/PKCE-S256-success?style=flat)
![Docker](https://img.shields.io/badge/Docker-Enabled-2496ED?logo=docker&logoColor=white)
![Client Credentials](https://img.shields.io/badge/Client_Credentials-Supported-success?style=flat)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red)
![License](https://img.shields.io/badge/License-MIT-yellow)
![GitHub release](https://img.shields.io/github/v/release/milad6117/OpenIddict-Reference)
![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/milad6117/OpenIddict-Reference/dotnet.yml)
![Docker Workflow](https://img.shields.io/github/actions/workflow/status/milad6117/OpenIddict-Reference/docker.yml)
![Reference Tokens](https://img.shields.io/badge/Tokens-Reference-success?style=flat)
![Refresh Tokens](https://img.shields.io/badge/Refresh-Tokens-blue?style=flat)
![Token Introspection](https://img.shields.io/badge/Token-Introspection-red?style=flat)
![Token Revocation](https://img.shields.io/badge/Token-Revocation-important?style=flat)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-blueviolet?style=flat)


# OpenIddict Reference Authorization Server

A production-ready Authorization Server built with ASP.NET Core (.NET 10) and OpenIddict 7.5, implementing modern OAuth 2.1 and OpenID Connect authentication flows.

This project serves as a reference implementation demonstrating how to build a secure identity provider using OpenIddict without relying on ASP.NET Core Identity. It focuses on Clean Architecture principles, extensibility, and real-world authentication scenarios.

The implementation includes secure token issuance, refresh token rotation, reference access tokens, token revocation, token introspection, OpenID Connect identity tokens, and PKCE support for public clients.

The project was designed as a foundation for a distributed microservices architecture where multiple resource servers (Product Service, Inventory Service, Order Service, etc.) trust a centralized Authorization Server.

This repository is intended for learning, experimentation, and as a starting point for production-ready authentication infrastructures.

## Why OpenIddict?

OpenIddict is one of the most flexible authentication frameworks available for ASP.NET Core.

Unlike ASP.NET Core Identity, OpenIddict focuses exclusively on OAuth 2.1 and OpenID Connect protocols, allowing complete control over authentication, authorization, token issuance, client management, and security policies.

This project demonstrates how OpenIddict can be used as a standalone Authorization Server while keeping user management fully customizable.

## Project Goals

This project was created to demonstrate:

- OAuth 2.1 Authorization Server implementation
- OpenID Connect Identity Provider
- Authorization Code Flow with PKCE
- Client Credentials Flow
- Refresh Token Flow
- Reference Access Tokens
- Token Revocation
- Token Introspection
- Cookie Authentication
- Custom User Management
- SQL Server persistence
- Entity Framework Core integration
- Swagger/OpenAPI integration
- Clean Architecture principles

## Key Features

- OAuth 2.1 compliant Authorization Server
- OpenID Connect support
- Authorization Code Flow + PKCE
- Client Credentials Flow
- Refresh Token Flow
- Reference Access Tokens
- Refresh Token Rotation
- Token Revocation Endpoint
- Token Introspection Endpoint
- UserInfo Endpoint
- Cookie Authentication
- SQL Server persistence
- Entity Framework Core integration
- Swagger OAuth2 integration
- Public and Confidential Clients
- Custom User Management
- OpenIddict 7.5
- .NET 10

## Typical Use Cases

This Authorization Server can be used in several scenarios:

- Microservices authentication
- API Gateway authentication
- Single Sign-On (SSO)
- Native applications
- SPA applications
- Mobile applications
- Machine-to-Machine communication
- Backend services
- Internal enterprise APIs


# Technology Stack

This project is built on top of modern Microsoft technologies and follows current security standards for OAuth 2.1 and OpenID Connect implementations.

| Technology | Version | Purpose |
|------------|---------|---------|
| .NET | 10 | Application Platform |
| ASP.NET Core | 10 | Web Framework |
| OpenIddict | 7.5 | OAuth2 & OpenID Connect Server |
| Entity Framework Core | 10 | ORM |
| SQL Server | Latest | Database |
| Cookie Authentication | ASP.NET Core | User Authentication |
| Swagger / OpenAPI | Latest | API Documentation |
| Serilog | Latest | Structured Logging |

---

# Architecture
```bash
The solution follows a layered architecture where responsibilities are clearly separated.

                +-------------------------+
                |        Swagger UI       |
                +-----------+-------------+
                            |
                            |
                +-----------v-------------+
                |     Authorization API   |
                +-----------+-------------+
                            |
        +-------------------+-------------------+
        |                   |                   |
        |                   |                   |
+-------v------+    +-------v------+    +-------v------+
| Authorization|    |    Token     |    |   UserInfo   |
|   Endpoint   |    |   Endpoint   |    |   Endpoint   |
+--------------+    +--------------+    +--------------+
        |
        |
+-------v-------------------------------------------+
|                OpenIddict Server                  |
+--------------------+------------------------------+
                     |
                     |
          +----------v----------+
          | Entity Framework    |
          +----------+----------+
                     |
             +-------v-------+
             | SQL Server    |
             +---------------+

 ```            
---

# High-Level Components

The application is composed of the following major components:

### Authorization Endpoint

Responsible for authenticating end users and generating Authorization Codes.

---

### Token Endpoint

Issues:

- Access Tokens
- Refresh Tokens
- Identity Tokens

Supports multiple OAuth2 grant types.

---

### UserInfo Endpoint

Returns authenticated user profile information according to the requested OpenID Connect scopes.

---

### Introspection Endpoint

Allows Resource Servers to validate opaque Reference Tokens.

---

### Revocation Endpoint

Allows clients to revoke previously issued Refresh Tokens and Reference Access Tokens.

---

### Entity Framework Core

Persists:

- Users
- Clients
- Scopes
- Tokens
- Authorizations

inside SQL Server.

---

# Authentication Flows

The Authorization Server currently supports the following flows:

| Flow | Supported |
|------|-----------|
| Authorization Code | ✅ |
| Authorization Code + PKCE | ✅ |
| Client Credentials | ✅ |
| Refresh Token | ✅ |
| OpenID Connect | ✅ |
| Reference Access Token | ✅ |
| Token Introspection | ✅ |
| Token Revocation | ✅ |

---

# Project Structure

```bash
src
├── OpenIddict.Reference.Api
│   ├── Controllers
│   ├── Pages
│   ├── Models
│   ├── Program.cs
│   └── appsettings.json
│
├── OpenIddict.Reference.Infrastructure
│   ├── Authentication
│   ├── Services
│   ├── Options
│   ├── OpenIddict
│   ├── Extensions
│   ├── Seeder
│   └── DependencyInjection.cs
│
├── OpenIddict.Reference.Persistence
│   ├── Configurations
│   ├── Migrations
│   ├── DbContext
│   └── DependencyInjection.cs
│
├── OpenIddict.Reference.Domain
│   ├── Entities
│   └── Interfaces
│
└── README.md
```
---

# Design Principles

This project follows several software engineering principles:

- Separation of Concerns
- Dependency Injection
- Repository Pattern
- Layered Architecture
- OAuth 2.1 Best Practices
- OpenID Connect Standards
- Principle of Least Privilege
- Stateless Authentication
- Secure Token Management

---

# Security Considerations

Security was the primary focus during development.

Implemented protections include:
- PKCE for public clients
- Reference Access Tokens
- Confidential Clients
- Refresh Token Rotation
- Token Revocation
- Token Introspection
- Cookie Authentication
- Secure Authorization Code Flow
- OpenID Connect Identity Tokens
- Audience Validation
- Resource Validation


# Authentication Flows

The Authorization Server implements multiple OAuth 2.1 and OpenID Connect flows.

Each flow is designed for a specific type of client and use case.

---

# Authorization Code Flow + PKCE

The Authorization Code Flow is the recommended authentication flow for:

- Single Page Applications (SPA)
- Mobile Applications
- Desktop Applications
- Swagger UI
- Public Clients

This implementation also supports PKCE (Proof Key for Code Exchange), preventing authorization code interception attacks.

## Flow Diagram

sequenceDiagram

participant User
participant Browser
participant Swagger
participant AuthorizationServer
participant Database

User->>Swagger: Login
Swagger->>AuthorizationServer: /connect/authorize
AuthorizationServer->>Database: Validate user
Database-->>AuthorizationServer: User
AuthorizationServer-->>Swagger: Authorization Code
Swagger->>AuthorizationServer: /connect/token
AuthorizationServer-->>Swagger: Access Token
AuthorizationServer-->>Swagger: Refresh Token
AuthorizationServer-->>Swagger: ID Token

### Generated Tokens

- Authorization Code
- Access Token
- Refresh Token
- Identity Token

### Supported Client

- Public Client

### Security

- PKCE
- Authorization Code
- Cookie Authentication
- Reference Tokens

---

# Client Credentials Flow

The Client Credentials Flow is designed for machine-to-machine communication.

There is no interactive user.

The authenticated identity is the client itself.

Typical use cases include:

- Microservices
- Background Workers
- Windows Services
- Scheduled Jobs
- API Gateway

## Flow Diagram

sequenceDiagram

participant Service
participant AuthorizationServer
participant Database

Service->>AuthorizationServer: ClientId + Secret
AuthorizationServer->>Database: Validate Client
Database-->>AuthorizationServer: Client
AuthorizationServer-->>Service: Access Token
### Generated Tokens

- Access Token

### Generated Claims

- sub
- client_id
- aud
- scope

### Supported Client

- Confidential Client

---

# Refresh Token Flow

Refresh Tokens allow clients to obtain a new Access Token without requiring the user to authenticate again.

This improves user experience while maintaining security.

## Flow Diagram

sequenceDiagram

participant Client
participant AuthorizationServer
participant Database

Client->>AuthorizationServer: Refresh Token
AuthorizationServer->>Database: Validate Refresh Token
Database-->>AuthorizationServer: Valid
AuthorizationServer-->>Client: New Access Token
AuthorizationServer-->>Client: New Refresh Token
### Generated Tokens

- New Access Token
- New Refresh Token

---

# OpenID Connect

OpenID Connect extends OAuth2 by providing authentication in addition to authorization.

Besides issuing Access Tokens, the Authorization Server also issues Identity Tokens.

Identity Tokens contain information about the authenticated user.

Typical claims include:

- sub
- name
- email
- role

---

# Token Introspection

Reference Tokens cannot be validated locally.

Instead, Resource Servers send them to the Authorization Server using the Introspection Endpoint.

If the token is valid, detailed metadata is returned.

## Flow Diagram

sequenceDiagram

participant API
participant AuthorizationServer
participant Database

API->>AuthorizationServer: /connect/introspect
AuthorizationServer->>Database: Validate Token
Database-->>AuthorizationServer: Active Token
AuthorizationServer-->>API: active = true

# Example Response

```json
{
  "active": true,
  "client_id": "service-worker",
  "scope": "resource_server",
  "aud": "resource_api",
  "exp": 1784090594
}
```
---

# Token Revocation

Clients may revoke previously issued tokens.

This endpoint supports revoking:

- Refresh Tokens
- Reference Access Tokens

## Flow Diagram

`mermaid
sequenceDiagram

participant Client
participant AuthorizationServer
participant Database

Client->>AuthorizationServer: /connect/revoke
AuthorizationServer->>Database: Revoke Token
Database-->>AuthorizationServer: Success
AuthorizationServer-->>Client: HTTP 200

After revocation:

- Token Status becomes **Revoked**
- Introspection returns:

```json
{
    "active": false
}
```

---

# Reference Access Tokens

This project uses **Reference Access Tokensns** instead of JWT Access Tokens.

Instead of embedding claims directly inside the token, only a random identifier is returned to the client.

The actual token payload is securely stored in the database.

Advantages:

- Immediate token revocation
- Smaller token size
- Centralized validation
- Better security
- Easier auditing
- Better suited for microservices

Reference Tokens are validated using the Introspection Endpoint.

---

# Supported OAuth 2.1 Endpoints

| Endpoint | Description |
|-----------|-------------|
| /connect/authorize | Authorization Endpoint |
| /connect/token | Token Endpoint |
| /connect/userinfo | UserInfo Endpoint |
| /connect/introspect | Token Introspection |
| /connect/revoke | Token Revocation |

---

# Supported Grant Types

| Grant Type | Status |
|------------|--------|
| Authorization Code | ✅ |
| Authorization Code + PKCE | ✅ |
| Client Credentials | ✅ |
| Refresh Token | ✅ |

---

# Supported Token Types

| Token | Supported |
|--------|-----------|
| Access Token | ✅ |
| Refresh Token | ✅ |
| Identity Token | ✅ |
| Reference Token | ✅ |

---

# API Documentation

The Authorization Server exposes several OAuth 2.1 and OpenID Connect endpoints.

Each endpoint implements a specific part of the authentication lifecycle.



# Authorization Endpoint

GET /connect/authorize

Starts the Authorization Code Flow.

This endpoint authenticates the user and returns an Authorization Code.

### Supported Flow

- Authorization Code
- Authorization Code + PKCE

### Required Parameters

| Parameter | Required | Description |
|-----------|----------|-------------|
| client_id | Yes | Client Identifier |
| redirect_uri | Yes | Redirect URI |
| response_type | Yes | code |
| scope | Yes | Requested scopes |
| code_challenge | Yes | PKCE Challenge |
| code_challenge_method | Yes | S256 |
| state | Recommended | CSRF protection |

### Example


GET /connect/authorize?client_id=swagger&response_type=code&redirect_uri=https://localhost:5005/swagger/oauth2-redirect.html&scope=openid profile email offline_access resource_server&code_challenge=...&code_challenge_method=S256

---

# Token Endpoint

POST /connect/token

Issues Access Tokens, Refresh Tokens and Identity Tokens.

Depending on the Grant Type, different request bodies are accepted.

---

## Authorization Code Grant

### Request

```ini
grant_type=authorization_code
client_id=swagger
code=AUTHORIZATION_CODE
redirect_uri=https://localhost:5005/swagger/oauth2-redirect.html
code_verifier=PKCE_VERIFIER
```
### Response
```json
{
  "access_token": "...",
  "refresh_token": "...",
  "id_token": "...",
  "token_type": "Bearer",
  "expires_in": 3600
}
```
---

## Client Credentials Grant

### Request

```ini
x-www-form-urlencoded

grant_type=client_credentials
client_id=service-worker
client_secret=****
scope=resource_server
```
### Response
```json
{
  "access_token": "...",
  "token_type": "Bearer",
  "expires_in": 3600
}
```
---

## Refresh Token Grant

### Request

```ini
x-www-form-urlencoded

grant_type=refresh_token
client_id=swagger
refresh_token=REFRESH_TOKEN
```

### Response
```json
{
  "access_token": "...",
  "refresh_token": "...",
  "id_token": "...",
  "expires_in": 3600
}
```
---

# UserInfo Endpoint


GET /connect/userinfo

Returns user profile information.

Requires:

Authorization: Bearer ACCESS_TOKEN

### Example Response
```json
{
  "sub": "1",
  "name": "John Doe",
  "email": "john@example.com",
  "role": "Admin"
}
```
---

# Introspection Endpoint

POST /connect/introspect

Validates Reference Access Tokens.

Used by Resource Servers.

### Request

```ini
x-www-form-urlencoded

client_id=resource_api
client_secret=****
token=ACCESS_TOKEN
```
### Example Response
```json
{
  "active": true,
  "client_id": "service-worker",
  "scope": "resource_server",
  "aud": "resource_api",
  "token_type": "Bearer",
  "exp": 1784090594
}
```

### Inactive token
```json
{
  "active": false
}
```
---

# Revocation Endpoint

POST /connect/revoke

Revokes previously issued Refresh Tokens or Reference Access Tokens.

### Request

```ini
x-www-form-urlencoded

client_id=swagger
refresh_token=REFRESH_TOKEN
```
### Successful Response

HTTP 200 OK
After revocation

- Refresh Token becomes invalid
- Token status changes to Revoked
- Introspection returns active=false

---

# OAuth2 Scopes

The Authorization Server currently supports the following scopes.

| Scope | Description |
|--------|-------------|
| openid | Required by OpenID Connect |
| profile | User profile information |
| email | User email |
| offline_access | Enables Refresh Tokens |
| resource_server | API access |

---

# OAuth2 Clients

## Swagger

Public Client

Supports:

- Authorization Code
- PKCE
- Refresh Token

---

## service-worker

Confidential Client

Supports:

- Client Credentials

---

## resource_api

Confidential Client

Used only for Token Introspection.

---

# HTTP Status Codes

| Status | Description |
|---------|-------------|
| 200 | Success |
| 400 | Invalid Request |
| 401 | Unauthorized |
| 403 | Forbidden |
| 500 | Internal Server Error |

---

# Error Responses

### Invalid Grant
```json
{
  "error": "invalid_grant"
}
```

### Invalid Client
```json
{
  "error": "invalid_client"
}
```

### Invalid Scope
```json
{
  "error": "invalid_scope"
}
```

### Unauthorized Client
```json
{
  "error": "unauthorized_client"
}
```

### Invalid Token
```json
{
  "active": false
}
```
---

# Testing

The project has been manually tested using:

- Swagger UI
- Postman

The following scenarios have been verified:

- ✅ User Login
- ✅ Authorization Code Flow
- ✅ PKCE
- ✅ Client Credentials Flow
- ✅ Refresh Token
- ✅ Token Revocation
- ✅ Reference Access Tokens
- ✅ Token Introspection
- ✅ OpenID Connect UserInfo

---

# Getting Started

## Prerequisites

Before running the project make sure the following software is installed.

- .NET 10 SDK
- SQL Server
- Visual Studio 2022 / Rider
- Git
- Docker Desktop (optional)

---

## Clone Repository
```bash
git clone https://github.com/milad6117/OpenIddict.Reference.git

cd OpenIddict.Reference

---

## Restore Packages

bash
dotnet restore

---

## Update Database

bash
dotnet ef database update

---

## Run Application

bash
dotnet run

Application

text
https://localhost:5005

Swagger

text
https://localhost:5005/swagger

---

## Seed Default Clients

The application automatically creates the default OAuth clients.

- swagger
- service-worker
- resource_api

No manual configuration is required.

---

## Default OAuth Flows

### Authorization Code + PKCE

Recommended for

- SPA
- Swagger
- Mobile Apps

---

### Client Credentials

Recommended for

- Microservices
- Background Workers
- Machine-to-Machine Communication
```

---

# Configuration

The application configuration is stored in appsettings.json and can be overridden using environment variables.

### Example

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=OpenIddictReference;Trusted_Connection=True;TrustServerCertificate=True;"
  },

  "Authentication": {
    "Issuer": "https://localhost:5005",
    "Audience": "resource_server"
  }
}
### Docker Environment Variables

SQL_DATABASE=OpenIddictReference
SQL_PASSWORD=YourStrong@Passw0rd
ASPNETCORE_ENVIRONMENT=Development
> When running with Docker Compose, the connection string is automatically overridden using environment variables.

---

## Docker

Build Image

bash
docker build -t openiddict-reference .

Run Container

bash
docker run -p 5005:8080 openiddict-reference

---

## Docker Compose

yaml
version: '3.9'

services:

  openiddict:

    build: .

    ports:
      - "5005:8080"

    environment:
      ASPNETCORE_ENVIRONMENT: Development

    depends_on:
      - sqlserver

  sqlserver:

    image: mcr.microsoft.com/mssql/server:2022-latest

    environment:
      ACCEPT_EULA: "Y"
      MSSQL_SA_PASSWORD: "YourStrongPassword123!"

    ports:
      - "1433:1433"

Run


Run the complete Authorization Server using Docker Compose.

docker compose up --build
The following services will be started:

- SQL Server 2022
- OpenIddict Authorization Server

---

## Project Structure

text
src/

 ├── API
 ├── Application
 ├── Domain
 ├── Infrastructure
 └── Persistence
`

---

## Features

- Authorization Code Flow
- PKCE
- Client Credentials Flow
- Refresh Tokens
- Token Revocation
- Token Introspection
- OpenID Connect
- Cookie Authentication
- Reference Access Tokens
- SQL Server Persistence
- Entity Framework Core
- OpenIddict 7.x

---

## Technologies

- ASP.NET Core 10
- C#
- OpenIddict
- Entity Framework Core
- SQL Server
- Cookie Authentication
- OAuth 2.1
- OpenID Connect
- Swagger / OpenAPI
- Docker

---

## License

This project is released under the MIT License.

---

# Roadmap

Future improvements planned for this project:

- ✅ Authorization Code Flow + PKCE
- ✅ Client Credentials Flow
- ✅ Refresh Token Flow
- ✅ Reference Access Tokens
- ✅ Token Revocation
- ✅ Token Introspection
- ✅ Docker Support
- ✅ Docker Compose
- ✅ GitHub Actions CI
- ✅ GitHub Container Registry (GHCR)

Possible future enhancements:

- OAuth Device Authorization Flow
- Dynamic Client Registration
- Federation Support
- Integration Tests
- Rate Limiting
- API Versioning

---

# Author

Milad Lotfi

Backend Engineer specializing in ASP.NET Core, Distributed Systems, Microservices, OAuth 2.1, OpenID Connect, and Clean Architecture.

- GitHub: https://github.com/milad6117
- LinkedIn: https://www.linkedin.com/in/milad-lotfi-689ab5411
