using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class Code_AnalytiqueRepository : ICode_AnalytiqueRepository
    {
        private readonly BlogDbContext _blocDbContext;
        public Code_AnalytiqueRepository(BlogDbContext blocDbContext)
        {
            this._blocDbContext = blocDbContext;
        }
        public async Task<Code_Analytique> CreateAsync(Code_Analytique code_Analytique)
        {
            await _blocDbContext.AddAsync(code_Analytique);
            await _blocDbContext.SaveChangesAsync();
            return code_Analytique;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var codeAnalytique = await _blocDbContext.code_Analytique.FirstOrDefaultAsync(x => x.ID_Analytique == id);
            _blocDbContext.code_Analytique.Remove(codeAnalytique);
            return await _blocDbContext.SaveChangesAsync();
        }

        public async Task<List<Code_Analytique>> GetAllAsync()
        {
            return await _blocDbContext.code_Analytique.ToListAsync();
        }

        public async Task<Code_Analytique> GetByCodeAsync(string code)
        {
            return  await _blocDbContext.code_Analytique.FirstOrDefaultAsync(x => x.CodeAnalytique == code);
        }

        public async Task<Code_Analytique> GetByIdAsync(int id)
        {
            var codeAnalytique = await _blocDbContext.code_Analytique.FirstOrDefaultAsync(x => x.ID_Analytique == id);
            return codeAnalytique;
        }

        public Task<int> UpdateAsync(int id, Code_Analytique code_Analytique)
        {
            Code_Analytique _code_Analytique = _blocDbContext.code_Analytique.Where(x => x.ID_Analytique == id).FirstOrDefault();
            _code_Analytique.Activite_Service = code_Analytique.Activite_Service;
            _code_Analytique.CodeAnalytique = code_Analytique.CodeAnalytique;
            _code_Analytique.Activite_Service = code_Analytique.Activite_Service;
            return _blocDbContext.SaveChangesAsync();
        }
    }
}
