using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CodeAnalytiqueController : ControllerBase
    {
        private readonly ICode_AnalytiqueService _iCode_AnalytiqueService;

        public CodeAnalytiqueController(ICode_AnalytiqueService iCode_AnalytiqueService)
        {
            this._iCode_AnalytiqueService = iCode_AnalytiqueService;
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> GetAllCodeAnalytiquel()
        {
            var CodeAnalytique = await _iCode_AnalytiqueService.GetAllAsync();
            return Ok(CodeAnalytique);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetCodeAnaytiqueById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var codeAnalytique = await _iCode_AnalytiqueService.GetByIdAsync(id);
            return Ok(codeAnalytique);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost("CreateCodeAnalytique")]
        public async Task<IActionResult> Create(Code_Analytique CodeAnalytique)
        {
            var createCodeAnalytique = await _iCode_AnalytiqueService.CreateAsync(CodeAnalytique);
            return Ok(createCodeAnalytique);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateCodeAnalytique/{id}")]
        public async Task<IActionResult> Update(int id, Code_Analytique CodeAnalytique)
        {
            int existingCodeAnalytique = await _iCode_AnalytiqueService.UpdateAsync(id, CodeAnalytique);
            if (existingCodeAnalytique == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteCodeAnalytique/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int codeAnalytique = await _iCode_AnalytiqueService.DeleteAsync(id);
            if (codeAnalytique == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetByCodeAsync")]
        public async Task<IActionResult> GetByCodeAsync(string code)
        {
            var codeAnalytique = await _iCode_AnalytiqueService.GetByCodeAsync(code);
            return Ok(codeAnalytique);
        }
    }
}
