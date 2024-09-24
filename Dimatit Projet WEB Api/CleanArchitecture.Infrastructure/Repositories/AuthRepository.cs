using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly BlogDbContext _blocDbContext;
        public AuthRepository(IConfiguration configuration, BlogDbContext blocDbContext)
        {
            this._configuration = configuration;
            this._blocDbContext = blocDbContext;
        }
        public async Task<Role> AddRole(Role role)
        {
            var addedRole = await _blocDbContext.Roles.AddAsync(role);
             _blocDbContext.SaveChanges();
            return addedRole.Entity;
        }

        public async Task<User> AddUser(User user)
        {
            var addedUser = await _blocDbContext.Users.AddAsync(user);
            _blocDbContext.SaveChanges();
            return addedUser.Entity;
        }

        public async Task<bool> AssignRoleToUser(AddUserRole obj)
        {
            try
            {
                var addRoles = new List<UserRole>();
                var user = await _blocDbContext.Users.SingleOrDefaultAsync(s => s.Id == obj.UserId);
                if (user == null)
                    throw new Exception("user is not valid");
                foreach (int role in obj.RoleIds)
                {
                    var userRole = new UserRole();
                    userRole.RoleId = role;
                    userRole.UserId = user.Id;
                    addRoles.Add(userRole);
                }
                _blocDbContext.UserRoles.AddRange(addRoles);
                _blocDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<GetInfoUserAuth> GetInfoUserAuth(LoginRequest obj)
        {
            char[] delimiters = { ',', ';' };
            string[] listeRole = {};
            List<string> list=new List<string>();
            List<GetInfoUserAuth> ListRole =   await (from u in _blocDbContext.Users
                                              join ur in _blocDbContext.UserRoles
                                              on u.Id equals ur.UserId
                                              join r in _blocDbContext.Roles
                                              on ur.RoleId equals r.Id
                                              where u.Username == obj.Username
                                              select new GetInfoUserAuth
                                              {
                                                  Username = obj.Username,
                                                  Password = obj.Password,
                                                  Roles = r.Name.Split(delimiters, StringSplitOptions.RemoveEmptyEntries),
                                              }).ToListAsync();
            foreach (var item in ListRole)
            {
                foreach (var item2 in item.Roles)
                {
                    list.Add(item2);
                }
            }
            var infoUser = await (from u in _blocDbContext.Users
                                  join ur in _blocDbContext.UserRoles
                                  on u.Id equals ur.UserId
                                  join r in _blocDbContext.Roles
                                  on ur.RoleId equals r.Id
                                  where u.Username == obj.Username
                                  select new GetInfoUserAuth
                                  {
                                      Username = obj.Username,
                                      Password = obj.Password,
                                      Roles = list.ToArray()
                                  }).FirstAsync();
            return infoUser;
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            if (loginRequest.Username != null && loginRequest.Password != null)
            {
                var user = await _blocDbContext.Users.SingleOrDefaultAsync(s => s.Username == loginRequest.Username && s.Password == loginRequest.Password);
                if (user != null)
                {
                    var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.Name)
                    };
                    var userRoles = await _blocDbContext.UserRoles.Where(u => u.UserId == user.Id).ToListAsync();
                    var roleIds =  userRoles.Select(s => s.RoleId).ToList();
                    var roles = await _blocDbContext.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;
                }
                else
                {
                    throw new Exception("user is not valid");
                }
            }
            else
            {
                throw new Exception("credentials are not valid");
            }
        }
       
    }
}
