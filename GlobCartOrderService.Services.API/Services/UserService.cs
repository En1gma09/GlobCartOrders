using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Infra.Data.Context;
using GlobCartOrderService.Infra.Data.Repository;

namespace GlobCartOrderService.Services.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        //private readonly GlobCartOrderServiceContext _globCartOrderServiceContext;

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


            //var getUser = _userRepository.GetByEmail(user.Email, user.Password);

            //if (getUser == null)
            //    result.Errors.Add($"Usuário {user.Email} não encontrado.");
            //else
            //{
            //    //user.Id = Guid.NewGuid();
            //    user.Name = getUser.Name;
            //    user.Email = getUser.Email;
            //    user.Password = getUser.Password;
            //}

            if (result.IsValid)
            {
                _userRepository.Create(user);
                _userRepository.Commit();
            }

            return result;

            //_globCartOrderServiceContext.Users.Add(user);
            //_userRepository.Commit();

            //return user;
        }
    }
}
