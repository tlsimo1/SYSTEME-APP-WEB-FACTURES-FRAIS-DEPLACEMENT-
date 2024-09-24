using CleanArchitecture.Domain.Entities;
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
    public class AchatRepository : IAchatRepository
    {
        private readonly BlogDbContext _blocDbContext;
        public AchatRepository(BlogDbContext blocDbContext)
        {
            this._blocDbContext = blocDbContext;
        }
        public async Task<int> Edit_StatusAchat(int id)
        {
            var achat = await _blocDbContext.Achat.FirstOrDefaultAsync(a => a.id_facture == id);
            if (achat == null)
            {
                return await Task.FromResult(0);
            }
            else
            {
                achat.Statut = 1;
                achat.Date_Saisie = DateTime.Now;
                await _blocDbContext.SaveChangesAsync();
            }
            return achat.id_facture;
        }

        public async Task<IEnumerable<dynamic>> GetAllFacturesAchats()
        {
            dynamic ListFactureAchat = await (from f in _blocDbContext.Facture
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

                                              where a.Statut == 0 && cmp.Statut == 1
                                              select new
                                              {
                                                  a.Id,
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
            return ListFactureAchat;
        }

        public async Task<dynamic> GetFactureAchat(int numFac)
        {
            dynamic FactureAchat = await (from f in _blocDbContext.Facture
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

                                          where a.Statut == 0 && cmp.Statut == 1 && a.Id == numFac
                                          select new
                                          {
                                              a.Id,
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
            return FactureAchat;
        }

        public async Task<dynamic> GetFactureParDateAchat(DateTime date)
        {
            dynamic FactureAchatParDate = await (from f in _blocDbContext.Facture
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

                                                 where a.Statut == 0 && cmp.Statut == 1 && f.Date_Saisie == date
                                                 select new
                                                 {
                                                     a.Id,
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
            return FactureAchatParDate;
        }
    }
}
