using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Infra.Data.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly GlobCartOrderServiceContext globCartOrderServiceContext;

        public AuthenticationRepository(GlobCartOrderServiceContext globCartOrderServiceContext)
        {
            this.globCartOrderServiceContext = globCartOrderServiceContext;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            //byte[] passwordHash;
            //byte[] passwordSalt;

            //_CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //user.PasswordHash = passwordHash;
            //user.PasswordSalt = passwordSalt;

            user.Id = Guid.NewGuid();
            user.Name = user.Name;
            user.Email = user.Email;
            user.Password = password;

            await globCartOrderServiceContext.Users.AddAsync(user);
            await globCartOrderServiceContext.SaveChangesAsync();

            return user;

        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await globCartOrderServiceContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;

            //if (!_VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //    return null;

            return user;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            if (await globCartOrderServiceContext.Users.AnyAsync(x => x.Email == email))
                return true;

            return false;
        }

        private void _CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash
                    (System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool _VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash
                    (System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
