﻿using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IAuthService
    {
        Task<User> AddUser(User user);
        Task<string> Login(LoginRequest loginRequest);
        Task<Role> AddRole(Role role);
        Task<bool> AssignRoleToUser(AddUserRole obj);
        Task<GetInfoUserAuth> GetInfoUserAuth(LoginRequest obj);
    }
}
