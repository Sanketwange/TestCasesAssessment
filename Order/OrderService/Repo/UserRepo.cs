using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderAPP.Repo.Abstract;
using Solution.Core.Entity;
using Solution.Persistence;
using System.Security.Claims;

namespace OrderAPP.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly UserDbContext _dbContext;

        public UserRepo( UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Users?> GetUserById(int Id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == Id);
        }

    }
}
