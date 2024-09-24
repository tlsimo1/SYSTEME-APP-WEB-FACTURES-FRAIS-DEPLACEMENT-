using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _iAuthRepository;

        public AuthController(IAuthRepository iAuthRepository)
        {
            _iAuthRepository = iAuthRepository;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest obj)
        {
            try
            {
                var token = await _iAuthRepository.Login(obj);
                var UserInfo= await _iAuthRepository.GetInfoUserAuth(obj);
                var subjects = Tuple.Create(token, UserInfo);
                return Ok(subjects);
            }
            catch (Exception)
            {
                return NotFound();
            }     
        }

        [HttpPost("assignRole")]
        public async Task<bool> AssignRoleToUser( AddUserRole userRole)
        {
            var addedUserRole = await _iAuthRepository.AssignRoleToUser(userRole);
            return addedUserRole;
        }

        [HttpPost("addUser")]
        public async Task<User> AddUser( User user)
        {
            var addeduser = await _iAuthRepository.AddUser(user);
            return addeduser;
        }

        [HttpPost("addRole")]
        public async Task<Role> AddRole( Role role)
        {
            var addedRole = await _iAuthRepository.AddRole(role);
            return addedRole;
        }
    }
}
