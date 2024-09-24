using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AchatController : ControllerBase
    {
        private IAchatRepository _iAchatRepository;

        public AchatController(IAchatRepository iAchatRepository)
        {
            _iAchatRepository = iAchatRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Edit_StatusAchat")]
        public async Task<IActionResult> Edit_StatusAchat(int id)
        {
            try
            {
                var UpdateAchat = await _iAchatRepository.Edit_StatusAchat(id);
                return Ok(UpdateAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAllFacturesAchats")]
        public async Task<IActionResult> GetAllFacturesAchats()
        {
            try
            {
                var AllFactureAchat = await _iAchatRepository.GetAllFacturesAchats();
                return Ok(AllFactureAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureAchat")]
        public async Task<IActionResult> GetFactureAchat(int numFacture)
        {
            try
            {
                var GetFactureAchat = await _iAchatRepository.GetFactureAchat(numFacture);
                return Ok(GetFactureAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureParDateAchat")]
        public async Task<IActionResult> GetFactureParDateAchat(DateTime date)
        {
            try
            {
                var GetFactureAchat = await _iAchatRepository.GetFactureParDateAchat(date);
                return Ok(GetFactureAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        
    }
}
