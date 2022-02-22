﻿using System;
using System.Threading.Tasks;
using Api.Entities;
using Api.Modals;

namespace Api.Repositories
{
    public interface IUserRepository<T>
    {
        Task<User> Create(User user);
        string Login(LoginModel loginModel);
        User GetByEmail(string email);
        Task<bool> Delete(Guid id);
        Task<bool> Update(User newUser);
    }
}
