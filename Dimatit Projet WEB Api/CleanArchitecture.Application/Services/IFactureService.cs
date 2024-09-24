using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IFactureService
    {
        Task<Facture> Insert_Facture(Facture facture);
        Task<IEnumerable<dynamic>> GetAllFacture();
        Task<dynamic> GetDetail(int id);
        Task<dynamic> GetFacture(string numFac);
        Task<IEnumerable<dynamic>> GetFactureParDate(DateTime date);
        Task<int> DeleteFacture(int id);
        Task<int> UpdateFacture(Facture Facture);
        Task<IEnumerable<dynamic>> GetFactureParFournisseur(string fournisseur);
        Task<IEnumerable<Facture>> ImpFacture(DateTime date);
    }
}
