using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class FraisDeplacementController : ControllerBase
    {
        private IFrais_DeplacementRepository _iFrais_DeplacementRepository;
        public FraisDeplacementController(IFrais_DeplacementRepository iFrais_DeplacementRepository)
        {
            _iFrais_DeplacementRepository = iFrais_DeplacementRepository;
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> GetAllFraisDeplacement()
        {
            dynamic fraisDeplacement = await _iFrais_DeplacementRepository.GetAllAsync();
            return Ok(fraisDeplacement);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFraisDeplacementById")]
        public async Task<IActionResult> GetById(int id)
        {
            var FraisDeplacement = await _iFrais_DeplacementRepository.GetByIdAsync(id);
            return Ok(FraisDeplacement);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost("CreateFraisDeplacement")]
        public async Task<IActionResult> Create(Frais_Deplacement fraisDeplacement)
        {
            var createFraisDeplacement= await _iFrais_DeplacementRepository.CreateAsync(fraisDeplacement);
            return Ok(createFraisDeplacement);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateFraisDeplacement/{id}")]
        public async Task<IActionResult> Update(int id, Frais_Deplacement frais_Deplacement)
        {
            int existingFraisDeplacement = await _iFrais_DeplacementRepository.UpdateAsync(id, frais_Deplacement);
            if (existingFraisDeplacement == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteFraisDeplacement/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int idFrais = await _iFrais_DeplacementRepository.DeleteAsync(id);
            if (idFrais == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFraisDeplacementByNameOrMat")]
        public async Task<IActionResult> GetBy_Mat_Nom_Async(string Mat_Nom)
        {
            var fraisDeplacment = await _iFrais_DeplacementRepository.GetBy_Mat_Nom_Async(Mat_Nom);
            return Ok(fraisDeplacment);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFraisDeplacementByDate")]
        public async Task<IActionResult> GetParDate_Async(DateTime date)
        {
            var fraisDeplacment = await _iFrais_DeplacementRepository.GetParDate_Async(date);
            return Ok(fraisDeplacment);
        }

        
        
    }
}
