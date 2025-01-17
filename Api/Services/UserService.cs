﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Models;
using Api.Repositories;

namespace Api.Services
{
    public class UserService
    {
        private readonly IUserRepository<User> _repo;
        public UserService(IUserRepository<User> repo)
        {
            _repo = repo;
        }
        public async Task<User> Create(User user)
        {
            return await _repo.Create(user);
        }
        public string Login(string email)
        {
            return _repo.Login(email);
        }
        public User GetByEmail(string email)
        {
            return _repo.GetByEmail(email);
        }
        public async Task<List<User>> GetList(Guid roleId, int pageNumber, int pageSize)
        {
            return await _repo.GetList(roleId, pageNumber, pageSize);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repo.Delete(id);
        }
        public async Task<bool> Update(User newUser)
        {
            return await _repo.Update(newUser);
        }
    }
}
