﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Api.Repositories
{
    public class ServiceTypeRepository : IServiceTypeRepository<ServiceType>
    {
        private readonly DataContext _context;
        public ServiceTypeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceType> Create(ServiceType serviceType)
        {
            serviceType.Status = "active";
            await _context.ServiceType.AddAsync(serviceType);
            await _context.SaveChangesAsync();
            return serviceType;
        }
        public async Task<bool> Update(ServiceType newServiceType)
        {
            ServiceType serviceType = _context.ServiceType.AsNoTracking().FirstOrDefault(x => x.Id == newServiceType.Id && x.Status.Equals("active"));
            if (serviceType == null)
            {
                return false;
            }
            _context.ServiceType.Update(newServiceType);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<ServiceType> GetById(Guid id)
        {
            ServiceType serviceType = await _context.ServiceType.Where(x => x.Id == id && x.Status.Equals("active")).FirstOrDefaultAsync();
            if (serviceType == null)
            {
                return null;
            }
            return serviceType;
        }
        public List<ServiceType> GetList(int pageNumber, int pageSize)
        {
            if (pageNumber == 0 && pageSize == 0)
            {
                return _context.ServiceType.Where(x => x.Status.Equals("active")).ToList();
            }
            return _context.ServiceType.Where(x => x.Status.Equals("active")).ToPagedList(pageNumber, pageSize).ToList();
        }
        public async Task<bool> Delete(Guid id)
        {
            ServiceType serviceType = await _context.ServiceType.FirstOrDefaultAsync(x => x.Id == id && x.Status.Equals("active"));
            if (serviceType == null)
            {
                return false;
            }
            serviceType.Status = "inactive";
            // _context.ServiceType.Remove(serviceType);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
