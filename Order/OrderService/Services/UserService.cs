using Microsoft.EntityFrameworkCore;
using OrderAPP.Repo;
using OrderAPP.Repo.Abstract;
using Solution.Core.Entity;

namespace OrderAPP.Services
{
    public class UserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        public async Task<Users?> GetUserByEmailAsync(string email)
        {
            return await _userRepo.GetUserByEmailAsync(email);
        }

        public async Task<Users?> GetUserById(int Id)
        {
            return await _userRepo.GetUserById(Id);
        }
    }
}
