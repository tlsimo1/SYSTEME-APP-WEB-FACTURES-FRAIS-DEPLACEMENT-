using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EtatController : ControllerBase
    {
        private IEtatsService _iEtatsService;
        public EtatController(IEtatsService iEtatsService)
        {
            this._iEtatsService = iEtatsService;
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("Get_Frais_ANT")]
        public async Task<IActionResult> Get_Frais_ANT()
        {
            dynamic etatANT = await _iEtatsService.Get_Frais_ANT();
            return Ok(etatANT);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("Get_Frais_Avancement")]
        public async Task<IActionResult> Get_Frais_Avancement()
        {
            dynamic etatANT = await _iEtatsService.Get_Frais_Avancement();
            return Ok(etatANT);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("Get_Frais_Circulation")]
        public async Task<IActionResult> Get_Frais_Circulation(string etat)
        {
            dynamic etatANT = await _iEtatsService.Get_Frais_Circulation(etat);
            return Ok(etatANT);
        }
        //[Authorize(Roles = "Admin,User")]
        [HttpGet("Get_Frais_ParModReglement")]
        public async Task<IActionResult> Get_Frais_ParModReglement(string mode)
        {
            dynamic etatANT = await _iEtatsService.Get_Frais_ParModReglement(mode);
            return Ok(etatANT);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("Get_Frais_Provision")]
        public async Task<IActionResult> Get_Frais_Provision(DateTime datedebut, DateTime dateFin)
        {
            dynamic etatANT = await _iEtatsService.Get_Frais_Provision(datedebut, dateFin);
            return Ok(etatANT);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("Get_Frais_ParVirement")]
        public async Task<IActionResult> Get_Frais_ParVirement(string mode)
        {
            dynamic etatANT = await _iEtatsService.Get_Frais_ParVirement(mode);
            return Ok(etatANT);
        }
       
    }
}
