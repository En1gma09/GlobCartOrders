﻿using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GlobCartOrderServiceContext globCartOrderServiceContext;

        public UserRepository(GlobCartOrderServiceContext globCartOrderServiceContext)
        {
            this.globCartOrderServiceContext = globCartOrderServiceContext;
        }

        public ICollection<User> GetAll()
        {
            return globCartOrderServiceContext.Users.ToList();
        }

        public User GetByEmail(string email, string password)
        {
                return globCartOrderServiceContext
                    .Users
                    .Include(u => u.Email)
                    .FirstOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password));
        }

        ValidationResult<User> IUserRepository.Create(User user)
        {
            var result = new ValidationResult<User>(user);

            user.Id = Guid.NewGuid();

            if (result.IsValid)
            {
                globCartOrderServiceContext.Users.Add(user);
                globCartOrderServiceContext.SaveChanges();
            }

            return result;
        }

        public void Commit()
        {
            globCartOrderServiceContext.SaveChanges();
        }
    }
}
