using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.Application.Services
{
    public class FactureService : IFactureService
    {
        private IFactureRepository _repository;
        public FactureService(IFactureRepository repository)
        {
            _repository=  repository;
        }
        public async Task<int> DeleteFacture(int id)
        {
            return await _repository.DeleteFacture(id);
        }

        public async Task<IEnumerable<dynamic>> GetAllFacture()
        {
            return await _repository.GetAllFacture();
        }

        public async Task<dynamic> GetDetail(int id)
        {
            return await _repository.GetDetail(id);
        }

        public async Task<dynamic> GetFacture(string numFac)
        {
            return await _repository.GetFacture(numFac);
        }

        public async Task<IEnumerable<dynamic>> GetFactureParDate(DateTime date)
        {
            return await _repository.GetFactureParDate(date);
        }

        public async Task<IEnumerable<dynamic>> GetFactureParFournisseur(string fournisseur)
        {
            return await _repository.GetFactureParFournisseur(fournisseur);
        }

        public async Task<IEnumerable<Facture>> ImpFacture(DateTime date)
        {
            return await _repository.ImpFacture(date);
        }

        public async Task<Facture> Insert_Facture(Facture facture)
        {
            return await _repository.Insert_Facture(facture);
        }

        public async Task<int> UpdateFacture(Facture Facture)
        {
            return await _repository.UpdateFacture(Facture);
        }
    }
}
