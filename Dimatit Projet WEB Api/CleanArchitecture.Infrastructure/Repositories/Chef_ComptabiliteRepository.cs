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
    public class Chef_ComptabiliteRepository : IChef_ComptabiliteRepository
    {
        private readonly BlogDbContext _blocDbContext;
        public Chef_ComptabiliteRepository(BlogDbContext blocDbContext)
        {
            this._blocDbContext = blocDbContext;
        }
        public async Task<int> Edit_StatusChefCmp(int id)
        {
            var chefCmp = await _blocDbContext.Chef_Comptabilite.FirstOrDefaultAsync(a => a.id_facture == id);
            if (chefCmp == null)
            {
                return await Task.FromResult(0);
            }
            else
            {
                chefCmp.Statut = 1;
                chefCmp.Date_Saisie = DateTime.Now;
                await _blocDbContext.SaveChangesAsync();
            }
            return chefCmp.id_facture;
        }

        public async Task<IEnumerable<dynamic>> GetAllFacturesChefCmp()
        {
            dynamic ListFactureChefCmp = await (from f in _blocDbContext.Facture
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

                                               where ch.Statut == 0 && ass.Statut==1
                                               select new
                                               {
                                                   ch.Id,
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
            return ListFactureChefCmp;
        }

        public async Task<dynamic> GetFactureChefCmp(int numFac)
        {
            dynamic FactureChefCmp = await (from f in _blocDbContext.Facture
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

                                                where ch.Statut == 0 && ass.Statut == 1 && ch.Id== numFac
                                                select new
                                                {
                                                    ch.Id,
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
            return FactureChefCmp;
        }

        public async Task<dynamic> GetFactureParDateChefCmp(DateTime date)
        {
            dynamic FactureChefCmp = await (from f in _blocDbContext.Facture
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

                                            where ch.Statut == 0 && ass.Statut == 1 && f.Date_Facture == date
                                            select new
                                            {
                                                ch.Id,
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
            return FactureChefCmp;
        }
    }
}
