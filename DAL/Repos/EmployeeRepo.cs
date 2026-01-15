using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

internal class EmployeeRepo : IEmployeeFeature
{
    private readonly TaskSyncDbContext db;

    public EmployeeRepo(TaskSyncDbContext db)
    {
        this.db = db;
    }
    public bool ExistsForUser(int userId)
    {
        return db.Employees.Any(e => e.UserId == userId);
    }

    public bool ExistsForTeamDesignation(int teamId, string designation)
    {
        return db.Employees.Any(e => e.TeamId == teamId && e.Designation == designation);
    }
    public Employee FindByUserEmail(string email)
    {
        return db.Employees.Include(e => e.User).Include(e => e.Team).FirstOrDefault(e => e.User.Email == email);
    }

    public Employee GetEmployeeWithDetails(int id)
    {
        return db.Employees .Include(e => e.User).Include(e => e.Team).Include(e => e.Tasks).FirstOrDefault(e => e.Id == id);

    }

    public List<Employee> GetEmployeeWithDetails()
    {
        return db.Employees.Include(e => e.User).Include(e => e.Team).Include(e => e.Tasks).ToList();
    }

}
