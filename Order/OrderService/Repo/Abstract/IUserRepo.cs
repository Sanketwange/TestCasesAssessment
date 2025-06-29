using Solution.Core.Entity;

namespace OrderAPP.Repo.Abstract
{
    public interface IUserRepo
    {
        public Task<Users?> GetUserByEmailAsync(string email);
        public Task<Users?> GetUserById(int Id);
    }
}
