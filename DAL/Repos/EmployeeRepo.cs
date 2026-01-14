using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

internal class EmployeeRepo : IRepository<Employee>, IEmployeeFeature
{
    private readonly TaskSyncDbContext db;

    public EmployeeRepo(TaskSyncDbContext db)
    {
        this.db = db;
    }

    public bool Create(Employee entity)
    {
        if (!db.Users.Any(u => u.Id == entity.UserId))
            throw new InvalidOperationException("User does not exist.");

        if (!db.Teams.Any(t => t.Id == entity.TeamId))
            throw new InvalidOperationException("Team does not exist.");

        if (db.Employees.Any(e => e.UserId == entity.UserId))
            throw new InvalidOperationException("Employee already exists for this user.");

        if (db.Employees.Any(e =>
            e.TeamId == entity.TeamId &&
            e.Designation == entity.Designation))
            throw new InvalidOperationException("Duplicate designation in the same team.");

        db.Employees.Add(entity);
        return db.SaveChanges() > 0;
    }

    public List<Employee> Find()
    {
        return db.Employees.ToList();
    }

    public Employee Find(int id)
    {
        var employee = db.Employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
            throw new Exception("Employee not found.");

        return employee;
    }

    public bool Update(Employee entity)
    {
        var employee = db.Employees.FirstOrDefault(e => e.Id == entity.Id);
        if (employee == null)
            throw new InvalidOperationException("Employee not found.");

        // Do NOT allow changing UserId via update payload
        var effectiveUserId = employee.UserId;

        if (!db.Users.Any(u => u.Id == effectiveUserId))
            throw new InvalidOperationException("User does not exist.");

        if (!db.Teams.Any(t => t.Id == entity.TeamId))
            throw new InvalidOperationException("Team does not exist.");

        if (db.Employees.Any(e => e.UserId == effectiveUserId && e.Id != entity.Id))
            throw new ApplicationException("Another employee with this user already exists.");

        // only update allowed fields
        employee.TeamId = entity.TeamId;
        employee.Designation = entity.Designation;
        employee.IsAvailable = entity.IsAvailable;

        return db.SaveChanges() > 0;
    }


    public bool Delete(int id)
    {
        var employee = Find(id);
        db.Employees.Remove(employee);
        return db.SaveChanges() > 0;
    }

    public Employee FindByUserEmail(string email)
    {
        return db.Employees
            .Include(e => e.User)
            .Include(e => e.Team)
            .FirstOrDefault(e => e.User.Email == email);
    }

    public Employee GetEmployeeWithDetails(int id)
    {
        return db.Employees
            .Include(e => e.User)
            .Include(e => e.Team)
            .Include(e => e.Tasks)
            .FirstOrDefault(e => e.Id == id);

    }

    public List<Employee> GetEmployeeWithDetails()
    {
        return db.Employees
            .Include(e => e.User)
            .Include(e => e.Team)
            .Include(e => e.Tasks)
            .ToList();
    }

}
