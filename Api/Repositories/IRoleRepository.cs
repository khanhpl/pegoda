﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Repositories
{
    public interface IRoleRepository<T>
    {
        Task<Role> Create(Role role);
        Task<bool> Update(Role newRole);
        Task<Role> GetById(Guid id);
        List<Role> GetList();
        Task<bool> Delete(Guid id);
    }
}
