<div align="center">

# 🚀 TaskSyncPro

### Enterprise-Grade Task Management & Team Collaboration Platform

![.NET Version](https://img.shields.io/badge/.NET-10.0-blue?logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Latest-green?logo=csharp&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-9.0-purple?logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-red?logo=microsoft-sql-server&logoColor=white)
![API](https://img.shields.io/badge/API-RESTful-orange?logo=swagger&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-3--Tier-blueviolet)
![License](https://img.shields.io/badge/License-MIT-yellow)
![Status](https://img.shields.io/badge/Status-Active%20Development-brightgreen)
![Last Updated](https://img.shields.io/badge/Updated-Jan%202026-blue)

[Features](#-key-features) • [Architecture](#-architecture) • [Installation](#-getting-started) • [API Docs](#-api-endpoints) • [Contributing](#-contributing)

</div>

---

## 📋 Overview

**TaskSyncPro** is a sophisticated, enterprise-ready task management and synchronization platform engineered with cutting-edge ASP.NET Core 10.0 technologies. Designed for teams of any size, it seamlessly integrates task tracking, team collaboration, employee lifecycle management, and advanced analytics into a unified ecosystem.

### 🎓 Built For
- **Enterprise Teams** requiring robust task coordination
- **Project Managers** needing real-time visibility and analytics
- **HR Departments** managing employee performance and assignments
- **Finance Teams** tracking billing and resource allocation
- **Organizations** requiring role-based access control and security

### ⚡ Core Value Proposition
- 📊 **Real-time Task Analytics** - Monitor project progress with comprehensive dashboards
- 🔒 **Enterprise Security** - Role-based access control with granular permissions
- 💰 **Financial Integration** - Built-in billing and cost tracking
- 📈 **Performance Metrics** - Track team and individual performance seamlessly
- 🔄 **Seamless Synchronization** - Keep all team members in sync

---

## 📑 Table of Contents

<details>
<summary><b>Click to expand</b></summary>

- [Key Features](#-key-features)
- [Quick Demo](#-quick-demo)
- [Architecture](#-architecture)
- [Technology Stack](#-technology-stack)
- [Project Structure](#-project-structure)
- [Getting Started](#-getting-started)
- [API Endpoints](#-api-endpoints)
- [Database Schema](#-database-schema)
- [Security Features](#-security-features)
- [Validation Rules](#-validation-rules)
- [Contributing](#-contributing)
- [Troubleshooting](#-troubleshooting)
- [Performance Tips](#-performance-tips)
- [FAQ](#-faq)
- [License](#-license)

</details>

---

## 🎯 Key Features

### 📝 Task Management Suite
A comprehensive task management ecosystem designed to streamline workflow and increase productivity:

- ✅ **Full CRUD Operations** - Create, read, update, and delete tasks with ease
- ✅ **Multi-Status Tracking** - Pending → InProgress → Completed or Overdue states
- ✅ **Priority Hierarchy** - Low, Medium, High priority levels for task organization
- ✅ **Advanced Due Date Management** - Intelligent deadline validation with automatic overdue detection
- ✅ **Smart Task Assignment** - Assign tasks to employees with conflict prevention
- ✅ **Complete Audit Trail** - Full task history and activity logging with timestamps
- ✅ **Validation Engine** - Comprehensive business rule validation (e.g., employee cannot self-assign)
- ✅ **Task Dependencies** - Track related tasks and dependencies
- ✅ **Bulk Operations** - Handle multiple tasks efficiently

### 👥 Team & Employee Management
Powerful tools for team organization and employee lifecycle management:

- 👥 **Team Management** - Create and organize teams with hierarchical structure
- 👤 **Employee Profiles** - Comprehensive employee information and career tracking
- 📊 **Performance Analytics** - Real-time employee performance metrics and insights
- 🎭 **Role-Based Access Control** - Granular permission management with custom roles
- 👨‍💼 **User Authentication** - Secure authentication with login/logout capabilities
- 📋 **Team Task Assignments** - View all team assignments and workload distribution
- 📈 **Capacity Planning** - Monitor team capacity and workload balance
- 🏆 **Performance Rankings** - Identify top performers and improvement opportunities

### 📊 Reporting & Analytics
Advanced reporting capabilities for data-driven decision making:

- 📈 **Task Status Overview** - Real-time dashboard of all task statuses
- 📊 **Priority Distribution Reports** - Analyze task priorities across organization
- 💰 **Financial Tracking** - Comprehensive billing and cost analysis
- 📉 **Team Performance Analytics** - Compare team metrics and productivity trends
- 📅 **Date Range Reporting** - Generate custom reports for any time period
- 🎯 **Workload Analysis** - Identify bottlenecks and optimize resource allocation
- 📋 **Custom Reports** - Build tailored reports based on specific metrics
- 🔍 **Drill-Down Analytics** - Deep dive into specific tasks, teams, or employees

### 💳 Billing & Financial Management
Integrated billing system for accurate cost tracking:

- 💳 **Billing Records** - Create and manage billing entries tied to tasks
- 📝 **Task-Based Billing** - Automatic billing calculation from task data
- 💰 **Financial Reports** - Comprehensive financial analysis and trends
- 🔄 **Invoice Generation** - Generate invoices from billing records
- 📊 **Cost Allocation** - Allocate costs to projects and cost centers
- 💡 **Rate Management** - Configure billing rates and cost structures
- 📈 **Revenue Tracking** - Monitor project profitability

---

## 🎬 Quick Demo

### Create a Task
```http
POST /api/task/create HTTP/1.1
Content-Type: application/json

{
  "title": "Implement User Authentication",
  "description": "Add JWT-based authentication to the API",
  "status": "InProgress",
  "priority": "High",
  "dueDate": "2026-02-15T17:00:00",
  "assignedEmployeeId": 5,
  "createdBy": 3
}

Response: 200 OK
{
  "message": "Task created successfully.",
  "taskId": 42
}
```

### Get Employee's Tasks
```http
GET /api/task/all/5 HTTP/1.1

Response: 200 OK
[
  {
    "id": 42,
    "title": "Implement User Authentication",
    "status": "InProgress",
    "priority": "High",
    "assignedTo": "John Doe",
    "dueDate": "2026-02-15T17:00:00",
    "progressPercentage": 65
  },
  ...
]
```

### Get Team Performance
```http
GET /api/reports/team-performance HTTP/1.1

Response: 200 OK
{
  "teamName": "Development Team",
  "totalTasks": 24,
  "completedTasks": 18,
  "completionRate": 75,
  "averageCompletionTime": "4.5 days",
  "topPerformer": "Jane Smith"
}
```

---

## 🏗️ Architecture

### Three-Tier Enterprise Architecture
TaskSyncPro implements a robust three-tier architecture pattern for scalability, maintainability, and separation of concerns:

```
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃     🌐 Presentation Layer        ┃
┃  (ASP.NET Core REST API)         ┃
┃                                  ┃
┃  • Controllers (8)               ┃
┃  • HTTP Routing                  ┃
┃  • Request Validation            ┃
┃  • Response Formatting           ┃
┗━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━┛
      │
      ↓ HTTP/JSON
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃   💼 Business Logic Layer        ┃
┃  (Services & Domain Logic)       ┃
┃                                  ┃
┃  • 8 Services                    ┃
┃  • Business Rules Engine         ┃
┃  • Data Validation               ┃
┃  • 19 DTOs                       ┃
┃  • AutoMapper Configuration      ┃
┃  • Helper Utilities              ┃
┗━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━┛
      │
      ↓ Service Calls
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃   🗄️ Data Access Layer          ┃
┃  (Entity Framework Core)         ┃
┃                                  ┃
┃  • Repository Pattern            ┃
┃  • DbContext (TaskSyncDbContext) ┃
┃  • LINQ Queries                  ┃
┃  • Entity Mappings               ┃
┃  • Database Migrations           ┃
┗━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━┛
      │
      ↓ SQL Queries
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃   💾 SQL Server Database         ┃
┃  (TaskSyncPro)                   ┃
┃                                  ┃
┃  • 7 Core Tables                 ┃
┃  • Relational Integrity          ┃
┃  • Transactions Support          ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
```

### Layered Design Benefits
- **Separation of Concerns** - Each layer has a distinct responsibility
- **Maintainability** - Easy to locate and modify specific functionality
- **Testability** - Mock dependencies for comprehensive unit testing
- **Scalability** - Can scale each layer independently
- **Security** - Multiple validation checkpoints


### Project Structure

```
TaskSyncPro/                         📦 Root Solution
├── 📄 TaskSyncPro.slnx             # Solution File
├── 📄 README.md                     # Documentation
├── 📄 LICENSE                       # MIT License
│
├── 🔴 API/                         # REST API Layer
│   ├── 📄 Program.cs               # Application Entry Point & Configuration
│   ├── 📄 API.csproj               # Project Configuration
│   │
│   ├── 🟠 Controllers/             # 8 API Controllers
│   │   ├── TaskController.cs       # Task CRUD & Operations
│   │   ├── EmployeeController.cs   # Employee Management
│   │   ├── TeamController.cs       # Team Operations
│   │   ├── UserController.cs       # User Authentication & Management
│   │   ├── RoleController.cs       # Role Management
│   │   ├── TaskLogController.cs    # Task History & Logging
│   │   ├── ReportsController.cs    # Analytics & Reporting
│   │   └── BillingController.cs    # Billing Operations
│   │
│   ├── 📁 Properties/              # Launch Settings
│   ├── 📁 bin/                     # Compiled Output
│   └── 📁 obj/                     # Build Artifacts
│
├── 🟡 BLL/                         # Business Logic Layer
│   ├── 📄 MapperConfig.cs          # AutoMapper Configuration (6 mappings)
│   │
│   ├── 🟠 Services/                # 8 Service Classes
│   │   ├── TaskService.cs          # Task business logic & validation
│   │   ├── EmployeeService.cs      # Employee management logic
│   │   ├── TeamService.cs          # Team operations & hierarchy
│   │   ├── UserService.cs          # User lifecycle management
│   │   ├── RoleService.cs          # Role & permission logic
│   │   ├── TaskLogService.cs       # Activity logging
│   │   ├── ReportsService.cs       # Report generation
│   │   └── BillingService.cs       # Billing calculations
│   │
│   ├── 🟠 DTOs/                    # 19 Data Transfer Objects
│   │   ├── TaskDTO.cs
│   │   ├── EmployeeDTO.cs
│   │   ├── EmployeeDetailsDTO.cs
│   │   ├── EmployeePerformanceDTO.cs
│   │   ├── TeamDTO.cs
│   │   ├── TeamEmployeeDTO.cs
│   │   ├── TeamEmployeeTaskDTO.cs
│   │   ├── UserDTO.cs
│   │   ├── UserLoginDTO.cs
│   │   ├── UserRoleDTO.cs
│   │   ├── RoleDTO.cs
│   │   ├── TaskLogDTO.cs
│   │   ├── TaskEmployeeDTO.cs
│   │   ├── BillingRecordDTO.cs
│   │   ├── BillingTaskDTO.cs
│   │   ├── TaskStatusOverviewDTO.cs
│   │   ├── TaskPriorityOverviewDTO.cs
│   │   ├── TeamPerformanceDTO.cs
│   │   └── DateRangeDTO.cs
│   │
│   ├── 🟠 Helpers/                 # Utility Classes
│   │   ├── EmailService.cs         # Email notifications
│   │   └── PasswordGenerator.cs    # Secure password generation
│   │
│   ├── 📁 bin/                     # Compiled Output
│   └── 📁 obj/                     # Build Artifacts
│
└── 🟢 DAL/                         # Data Access Layer
    ├── 📄 DataAccessFactory.cs     # Repository Factory
    ├── 📄 ValidationException.cs   # Custom Exception
    │
    ├── 🟠 EF/                      # Entity Framework Core
    │   ├── TaskSyncDbContext.cs    # DbContext with 7 DbSets
    │   └── Models/                 # Entity Models (7 entities)
    │       ├── Role.cs
    │       ├── User.cs
    │       ├── Employee.cs
    │       ├── Team.cs
    │       ├── Task.cs
    │       ├── TaskLog.cs
    │       └── BillingRecord.cs
    │
    ├── 🟠 Interfaces/              # Data Contracts
    │   ├── IRepository.cs          # Generic repository interface
    │   ├── ITaskFeature.cs
    │   ├── IEmployeeFeature.cs
    │   ├── ITeamFeature.cs
    │   ├── IUserFeature.cs
    │   ├── IRole.cs
    │   ├── ITaskLogFeature.cs
    │   ├── IBillingFeature.cs
    │   └── IReports.cs
    │
    ├── 🟠 Repos/                   # Repository Implementations
    │   ├── EmployeeRepo.cs
    │   ├── TaskRepo.cs
    │   ├── TeamRepo.cs
    │   ├── UserRepo.cs
    │   ├── RoleRepo.cs
    │   ├── TaskLogRepo.cs
    │   ├── BillingRecordRepo.cs
    │   └── ReportRepo.cs
    │
    ├── 🟠 Migrations/              # Database Schema Versions
    │   ├── 20260113190005_initialcreate.cs
    │   ├── 20260113190005_initialcreate.Designer.cs
    │   ├── 20260114161349_FixTaskStringColumnLengths.cs
    │   ├── 20260114161349_FixTaskStringColumnLengths.Designer.cs
    │   └── TaskSyncDbContextModelSnapshot.cs
    │
    ├── 📁 bin/                     # Compiled Output
    └── 📁 obj/                     # Build Artifacts
```

---

## 🛠️ Technology Stack

### Core Framework & Language
| Technology | Version | Purpose |
|-----------|---------|---------|
| **ASP.NET Core** | 10.0 | Web API Framework |
| **C#** | Latest | Primary Language |
| **.NET** | 10.0 | Runtime Environment |

### Data & ORM
| Technology | Version | Purpose |
|-----------|---------|---------|
| **Entity Framework Core** | 9.0.11 | Object-Relational Mapper |
| **EF Core Design** | 9.0.11 | Migration Tools |
| **EF Core SQL Server** | 9.0.11 | SQL Server Provider |
| **SQL Server** | 2019+ | Relational Database |

### API & Documentation
| Technology | Version | Purpose |
|-----------|---------|---------|
| **OpenAPI** | 10.0.1 | API Specification & Swagger UI |
| **REST** | - | API Architecture |

### Object Mapping
| Technology | Version | Purpose |
|-----------|---------|---------|
| **AutoMapper** | Latest | DTO to Entity Mapping |

### Architecture Patterns
| Pattern | Usage |
|---------|-------|
| **Repository Pattern** | Data access abstraction |
| **Service Pattern** | Business logic encapsulation |
| **Dependency Injection** | Loose coupling |
| **Factory Pattern** | Repository creation |
| **DTO Pattern** | API contracts |
| **Three-Tier Architecture** | Separation of concerns |

---

## 🚀 Getting Started

### Prerequisites
- ✅ **.NET 10.0 SDK** or later ([Download](https://dotnet.microsoft.com/download))
- ✅ **SQL Server 2019** or later ([Express Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))
- ✅ **Visual Studio 2022** or **VS Code** with C# extension
- ✅ **Git** for version control

### Installation Steps

#### 1️⃣ Clone the Repository
```bash
git clone https://github.com/yourusername/TaskSyncPro.git
cd TaskSyncPro
```

#### 2️⃣ Restore NuGet Packages
```bash
# Restore all dependencies
dotnet restore

# Or restore specific project
dotnet restore API/API.csproj
dotnet restore BLL/BLL.csproj
dotnet restore DAL/DAL.csproj
```

#### 3️⃣ Configure Database Connection
Edit `API/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DbConn": "data source=YOUR_SERVER_NAME; initial catalog=TaskSyncPro; TrustServerCertificate=True; Integrated Security=True;"
  }
}
```

**Example configurations:**
```json
// Local Machine
"DbConn": "data source=.; initial catalog=TaskSyncPro; TrustServerCertificate=True; Integrated Security=True;"

// Named Instance
"DbConn": "data source=YOUR_COMPUTER\\SQLEXPRESS; initial catalog=TaskSyncPro; TrustServerCertificate=True; Integrated Security=True;"

// Azure SQL (with user/password)
"DbConn": "Server=tcp:YOUR_SERVER.database.windows.net,1433;Initial Catalog=TaskSyncPro;Persist Security Info=False;User ID=admin;Password=YourPassword;Encrypt=True;Connection Timeout=30;"
```

#### 4️⃣ Apply Database Migrations
```bash
# Navigate to API project
cd API

# Create database and apply migrations
dotnet ef database update

# Or with specific migration
dotnet ef database update --project ../DAL
```

#### 5️⃣ Run the Application
```bash
cd API
dotnet run

# Or with watch mode for development
dotnet watch run
```

✅ **Success!** API is now running at:
- 🔗 **HTTPS:** `https://localhost:5001`
- 🔗 **API Docs:** `https://localhost:5001/openapi/v1.json`
- 🔗 **Swagger UI:** `https://localhost:5001/swagger`

---

## 📚 API Endpoints

### 📝 Task Management Endpoints

#### Create Task
```http
POST /api/task/create
Content-Type: application/json

{
  "title": "string",
  "description": "string",
  "status": "Pending|InProgress|Completed|Overdue",
  "priority": "Low|Medium|High",
  "dueDate": "2026-02-15T17:00:00Z",
  "assignedEmployeeId": 5,
  "createdBy": 3
}

Response: 200 OK
{ "message": "Task created successfully." }
```

#### Get Tasks for Employee
```http
GET /api/task/all/{employeeId}

Response: 200 OK
[
  {
    "id": 1,
    "title": "Task Title",
    "status": "InProgress",
    "priority": "High",
    "dueDate": "2026-02-15T17:00:00Z"
  }
]
```

#### Update Task
```http
PUT /api/task/update
Content-Type: application/json

{
  "id": 1,
  "status": "Completed",
  "priority": "High",
  "completedAt": "2026-01-23T10:30:00Z"
}

Response: 200 OK
{ "message": "Task updated successfully." }
```

#### Delete Task
```http
DELETE /api/task/delete/{taskId}

Response: 200 OK
{ "message": "Task deleted successfully." }
```

### 👥 Employee Management Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/employee/create` | Create new employee |
| GET | `/api/employee/{id}` | Get employee details |
| PUT | `/api/employee/update` | Update employee information |
| DELETE | `/api/employee/delete/{id}` | Delete employee |
| GET | `/api/employee/performance/{id}` | Get performance metrics |

### 👨‍💼 User Management Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/user/create` | Create new user account |
| POST | `/api/user/login` | Authenticate user |
| GET | `/api/user/{id}` | Get user profile |
| PUT | `/api/user/update` | Update user information |

### 🏢 Team Management Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/team/create` | Create new team |
| GET | `/api/team/{id}` | Get team details |
| PUT | `/api/team/update` | Update team information |
| GET | `/api/team/{id}/members` | Get team members |

### 📊 Reporting Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/reports/task-status` | Task status distribution |
| GET | `/api/reports/priority-overview` | Priority distribution |
| GET | `/api/reports/team-performance` | Team performance metrics |
| GET | `/api/reports/employee-performance/{id}` | Employee metrics |
| POST | `/api/reports/date-range` | Custom date range reports |

### 💳 Billing Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/billing/record` | Create billing record |
| GET | `/api/billing/{id}` | Get billing details |
| GET | `/api/billing/employee/{empId}` | Get employee billing |
| DELETE | `/api/billing/record/{id}` | Delete billing record |

---

## 🔐 Security Features

### Authentication & Authorization
- ✅ **User Authentication** - Secure login mechanism
- ✅ **Authorization Middleware** - Route protection with role checks
- ✅ **Role-Based Access Control (RBAC)** - Fine-grained permissions
- ✅ **Role Hierarchy** - Admin > Manager > Employee > Guest

### Data Protection
- ✅ **HTTPS Enforcement** - All communications encrypted
- ✅ **Input Validation** - Multi-layer validation (Controller → Service → DB)
- ✅ **SQL Injection Prevention** - Parameterized queries via EF Core
- ✅ **Password Security** - Secure password hashing and generation

### Error Handling
- ✅ **Exception Management** - Custom exception handling
- ✅ **Sensitive Data Masking** - No sensitive info in error responses
- ✅ **Audit Logging** - Track all significant operations
- ✅ **Transaction Integrity** - Database transaction management

---

## 📊 Database Schema

### Entity Relationship Diagram

```
┌─────────────┐         ┌──────────┐
│    Role     │         │   User   │
├─────────────┤    1 ──┬┤──────────┤
│ • RoleId    │      └─┤ • UserId  │
│ • Name      │         │ • RoleId  │
│ • Created   │         └──────────┘
└─────────────┘              │
                             │ 1:1
                        ┌────▼──────────┐
                        │   Employee    │
                        ├───────────────┤
                        │ • EmployeeId  │
                        │ • UserId      │
                        │ • TeamId      │
                        │ • Position    │
                        │ • Salary      │
                        └────┬──────────┘
                             │ 1:M
                        ┌────▼──────────┐
                        │     Task      │
                        ├───────────────┤
                        │ • TaskId      │
                        │ • AssignedTo  │
                        │ • CreatedBy   │
                        │ • Status      │
                        │ • Priority    │
                        │ • DueDate     │
                        └────┬──────────┘
                             │ 1:M
                        ┌────▼──────────┐
                        │   TaskLog     │
                        ├───────────────┤
                        │ • LogId       │
                        │ • TaskId      │
                        │ • Action      │
                        │ • Timestamp   │
                        └───────────────┘

┌──────────────┐
│    Team      │
├──────────────┤
│ • TeamId     │
│ • Name       │
│ • Manager    │
│ • Created    │
└──────────────┘

┌──────────────┐
│ BillingRecord│
├──────────────┤
│ • BillingId  │
│ • TaskId     │
│ • Amount     │
│ • Date       │
│ • Status     │
└──────────────┘
```

### Core Entities

| Entity | Fields | Purpose |
|--------|--------|---------|
| **User** | UserId, RoleId, Email, Password | User accounts & authentication |
| **Role** | RoleId, Name | Role definitions |
| **Employee** | EmployeeId, UserId, TeamId, Position | Employee information |
| **Team** | TeamId, Name, Manager | Team organization |
| **Task** | TaskId, Title, AssignedTo, Status, Priority, DueDate | Task management |
| **TaskLog** | LogId, TaskId, Action, Timestamp | Activity history |
| **BillingRecord** | BillingId, TaskId, Amount, Date | Financial tracking |

---

## 🧪 Validation Rules

### Task Validation

```
✓ Status must be: Pending, InProgress, Completed, or Overdue
✓ Priority must be: Low, Medium, or High
✓ DueDate >= CreatedAt
✓ Completed tasks must have CompletedAt date
✓ Only completed tasks can have CompletedAt
✓ Overdue status requires DueDate < Today
✓ CompletedAt must not be in the future
✓ CompletedAt >= CreatedAt
✓ Cannot self-assign tasks (CreatedBy ≠ AssignedEmployeeId)
✓ InProgress tasks must be assigned to employee
```

### User Validation
```
✓ Email must be unique
✓ Email must be valid format
✓ Password must meet complexity requirements
✓ Role must exist
✓ Cannot delete user with pending tasks
```

### Employee Validation
```
✓ User must exist
✓ Email must be unique
✓ Employee position must be valid
✓ Team must exist (if assigned)
```

---

## 🎨 Design Patterns & Best Practices

### Architectural Patterns
| Pattern | Implementation | Benefit |
|---------|-----------------|---------|
| **3-Tier Architecture** | API → BLL → DAL | Clear separation of concerns |
| **Repository Pattern** | `IRepository<T>` | Data access abstraction |
| **Service Pattern** | Business services | Centralized business logic |
| **Dependency Injection** | ASP.NET Core DI | Loose coupling |
| **Factory Pattern** | DataAccessFactory | Repository creation |
| **DTO Pattern** | 19 DTOs | API contract separation |

### Coding Best Practices
- ✅ **SOLID Principles** - Single Responsibility, Open/Closed, etc.
- ✅ **DRY** - Don't Repeat Yourself throughout codebase
- ✅ **Exception Handling** - Proper try-catch with meaningful messages
- ✅ **Async/Await** - Non-blocking operations
- ✅ **Type Safety** - Nullable reference types enabled
- ✅ **Validation** - Multi-layer validation approach

---

## 📈 Performance Tips

### Database Optimization
```csharp
// Use AsNoTracking for read-only queries
var tasks = _context.Tasks.AsNoTracking().ToList();

// Eager load related entities
var employees = _context.Employees
    .Include(e => e.Team)
    .Include(e => e.Tasks)
    .ToList();

// Use pagination for large datasets
var tasks = _context.Tasks
    .Skip((page - 1) * pageSize)
    .Take(pageSize)
    .ToList();
```

### API Performance
- ✅ Enable response caching for reports
- ✅ Use pagination for list endpoints
- ✅ Implement rate limiting
- ✅ Use async operations throughout
- ✅ Monitor query performance with logging

---

## 🆘 Troubleshooting

### Common Issues

#### Database Connection Failed
**Error:** "Cannot connect to database"
```bash
# Verify connection string
# Check SQL Server is running
# Verify credentials and permissions
# Test with SQL Server Management Studio first
```

#### Migration Errors
```bash
# Remove pending migrations
dotnet ef migrations remove

# Re-apply migrations
dotnet ef database update

# View migration history
dotnet ef migrations list
```

#### Port Already in Use
```bash
# Change port in Properties/launchSettings.json
# Or use different port
dotnet run --urls "https://localhost:5002"
```

---

## ❓ FAQ

**Q: Can I modify the database schema?**
A: Yes, create a migration: `dotnet ef migrations add MigrationName`

**Q: How do I add new endpoints?**
A: Create controller in API/Controllers, service in BLL/Services, repository in DAL/Repos

**Q: How does authentication work?**
A: User login creates session, verified against User table with RoleId-based authorization

**Q: Can I use this in production?**
A: Yes, but ensure proper security configuration, SSL certificates, and database backups

**Q: How do I export reports?**
A: Use reporting endpoints, then convert response to Excel/PDF as needed

---

## 🤝 Contributing

We welcome contributions! Here's how to get involved:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/amazing-feature`)
3. **Commit** your changes (`git commit -m 'Add amazing feature'`)
4. **Push** to the branch (`git push origin feature/amazing-feature`)
5. **Open** a Pull Request

### Development Guidelines
- Follow C# naming conventions (PascalCase for public members)
- Write meaningful commit messages
- Add XML documentation for public methods
- Ensure all tests pass before submitting PR

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for complete details.

MIT License grants you:
- ✅ Freedom to use commercially
- ✅ Freedom to modify
- ✅ Freedom to distribute
- ✅ Private use

Requirements:
- Include original license and copyright notice

---

## 🙏 Acknowledgments

Built with:
- **ASP.NET Core** - Enterprise web framework
- **Entity Framework Core** - Modern ORM
- **AutoMapper** - Object mapping
- **SQL Server** - Reliable database

---

<div align="center">

### ⭐ If you find this project helpful, please give it a star!

**Made with ❤️ for enterprise teams**

[Report Bug](https://github.com/yourusername/TaskSyncPro/issues) • [Request Feature](https://github.com/yourusername/TaskSyncPro/issues) • [Documentation](https://github.com/yourusername/TaskSyncPro/wiki)

**Last Updated:** January 23, 2026

</div>
