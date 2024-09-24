using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interface
{
    public interface ICode_AnalytiqueRepository
    {
        Task<List<Code_Analytique>> GetAllAsync();
        Task<Code_Analytique> GetByIdAsync(int id);
        Task<Code_Analytique> GetByCodeAsync(string code);
        Task<Code_Analytique> CreateAsync(Code_Analytique code_Analytique);
        Task<int> UpdateAsync(int id, Code_Analytique code_Analytique);
        Task<int> DeleteAsync(int id);
    }
}
