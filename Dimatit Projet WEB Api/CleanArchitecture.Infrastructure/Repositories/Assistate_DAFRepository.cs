using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class Assistate_DAFRepository : IAssistate_DAFRepository
    {
        private readonly BlogDbContext _blocDbContext;
        public Assistate_DAFRepository(BlogDbContext blocDbContext)
        {
            this._blocDbContext = blocDbContext;
        }
        public async Task<int> Edit_StatusAssDAF(int id)
        {
            var assDaf = await _blocDbContext.Assistate_DAF.FirstOrDefaultAsync(a => a.id_facture == id);
            if (assDaf == null)
            {
                return await Task.FromResult(0);
            }
            else
            {
                assDaf.Statut = 1;
                assDaf.Date_Saisie= DateTime.Now;
                await _blocDbContext.SaveChangesAsync();
            }
            return assDaf.id_facture;
        }

        public async Task<IEnumerable<dynamic>> GetAllFacturesAssDAF()
        {
            dynamic ListFactureAssDaf = await (from f in _blocDbContext.Facture
                                               join a in _blocDbContext.Achat on f.ID_facture equals a.id_facture into ac
                                               from a in ac.DefaultIfEmpty()

                                               join ass in _blocDbContext.Assistate_DAF on a.id_facture equals ass.id_facture into assD
                                               from ass in assD.DefaultIfEmpty()

                                               join bdr in _blocDbContext.Bureau_Ordre on ass.id_facture equals bdr.id_facture into bdrD
                                               from bdr in bdrD.DefaultIfEmpty()

                                               join cmp in _blocDbContext.Comptabilite on bdr.id_facture equals cmp.id_facture into cmpD
                                               from cmp in cmpD.DefaultIfEmpty()

                                               join ch in _blocDbContext.Chef_Comptabilite on cmp.id_facture equals ch.id_facture into chD
                                               from ch in chD.DefaultIfEmpty()

                                               where bdr.Statut == 1 && ass.Statut==0
                                               select new
                                               {
                                                   ass.Id,
                                                   f.ID_facture,
                                                   f.NumFacture,
                                                   f.Fournisseur,
                                                   f.Date_Facture,
                                                   f.TotalTTC,

                                                   Statut_BureauOrdre =
                                                   (
                                                     bdr.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                                   bdr.Date_Saisie,
                                                   Statut_AssitanteDAF =
                                                   (
                                                     ass.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                                   DateDaf = ass.Date_Saisie,
                                                   Statut_ChefComptable =
                                                   (
                                                     ch.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                                   DateChef = ch.Date_Saisie,
                                                   Statut_Comptabilite =
                                                   (
                                                     cmp.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                                   Datecmp = ch.Date_Saisie,
                                                   Statut_Achat =
                                                   (
                                                     a.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                                   DateAchat = a.Date_Saisie,
                                                   Statut_Comptabilisation =
                                                   (
                                                     cmp.Statut_Final == 1 ? "Validé" : "Non Valide"
                                                   ),
                                                   DateComptabilisation = cmp.Date_Comptabilisation,

                                               }).ToListAsync();
            return ListFactureAssDaf;
        }

        public async Task<dynamic> GetFactureAssDAF(int numFacAss)
        {
            dynamic FactureAssDaf = await (from f in _blocDbContext.Facture
                                           join a in _blocDbContext.Achat on f.ID_facture equals a.id_facture into ac
                                           from a in ac.DefaultIfEmpty()

                                           join ass in _blocDbContext.Assistate_DAF on a.id_facture equals ass.id_facture into assD
                                           from ass in assD.DefaultIfEmpty()

                                           join bdr in _blocDbContext.Bureau_Ordre on ass.id_facture equals bdr.id_facture into bdrD
                                           from bdr in bdrD.DefaultIfEmpty()

                                           join cmp in _blocDbContext.Comptabilite on bdr.id_facture equals cmp.id_facture into cmpD
                                           from cmp in cmpD.DefaultIfEmpty()

                                           join ch in _blocDbContext.Chef_Comptabilite on cmp.id_facture equals ch.id_facture into chD
                                           from ch in chD.DefaultIfEmpty()

                                           where ass.Id== numFacAss
                                           select new
                                           {
                                               ass.Id,
                                               f.ID_facture,
                                               f.NumFacture,
                                               f.Fournisseur,
                                               f.Date_Facture,
                                               f.TotalTTC,

                                               Statut_BureauOrdre =
                                                   (
                                                     bdr.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                               bdr.Date_Saisie,
                                               Statut_AssitanteDAF =
                                                   (
                                                     ass.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                               DateDaf = ass.Date_Saisie,
                                               Statut_ChefComptable =
                                                   (
                                                     ch.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                               DateChef = ch.Date_Saisie,
                                               Statut_Comptabilite =
                                                   (
                                                     cmp.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                               Datecmp = ch.Date_Saisie,
                                               Statut_Achat =
                                                   (
                                                     a.Statut == 1 ? "Validé" : "Non Valide"
                                                   ),
                                               DateAchat = a.Date_Saisie,
                                               Statut_Comptabilisation =
                                                   (
                                                     cmp.Statut_Final == 1 ? "Validé" : "Non Valide"
                                                   ),
                                               DateComptabilisation = cmp.Date_Comptabilisation,

                                           }).FirstAsync();
            return FactureAssDaf;
        }

        public async Task<dynamic> GetFactureParDateAssDAF(DateTime date)
        {
            dynamic FactureAssDaf = await (from f in _blocDbContext.Facture
                                           join a in _blocDbContext.Achat on f.ID_facture equals a.id_facture into ac
                                           from a in ac.DefaultIfEmpty()

                                           join ass in _blocDbContext.Assistate_DAF on a.id_facture equals ass.id_facture into assD
                                           from ass in assD.DefaultIfEmpty()

                                           join bdr in _blocDbContext.Bureau_Ordre on ass.id_facture equals bdr.id_facture into bdrD
                                           from bdr in bdrD.DefaultIfEmpty()

                                           join cmp in _blocDbContext.Comptabilite on bdr.id_facture equals cmp.id_facture into cmpD
                                           from cmp in cmpD.DefaultIfEmpty()

                                           join ch in _blocDbContext.Chef_Comptabilite on cmp.id_facture equals ch.id_facture into chD
                                           from ch in chD.DefaultIfEmpty()

                                           where bdr.Statut == 1 && f.Date_Facture == date
                                           select new
                                           {
                                               ass.Id,
                                               f.ID_facture,
                                               f.NumFacture,
                                               f.Fournisseur,
                                               f.Date_Facture,
                                               f.TotalTTC,

                                               Statut_BureauOrdre =
                                                  (
                                                    bdr.Statut == 1 ? "Validé" : "Non Valide"
                                                  ),
                                               bdr.Date_Saisie,
                                               Statut_AssitanteDAF =
                                                  (
                                                    ass.Statut == 1 ? "Validé" : "Non Valide"
                                                  ),
                                               DateDaf = ass.Date_Saisie,
                                               Statut_ChefComptable =
                                                  (
                                                    ch.Statut == 1 ? "Validé" : "Non Valide"
                                                  ),
                                               DateChef = ch.Date_Saisie,
                                               Statut_Comptabilite =
                                                  (
                                                    cmp.Statut == 1 ? "Validé" : "Non Valide"
                                                  ),
                                               Datecmp = ch.Date_Saisie,
                                               Statut_Achat =
                                                  (
                                                    a.Statut == 1 ? "Validé" : "Non Valide"
                                                  ),
                                               DateAchat = a.Date_Saisie,
                                               Statut_Comptabilisation =
                                                  (
                                                    cmp.Statut_Final == 1 ? "Validé" : "Non Valide"
                                                  ),
                                               DateComptabilisation = cmp.Date_Comptabilisation,

                                           }).FirstAsync();
            return FactureAssDaf;
        }
    }
}
