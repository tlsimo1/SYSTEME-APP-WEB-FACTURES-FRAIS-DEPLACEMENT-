using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _iAuthRepository;

        public AuthService(IAuthRepository iAuthRepository)
        {
            this._iAuthRepository = iAuthRepository;
        }
        public async Task<Role> AddRole(Role role)
        {
            return await _iAuthRepository.AddRole(role);
        }

        public async Task<User> AddUser(User user)
        {
           return await _iAuthRepository.AddUser(user);
        }

        public async Task<bool> AssignRoleToUser(AddUserRole obj)
        {
           return await _iAuthRepository.AssignRoleToUser(obj);
        }

        public async Task<GetInfoUserAuth> GetInfoUserAuth(LoginRequest loginRequest)
        {
            return await _iAuthRepository.GetInfoUserAuth(loginRequest);
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
           return await _iAuthRepository.Login(loginRequest);
        }
    }
}
