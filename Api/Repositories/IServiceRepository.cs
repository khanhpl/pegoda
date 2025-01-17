﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Repositories
{
    public interface IServiceRepository<T>
    {
        Task<Service> Create(Service service);
        Task<bool> Update(Service newService);
        Task<Service> GetById(Guid id);
        List<Service> GetList(int pageNumber, int pageSize);
        Task<bool> Delete(Guid id);
        Task<List<Service>> SearchByName(String name, int pageNumber, int pageSize);
        Task<List<Service>> SearchByCenterId(Guid centerId, int pageNumber, int pageSize);
        Task<List<Service>> SearchByNameAndCenterId(Guid centerId, String name, int pageNumber, int pageSize);
        Task<List<Service>> Search(string nameService, Guid animalId, Guid serviceTypeId);

    }
}
