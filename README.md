# TaskSyncPro

<!-- Badges: informational (no CI configured in this repo) -->
![.NET](https://img.shields.io/badge/.NET-net10.0-512BD4?logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4)
![EF Core](https://img.shields.io/badge/EF%20Core-9.0-6DB33F)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?logo=microsoftsqlserver)
![AutoMapper](https://img.shields.io/badge/AutoMapper-14.0-0B7285)

TaskSyncPro is a layered ASP.NET Core Web API for managing **teams**, **employees**, **tasks**, **task logs**, **billing records**, and **performance reports**.

- Solution: `TaskSyncPro.slnx`
- Projects: `API` (presentation), `BLL` (business logic + DTOs), `DAL` (EF Core + repositories)

## Features

| Area | What you can do | Main endpoints |
|---|---|---|
| Users | Create users (auto-generated password), login, query by email/phone | `/api/User/*` |
| Roles | CRUD roles, search by name | `/api/Role/*` |
| Teams | CRUD teams, fetch teams with employees/tasks | `/api/Team/*` |
| Employees | CRUD employees, lookup by email/phone, fetch employee details | `/api/Employee/*` |
| Tasks | CRUD tasks, filter by title/priority/status | `/api/Task/*` |
| Task Logs | Track task status changes, query logs by task | `/api/TaskLog/*` |
| Billing | Create/update billing records, fetch billing with task | `/api/Billing/*` |
| Reports | Task status/priority overview + employee/team performance | `/api/Reports/*` |

## Tech Stack

- .NET: `net10.0`
- ASP.NET Core Web API
- EF Core: `Microsoft.EntityFrameworkCore` + `SqlServer`
- AutoMapper
- Password hashing: `Microsoft.AspNetCore.Identity` `PasswordHasher<T>`
- OpenAPI (development): `Microsoft.AspNetCore.OpenApi`

## Architecture

The solution follows a simple 3-layer architecture:

- **API**: Controllers expose REST endpoints under `/api/*`.
- **BLL**: Services implement validations and business rules. DTOs are used for request/response models. AutoMapper maps DTOs ↔ EF entities.
- **DAL**: EF Core `DbContext` plus repositories.

Key pieces:

- `DAL.EF.TaskSyncDbContext` defines the database model.
- `DAL.DataAccessFactory` is the entry point for repositories:
  - `GetRepo<T>()` for CRUD via the generic `Repository<T>`
  - Feature repos for domain-specific queries (Tasks, Users, Teams, Billing, Reports, etc.)
- `BLL.MapperConfig` configures AutoMapper mappings.

## Database Model (EF Core)

Entities in `DAL.EF.Models`:

- `Role` → has many `User`
- `User` → belongs to a `Role`
- `Team` → has many `Employee`
- `Employee` → belongs to a `User` and a `Team`; has many assigned `Task`
- `Task` → created by a `User`, optionally assigned to an `Employee`; has (1:1) `BillingRecord`
- `BillingRecord` → belongs to a `Task` (unique per task)
- `TaskLog` → belongs to a `Task`

Migrations are in the `DAL/Migrations` folder.

## Configuration

### Database connection

Set the SQL Server connection string in [API/appsettings.json](API/appsettings.json):

```json
"ConnectionStrings": {
  "DbConn": "data source=...; initial catalog=TaskSyncPro; ..."
}
```

Recommended: use a local SQL Server instance and update `DbConn` accordingly.

### Email (user creation)

User creation triggers an email with a generated temporary password.

The current implementation uses hard-coded SMTP credentials in [BLL/Helpers/EmailService.cs](BLL/Helpers/EmailService.cs). For security, you should replace these with configuration (user-secrets / environment variables) before running in any real environment.

## Quick Start

1) Configure the database connection string in [API/appsettings.json](API/appsettings.json)

2) Apply EF Core migrations

```powershell
dotnet tool install --global dotnet-ef

dotnet restore
dotnet ef database update --project .\DAL\DAL.csproj --startup-project .\API\API.csproj
```

3) Run the API

```powershell
dotnet run --project .\API\API.csproj
```

Default launch URLs (Development) from [API/Properties/launchSettings.json](API/Properties/launchSettings.json):

- HTTP: `http://localhost:5273`
- HTTPS: `https://localhost:7173`

## Running the API

### Prerequisites

- .NET SDK that supports `net10.0`
- SQL Server (LocalDB or full SQL Server)
- (Optional) EF Core CLI tools: `dotnet-ef`

### Apply database migrations

From the repository root:

```powershell
# Install EF CLI tools (if not already installed)
dotnet tool install --global dotnet-ef

# Restore dependencies
dotnet restore

# Apply migrations to the database
# Migrations are in DAL, startup project is API

dotnet ef database update --project .\DAL\DAL.csproj --startup-project .\API\API.csproj
```

### Start the API

```powershell
cd .\API

dotnet run
```

Default launch URLs (Development) from [API/Properties/launchSettings.json](API/Properties/launchSettings.json):

- HTTP: `http://localhost:5273`
- HTTPS: `https://localhost:7173`

### OpenAPI

In Development, OpenAPI is enabled via `app.MapOpenApi()`.

Typical endpoints:

- `GET /openapi/v1.json`

(Exact route depends on ASP.NET Core OpenAPI defaults.)

## API Endpoints

Base route pattern: `api/[controller]`

Tip: Once the API is running in Development, you can use the OpenAPI JSON to generate a client or import into API tools.

### Users (`/api/User`)

- `POST /api/User/login`
- `GET /api/User/all`
- `GET /api/User/all/{id}`
- `POST /api/User/create`
- `PUT /api/User/update`
- `DELETE /api/User/delete/{id}`
- `GET /api/User/byEmail/{email}`
- `GET /api/User/byPhoneNumber/{phoneNumber}`
- `GET /api/User/withRoles`

### Roles (`/api/Role`)

- `POST /api/Role/Create`
- `GET /api/Role/all`
- `GET /api/Role/Find/{id}`
- `GET /api/Role/byName/{role}`
- `PUT /api/Role/update`
- `DELETE /api/Role/Delete/{id}`

### Teams (`/api/Team`)

- `POST /api/Team/create`
- `GET /api/Team/all`
- `GET /api/Team/all/{id}`
- `PUT /api/Team/update`
- `DELETE /api/Team/delete/{id}`
- `GET /api/Team/withEmployees`
- `GET /api/Team/withEmployees/{id}`
- `GET /api/Team/withEmployeeTask`
- `GET /api/Team/withEmployeeTask/{id}`

### Employees (`/api/Employee`)

- `POST /api/Employee/create`
- `GET /api/Employee/all`
- `GET /api/Employee/all/{id}`
- `PUT /api/Employee/update`
- `DELETE /api/Employee/delete/{id}`
- `GET /api/Employee/ByEmail/{email}`
- `GET /api/Employee/ByPhoneNumber/{phoneNumber}`
- `GET /api/Employee/GetEmployeeWithDetails`
- `GET /api/Employee/GetEmployeeWithDetails/{id}`

### Tasks (`/api/Task`)

- `POST /api/Task/create`
- `GET /api/Task/all`
- `GET /api/Task/all/{id}`
- `PUT /api/Task/update`
- `DELETE /api/Task/delete/{id}`
- `GET /api/Task/findByTitle/{title}`
- `GET /api/Task/findByPriority/{priority}`
- `GET /api/Task/findByStatus/{status}`

Task business rules (enforced in BLL):

- Allowed statuses: `Pending`, `InProgress`, `Completed`, `Overdue`
- Allowed priorities: `Low`, `Medium`, `High`
- `InProgress` tasks must be assigned to an employee
- `Pending` tasks cannot be assigned
- `Completed` tasks must have `CompletedAt`

### Task Logs (`/api/TaskLog`)

- `POST /api/TaskLog/create`
- `GET /api/TaskLog/all`
- `GET /api/TaskLog/all/{id}`
- `PUT /api/TaskLog/update`
- `DELETE /api/TaskLog/delete/{id}`
- `GET /api/TaskLog/byTask/{taskId}`

### Billing (`/api/Billing`)

- `POST /api/Billing/create`
- `GET /api/Billing/all`
- `GET /api/Billing/all/{id}`
- `PUT /api/Billing/update`
- `DELETE /api/Billing/delete/{id}`
- `GET /api/Billing/withTask`
- `GET /api/Billing/withTask/{id}`

### Reports (`/api/Reports`)

All report endpoints accept a JSON body:

```json
{ "from": "2026-01-01T00:00:00", "to": "2026-01-31T23:59:59" }
```

- `POST /api/Reports/task-status-overview`
- `POST /api/Reports/task-priority-overview`
- `POST /api/Reports/employee-performance`
- `POST /api/Reports/team-performance`

## Notes / Known Issues

- **Billing PaidById mismatch**: `BillingRecordDTO` includes `PaidById`, but the EF entity + migrations for `BillingRecords` do not include a `PaidById` column. As a result, this value is not persisted.
- **Email credentials**: SMTP credentials are currently hard-coded in [BLL/Helpers/EmailService.cs](BLL/Helpers/EmailService.cs). Remove/replace before sharing the repo or deploying.
- **Authorization**: The API enables `UseAuthorization()`, but there is no configured authentication/JWT setup in the current codebase.

## Suggested Improvements (Optional)

- Move SMTP configuration into `appsettings.*` + user-secrets (and remove secrets from source).
- Add authentication/authorization (JWT) and protect sensitive endpoints.
- Add unique indexes (e.g., users by email/phone) at the database level.
- Add CI workflow (build + test) to make the badges “live”.

## Useful Commands

```powershell
# Restore
 dotnet restore

# Build
 dotnet build

# Run API
 dotnet run --project .\API\API.csproj

# Apply migrations
 dotnet ef database update --project .\DAL\DAL.csproj --startup-project .\API\API.csproj
```
