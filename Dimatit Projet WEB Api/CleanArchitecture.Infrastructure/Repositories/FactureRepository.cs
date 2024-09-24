using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class FactureRepository : IFactureRepository
    {
        DateTime? newdate = null;

        private readonly BlogDbContext _blocDbContext;
        public FactureRepository(BlogDbContext blocDbContext)
        {
            this._blocDbContext = blocDbContext;
        }
        public async Task<IEnumerable<dynamic>> GetAllFacture()
        {
            dynamic ListFacture = await (from f in _blocDbContext.Facture
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
                                           
                                            select new
                                            {
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
            return ListFacture;
        }
        public async Task<dynamic> GetDetail(int id)
        {
            dynamic ListFacture = await (from f in _blocDbContext.Facture
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

                                         where f.ID_facture== id
                                         select new
                                         {
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
            return ListFacture;
        }
        public async Task<dynamic> GetFacture(string numFac)
        {
            dynamic ListFacture = await (from f in _blocDbContext.Facture
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

                                         where f.NumFacture == numFac
                                         select new
                                         {
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
            return ListFacture;
        }
        public async Task<IEnumerable<dynamic>> GetFactureParDate(DateTime date)
        {
            dynamic ListFacture = await (from f in _blocDbContext.Facture
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

                                         where f.Date_Facture == date
                                         select new
                                         {
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
            return ListFacture;
        }
        public async Task<IEnumerable<dynamic>> GetFactureParFournisseur(string fournisseur)
        {
            dynamic ListFacture = await (from f in _blocDbContext.Facture
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

                                         where f.Fournisseur == fournisseur
                                         select new
                                         {
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
            return ListFacture;
        }
        public async Task<IEnumerable<Facture>> ImpFacture(DateTime date)
        {
            dynamic ListFacture = await _blocDbContext.Facture.Where(f => f.Date_Saisie == date).ToListAsync();
            return ListFacture;
        }
        public async Task<int> DeleteFacture(int id)
        {
            var bureuOrdre=  await _blocDbContext.Bureau_Ordre.Where( b => b.id_facture == id ).FirstAsync();
                                _blocDbContext.Remove(bureuOrdre );
                                _blocDbContext.SaveChanges();

            var AssistanteDaf = await _blocDbContext.Assistate_DAF.Where(b => b.id_facture == id).FirstAsync();
                                 _blocDbContext.Remove(AssistanteDaf);
                                 _blocDbContext.SaveChanges();

            var chefCmp = await _blocDbContext.Chef_Comptabilite.Where(b => b.id_facture == id).FirstAsync();
                                _blocDbContext.Remove(chefCmp);
                                _blocDbContext.SaveChanges();

            var cmp = await _blocDbContext.Comptabilite.Where(b => b.id_facture == id).FirstAsync();
                                _blocDbContext.Remove(cmp);
                                _blocDbContext.SaveChanges();


            var achat = await _blocDbContext.Achat.Where(b => b.id_facture == id).FirstAsync();
                                _blocDbContext.Remove(achat);
                                _blocDbContext.SaveChanges();

            var facture = await _blocDbContext.Facture.Where(b => b.ID_facture == id).FirstAsync();
                                _blocDbContext.Remove(facture);
                                _blocDbContext.SaveChanges();

            return 1;


        }
        public async Task<Facture> Insert_Facture(Facture facture)
        {
            
         
            await _blocDbContext.Facture.AddAsync(facture);
            await _blocDbContext.SaveChangesAsync();


            Bureau_Ordre _bureau_Ordre = new Bureau_Ordre();
            _bureau_Ordre.id_facture = facture.ID_facture;
            _bureau_Ordre.Fac_Num = facture.NumFacture;
            _bureau_Ordre.Statut = 1;
            _bureau_Ordre.Date_Saisie = facture.Date_Saisie;
            await _blocDbContext.Bureau_Ordre.AddAsync(_bureau_Ordre);
            await _blocDbContext.SaveChangesAsync();



            Assistate_DAF _assistate_DAF = new Assistate_DAF();
            _assistate_DAF.id_facture = facture.ID_facture;
            _assistate_DAF.Fac_Num = facture.NumFacture;
            _assistate_DAF.Statut = 0;
            _assistate_DAF.Date_Saisie = Convert.ToDateTime(newdate);
            await _blocDbContext.Assistate_DAF.AddAsync(_assistate_DAF);
            await _blocDbContext.SaveChangesAsync();


            Chef_Comptabilite _chef_Comptabilite = new Chef_Comptabilite();
            _chef_Comptabilite.id_facture = facture.ID_facture;
            _chef_Comptabilite.Fac_Num = facture.NumFacture;
            _chef_Comptabilite.Statut = 0;
            _chef_Comptabilite.Date_Saisie = Convert.ToDateTime(newdate);
            await _blocDbContext.Chef_Comptabilite.AddAsync(_chef_Comptabilite);
            await _blocDbContext.SaveChangesAsync();

            Comptabilite _comptabilite = new Comptabilite();
            _comptabilite.id_facture = facture.ID_facture;
            _comptabilite.Fac_Num = facture.NumFacture;
            _comptabilite.Statut = 0;
            _comptabilite.Date_Comptabilisation = Convert.ToDateTime(newdate);
            _comptabilite.Date_Saisie = Convert.ToDateTime(newdate);
            _comptabilite.Statut_Final = 0;
            await _blocDbContext.Comptabilite.AddAsync(_comptabilite);
            await _blocDbContext.SaveChangesAsync();

            Achat _achat = new Achat();
            _achat.id_facture = facture.ID_facture;
            _achat.Fac_Num = facture.NumFacture;
            _achat.Statut = 0;
            _achat.Date_Saisie = Convert.ToDateTime(newdate);
            await _blocDbContext.Achat.AddAsync(_achat);
            await _blocDbContext.SaveChangesAsync();


           

            return facture;
        }
        public async Task<int> UpdateFacture(Facture facture)
        {
            

            var _facture = await _blocDbContext.Facture.Where(f => f.ID_facture == facture.ID_facture).FirstAsync();
            _facture.Fournisseur = facture.Fournisseur;
            _facture.NumFacture = facture.NumFacture;
            _facture.Date_Facture = facture.Date_Facture;
            _facture.TotalTTC=facture.TotalTTC;
            _facture.Date_Saisie= facture.Date_Saisie;
            await _blocDbContext.SaveChangesAsync();


           
            var _bureauOrdre = await _blocDbContext.Bureau_Ordre.Where(f => f.id_facture == facture.ID_facture).FirstAsync();
            _bureauOrdre.Fac_Num = facture.NumFacture;
            //_bureauOrdre.Statut=facture.StatutBrd;
            //_bureauOrdre.Date_Saisie = facture.Date_SaisieBrd;
            await _blocDbContext.SaveChangesAsync();

            var _assDaf = await _blocDbContext.Assistate_DAF.Where(f => f.id_facture == facture.ID_facture).FirstAsync();
            _assDaf.Fac_Num = facture.NumFacture;
            //_assDaf.Statut = facture.StatutAss;
            //_assDaf.Date_Saisie = facture.Date_SaisieAss;
            await _blocDbContext.SaveChangesAsync();


            var _chefCmp = await _blocDbContext.Chef_Comptabilite.Where(f => f.id_facture == facture.ID_facture).FirstAsync();
            _chefCmp.Fac_Num = facture.NumFacture;
            //_chefCmp.Statut = facture.StatutCh;
            //_chefCmp.Date_Saisie = facture.Date_SaisieCh;
            await _blocDbContext.SaveChangesAsync();

            var _cmp = await _blocDbContext.Comptabilite.Where(f => f.id_facture == facture.ID_facture).FirstAsync();
            _cmp.Fac_Num = facture.NumFacture;
            //_cmp.Statut = facture.StatutCm;
            //_cmp.Date_Saisie = facture.Date_SaisieCm;
            await _blocDbContext.SaveChangesAsync();

            var _cmpp = await _blocDbContext.Comptabilite.Where(f => f.id_facture == facture.ID_facture).FirstAsync();
            _cmpp.Fac_Num = facture.NumFacture;
            //_cmpp.Statut = facture.StatutCm;
            //_cmpp.Date_Saisie = facture.Date_SaisieCm;
            //_cmpp.Date_Comptabilisation = facture.Date_Comptabilisation;
            //_cmpp.Statut_Final=facture.StatutFinal;
            await _blocDbContext.SaveChangesAsync();


            var _achat = await _blocDbContext.Achat.Where(f => f.id_facture == facture.ID_facture).FirstAsync();
            _achat.Fac_Num = facture.NumFacture;
            //_cmpp.Statut = facture.StatutCm;
            //_cmpp.Date_Saisie = facture.Date_SaisieCm;
            //_cmpp.Date_Comptabilisation = facture.Date_Comptabilisation;
            //_cmpp.Statut_Final=facture.StatutFinal;
            await _blocDbContext.SaveChangesAsync();

            return 1;
        }
    }
}
