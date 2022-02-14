﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Repositories;

namespace Api.Services
{
    public class ServiceService
    {
        private readonly IServiceRepository<Service> _repo;
        public ServiceService(IServiceRepository<Service> repo)
        {
            _repo = repo;
        }
        public async Task<Service> Create(Service service)
        {
            return await _repo.Create(service);
        }
        public async Task<bool> Update(Service newService)
        {
            return await _repo.Update(newService);
        }
        public async Task<Service> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }
        public List<Service> GetAll()
        {
            return _repo.GetAll();
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repo.Delete(id);
        }
    }
}
