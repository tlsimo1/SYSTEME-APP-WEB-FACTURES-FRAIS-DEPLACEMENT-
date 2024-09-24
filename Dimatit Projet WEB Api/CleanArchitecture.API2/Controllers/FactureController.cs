using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class FactureController : ControllerBase
    {
        private IFactureRepository _iFactureRepository;

        public FactureController(IFactureRepository iFactureRepository)
        {
            _iFactureRepository = iFactureRepository;
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost("CreateFacture")]
        public async Task<IActionResult> CreateFacture(Facture facture)
        {
            try
            {
                await _iFactureRepository.Insert_Facture(facture);
                return Ok(facture);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAllFacture")]
        public async Task<IActionResult> GetAllFacture()
        {
            
            try
            {
              var AllFacture=  await _iFactureRepository.GetAllFacture();
                return Ok(AllFacture);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetDetailFacture")]
        public async Task<IActionResult> GetDetailFacture(int id)
        {

            try
            {
                var Facture = await _iFactureRepository.GetDetail(id);
                return Ok(Facture);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureParFournisseur")]
        public async Task<IActionResult> GetFactureParFournisseur(string  fournisseur)
        {

            try
            {
                var Facture = await _iFactureRepository.GetFactureParFournisseur(fournisseur);
                return Ok(Facture);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetFactureParDate")]
        public async Task<IActionResult> GetFactureParDate(DateTime date)
        {

            try
            {
                var Facture = await _iFactureRepository.GetFactureParDate(date);
                return Ok(Facture);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteFacture")]
        public async Task<IActionResult> DeleteFacture(int id)
        {

            try
            {
                var Facture = await _iFactureRepository.DeleteFacture(id);
                return Ok(Facture);
            }
            catch (Exception ex)
            {
                throw new Exception();
                //return ex.Message.ToString();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateFacture")]
        public async Task<IActionResult> UpdateFacture(Facture facture)
        {
            var fraisDeplacment = await _iFactureRepository.UpdateFacture(facture);
            return Ok(fraisDeplacment);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetEtat")]
        public async Task<IActionResult> GetEtat(DateTime date)
        {
            var fraisDeplacment = await _iFactureRepository.ImpFacture(date);
            return Ok(fraisDeplacment);
        }
    }
}
