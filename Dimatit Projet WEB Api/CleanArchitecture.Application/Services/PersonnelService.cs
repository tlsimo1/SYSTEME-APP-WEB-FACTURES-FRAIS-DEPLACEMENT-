using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class PersonnelService : IPersonnelService
    {
        private IPersonnelRepository _iPersonnelRepository;
        public PersonnelService(IPersonnelRepository iPersonnelRepository)
        {
            _iPersonnelRepository = iPersonnelRepository;
        }
        public async Task<Personnel> CreateAsync(Personnel personnel)
        {
            return await _iPersonnelRepository.CreateAsync(personnel);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _iPersonnelRepository.DeleteAsync(id);

        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            return await _iPersonnelRepository.GetAllAsync();
        }

        public async Task<dynamic> GetByIdAsync(int id)
        {
            return await _iPersonnelRepository.GetByIdAsync(id);
        }

        public async Task<Personnel> GetBy_Mat_Nom_Async(string Mat_Nom)
        {
            return await _iPersonnelRepository.GetBy_Mat_Nom_Async(Mat_Nom);
        }

        public async Task<dynamic> Get_Mat_CA_Async(int id)
        {
            return await _iPersonnelRepository.Get_Mat_CA_Async(id);
        }

        public async Task<int> UpdateAsync(int id, Personnel personnel)
        {
            return await _iPersonnelRepository.UpdateAsync(id, personnel);
        }
    }
}
