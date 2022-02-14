﻿using System;
namespace Api.Models
{
    public class UpdateUserModal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public Guid RoleId { get; set; }
    }
}