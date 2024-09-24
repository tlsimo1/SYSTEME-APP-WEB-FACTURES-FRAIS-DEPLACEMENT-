using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IFrais_DeplacementService
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<Frais_Deplacement> GetByIdAsync(int id);
        Task<dynamic> GetBy_Mat_Nom_Async(string Mat_Nom);
        Task<IEnumerable<dynamic>>GetParDate_Async(DateTime date);
        Task<Frais_Deplacement> CreateAsync(Frais_Deplacement frais_Deplacement);
        Task<int> UpdateAsync(int id, Frais_Deplacement frais_Deplacement);
        Task<int> DeleteAsync(int id);
    }
}
