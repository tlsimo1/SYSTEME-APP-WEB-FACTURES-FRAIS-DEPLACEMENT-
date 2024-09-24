using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class Code_AnalytiqueService : ICode_AnalytiqueService
    {
        private ICode_AnalytiqueRepository _iCode_AnalytiqueRepository;
        public Code_AnalytiqueService(ICode_AnalytiqueRepository iCode_AnalytiqueRepository)
        {
            _iCode_AnalytiqueRepository = iCode_AnalytiqueRepository;
        }
        public async Task<Code_Analytique> CreateAsync(Code_Analytique code_Analytique)
        {
            return await _iCode_AnalytiqueRepository.CreateAsync(code_Analytique);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _iCode_AnalytiqueRepository.DeleteAsync(id);
        }

        public async Task<List<Code_Analytique>> GetAllAsync()
        {
            return await _iCode_AnalytiqueRepository.GetAllAsync();
        }

        public async Task<Code_Analytique> GetByCodeAsync(string code)
        {
            return await _iCode_AnalytiqueRepository.GetByCodeAsync(code);
        }

        public async Task<Code_Analytique> GetByIdAsync(int id)
        {
            return await _iCode_AnalytiqueRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(int id, Code_Analytique code_Analytique)
        {
            return await _iCode_AnalytiqueRepository.UpdateAsync(id, code_Analytique);
        }
    }
}
