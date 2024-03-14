using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context) 
        => _context = context;

    public async Task<User> GetUser()
        => await _context.Users
            .OrderByDescending(u => u.Orders.Count)
            .FirstAsync();

    public async Task<List<User>> GetUsers()
        => await _context.Users
            .Where(u => u.Status == UserStatus.Inactive)
            .ToListAsync();
}