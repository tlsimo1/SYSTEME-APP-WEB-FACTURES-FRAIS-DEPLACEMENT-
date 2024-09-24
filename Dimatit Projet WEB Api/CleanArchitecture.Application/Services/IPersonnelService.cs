using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IPersonnelService
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<dynamic> GetByIdAsync(int id);
        Task<Personnel> GetBy_Mat_Nom_Async(string Mat_Nom);
        Task<dynamic> Get_Mat_CA_Async(int id);
        Task<Personnel> CreateAsync(Personnel personnel);
        Task<int> UpdateAsync(int id, Personnel personnel);
        Task<int> DeleteAsync(int id);
    }
}
