using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Infra.Data.Context;
using GlobCartOrderService.Infra.Data.Repository;

namespace GlobCartOrderService.Services.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository;
        }

        public User GetUser(string email, string password)
        {
            return _userRepository.GetByEmail(email, password);
        }

        public ValidationResult<User> CreateUser(User user)
        {
            var result = new ValidationResult<User>(user);

            user.Name = user.Name;
            user.Email = user.Email;
            user.Password = user.Password;

            if (result.IsValid)
            {
                _userRepository.Create(user);
                _userRepository.Commit();
            }

            return result;
        }
    }
}
