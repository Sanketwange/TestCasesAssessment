using OrderAPP.Repo;
using OrderAPP.Repo.Abstract;

namespace OrderAPP.Services
{
    public class UserAuthService
    {
        private readonly IUserRepo _userRepository;

        public UserAuthService(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user != null;
        }

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 8)
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            if (!password.Any(char.IsDigit))
                return false;

            return true;
        }
    }
}
