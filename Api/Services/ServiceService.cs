﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Repositories;
using Microsoft.EntityFrameworkCore;

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
        public List<Service> GetList(int pageNumber, int pageSize)
        {
            return _repo.GetList(pageNumber, pageSize);
        }
        public async Task<Service> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repo.Delete(id);
        }
        public async Task<List<Service>> SearchByName(String name, int pageNumber, int pageSize)
        {
            return await _repo.SearchByName(name, pageNumber, pageSize);
        }
        public async Task<List<Service>> SearchByCenterId(Guid centerId, int pageNumber, int pageSize)
        {
            return await _repo.SearchByCenterId(centerId, pageNumber, pageSize);
        }
        public async Task<List<Service>> SearchByNameAndCenterId(Guid centerId, String name, int pageNumber, int pageSize)
        {
            return await _repo.SearchByNameAndCenterId(centerId, name, pageNumber, pageSize);
        }
        public async Task<List<Service>> Search(string nameService, Guid animalId, Guid serviceTypeId)
        {
            return await _repo.Search(nameService, animalId, serviceTypeId);
        }

    }
}
