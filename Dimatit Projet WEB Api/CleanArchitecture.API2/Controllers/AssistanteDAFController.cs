using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AssistanteDAFController : ControllerBase
    {
        private IAssistate_DAFRepository _iAssistate_DAFRepository;
        public AssistanteDAFController(IAssistate_DAFRepository iAssistate_DAFRepository)
        {
            _iAssistate_DAFRepository = iAssistate_DAFRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Edit_StatusAssDAF")]
        public async Task<IActionResult> Edit_StatusAssDAF(int id)
        {
            try
            {
                var UpdateAchat = await _iAssistate_DAFRepository.Edit_StatusAssDAF(id);
                return Ok(UpdateAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAllFacturesAssDAF")]
        public async Task<IActionResult> GetAllFacturesAssDAF()
        {
            try
            {
                var AllFactureAchat = await _iAssistate_DAFRepository.GetAllFacturesAssDAF();
                return Ok(AllFactureAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
           
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureAssDAF")]
        public async Task<IActionResult> GetFactureAssDAF(int numFacAss)
        {
            try
            {
                var GetFactureAchat = await _iAssistate_DAFRepository.GetFactureAssDAF(numFacAss);
                return Ok(GetFactureAchat);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureParDateAssDAF")]
        public async Task<IActionResult> GetFactureParDateAssDAF(DateTime date)
        {
            try
            {
                var GetFactureAchat = await _iAssistate_DAFRepository.GetFactureParDateAssDAF(date);
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
