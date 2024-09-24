using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ComptabiliteController : ControllerBase
    {
        private IComptabiliteRepository _iComptabiliteRepository;

        public ComptabiliteController(IComptabiliteRepository iComptabiliteRepository)
        {
            _iComptabiliteRepository = iComptabiliteRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Edit_StatusCmp")]
        public async Task<IActionResult> Edit_StatusCmp(int id)
        {
            try
            {
                var UpdateAchat = await _iComptabiliteRepository.Edit_StatusCmp(id);
                return Ok(UpdateAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAllFacturesCmp")]
        public async Task<IActionResult> GetAllFacturesCmp()
        {
            try
            {
                var AllFactureAchat = await _iComptabiliteRepository.GetAllFacturesCmp();
                return Ok(AllFactureAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureCmp")]
        public async Task<IActionResult> GetFactureCmp(int numFacture)
        {
            try
            {
                var GetFactureAchat = await _iComptabiliteRepository.GetFactureCmp(numFacture);
                return Ok(GetFactureAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureParDateCmp")]
        public async Task<IActionResult> GetFactureParDateCmp(DateTime date)
        {
            try
            {
                var GetFactureAchat = await _iComptabiliteRepository.GetFactureParDateCmp(date);
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
