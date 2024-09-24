using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class Frais_DeplacementService : IFrais_DeplacementService
    {
        private IFrais_DeplacementRepository _iFrais_DeplacementRepository;
        public Frais_DeplacementService(IFrais_DeplacementRepository ifFrais_DeplacementRepository)
        {
            _iFrais_DeplacementRepository = ifFrais_DeplacementRepository;
        }
        public async Task<Frais_Deplacement> CreateAsync(Frais_Deplacement frais_Deplacement)
        {
            return await _iFrais_DeplacementRepository.CreateAsync(frais_Deplacement);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _iFrais_DeplacementRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            return await _iFrais_DeplacementRepository.GetAllAsync();
        }

        public async Task<Frais_Deplacement> GetByIdAsync(int id)
        {
            return await _iFrais_DeplacementRepository.GetByIdAsync(id);
        }

        public async Task<dynamic> GetBy_Mat_Nom_Async(string Mat_Nom)
        {
            return await _iFrais_DeplacementRepository.GetBy_Mat_Nom_Async(Mat_Nom);
        }

        public async Task<IEnumerable<dynamic>> GetParDate_Async(DateTime date)
        {
            return await _iFrais_DeplacementRepository.GetParDate_Async(date);
        }

        public async Task<int> UpdateAsync(int id, Frais_Deplacement frais_Deplacement)
        {
            return await _iFrais_DeplacementRepository.UpdateAsync(id, frais_Deplacement);
        }
    }
}
