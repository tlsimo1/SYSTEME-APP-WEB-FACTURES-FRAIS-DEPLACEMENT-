using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Chef_ComptabiliteController : ControllerBase
    {
        private IChef_ComptabiliteRepository _iChef_ComptabiliteRepository;

        public Chef_ComptabiliteController(IChef_ComptabiliteRepository iChef_ComptabiliteRepository)
        {
            _iChef_ComptabiliteRepository = iChef_ComptabiliteRepository;
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("Edit_StatusChefCmp")]
        public async Task<IActionResult> Edit_StatusChefCmp(int id)
        {
            try
            {
                var UpdateAchat = await _iChef_ComptabiliteRepository.Edit_StatusChefCmp(id);
                return Ok(UpdateAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAllFacturesChefCmp")]
        public async Task<IActionResult> GetAllFacturesChefCmp()
        {
            try
            {
                var AllFactureAchat = await _iChef_ComptabiliteRepository.GetAllFacturesChefCmp();
                return Ok(AllFactureAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureChefCmp")]
        public async Task<IActionResult> GetFactureChefCmp(int numFacture)
        {
            try
            {
                var GetFactureAchat = await _iChef_ComptabiliteRepository.GetFactureChefCmp(numFacture);
                return Ok(GetFactureAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureParDateChefCmp")]
        public async Task<IActionResult> GetFactureParDateChefCmp(DateTime date)
        {
            try
            {
                var GetFactureAchat = await _iChef_ComptabiliteRepository.GetFactureParDateChefCmp(date);
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
