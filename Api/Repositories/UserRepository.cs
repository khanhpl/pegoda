﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Api.Models;
using Google.Apis.Util;
using Microsoft.EntityFrameworkCore;
using quiz_app_dotnet_api.Helper;
using X.PagedList;

namespace Api.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly DataContext _context;
        private readonly IJwtHelper _jwtHelper;
        public UserRepository(DataContext context, IJwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }
        public async Task<User> Create(User user)
        {
            user.Status = "active";
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public User GetByEmail(string email)
        {
            User user = _context.User.FirstOrDefault(u => u.Email == email && u.Status.Equals("active"));
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public string Login(string email)
        {
            User user = _context.User.FirstOrDefault(u => u.Email == email && u.Status.Equals("active"));
            if (user == null)
            {
                return null;
            }
            Role role = _context.Role.FirstOrDefault(u => u.Id == user.RoleId);
            Center center;
            Staff staff;
            Guid centerId = Guid.Empty;
            if (role.Name == "CENTER")
            {
                center = _context.Center.FirstOrDefault(c => c.Email == user.Email && c.Status.Equals("active"));
                centerId = center.Id;
            }
            else if (role.Name == "STAFF")
            {
                staff = _context.Staff.FirstOrDefault(s => s.Email == user.Email && s.Status.Equals("active"));
                centerId = staff.CenterId;
            }
            return _jwtHelper.generateJwtToken(user, role, centerId);
        }
        public async Task<bool> Delete(Guid id)
        {
            User user = await _context.User.FirstOrDefaultAsync(u => u.Id == id && u.Status == "active");
            // _context.User.Remove(user);
            user.Status = "inactive";
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(User newUser)
        {
            User user = await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.Id == newUser.Id && x.Status.Equals("active"));
            if (user == null)
            {
                return false;
            }
            _context.User.Update(newUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetList(Guid roleId, int pageNumber, int pageSize)
        {
            if (pageNumber == 0 && pageSize == 0)
            {
                return await _context.User.Where(x => x.RoleId == roleId && x.Status.Equals("active")).ToListAsync();
            }
            else
            {
                return await _context.User.Where(x => x.RoleId == roleId && x.Status.Equals("active")).ToPagedList(pageNumber, pageSize).ToListAsync();
            }
        }
    }
}
