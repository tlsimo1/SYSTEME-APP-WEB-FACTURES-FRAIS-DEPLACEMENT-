using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelService _iPersonnelService;
        public PersonnelController(IPersonnelService iPersonnelService)
        {
            this._iPersonnelService = iPersonnelService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllPersonnel()
        {
            var Personnel = await _iPersonnelService.GetAllAsync();
            return Ok(Personnel);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetPersonnelById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Personnel = await _iPersonnelService.GetByIdAsync(id);
            return Ok(Personnel);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost("CreatePersonnel")]
        public async Task<IActionResult> Create(Personnel personnel)
        {
            var createdPersonnel = await _iPersonnelService.CreateAsync(personnel);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatePersonnel/{id}")]
        public async Task<IActionResult> Update(int id, Personnel personnel)
        {
            int existingPersonnel = await _iPersonnelService.UpdateAsync(id, personnel);
            if (existingPersonnel == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePersonnel/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int personnel = await _iPersonnelService.DeleteAsync(id);
            if (personnel == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetBy_Name_Mat")]
        public async Task<IActionResult> GetByName_Mat(string Mat_Name)
        {
            var Personnel = await _iPersonnelService.GetBy_Mat_Nom_Async(Mat_Name);
            return Ok(Personnel);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetBy_Mat_CA")]
        public async Task<IActionResult> Get_Mat_CA_Async(int id)
        {
            var Personnel = await _iPersonnelService.Get_Mat_CA_Async(id);
            return Ok(Personnel);
        }
    }
}
