using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class Frais_DeplacementRepository : IFrais_DeplacementRepository
    {
        private readonly BlogDbContext _blocDbContext;
        public Frais_DeplacementRepository(BlogDbContext blocDbContext)
        {
            this._blocDbContext = blocDbContext;
        }
        public async Task<Frais_Deplacement> CreateAsync(Frais_Deplacement frais_Deplacement)
        {
            await _blocDbContext.frais_Deplacement.AddAsync(frais_Deplacement);
            await _blocDbContext.SaveChangesAsync();
            return frais_Deplacement;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var fraisDept = await _blocDbContext.frais_Deplacement.FirstOrDefaultAsync(x => x.ID_Frais == id);
            _blocDbContext.frais_Deplacement.Remove(fraisDept);
            return await _blocDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
           dynamic ListFraisdeplacemet = await _blocDbContext.frais_Deplacement.ToListAsync();
           
            return ListFraisdeplacemet;
        }

        public async Task<int> UpdateAsync(int id, Frais_Deplacement frais_Deplacement)
        {
            var fraisDeptUpdate = await _blocDbContext.frais_Deplacement.FirstOrDefaultAsync(x => x.ID_Frais == id);
            fraisDeptUpdate.Frais_Kilometrique = frais_Deplacement.Frais_Kilometrique;
            fraisDeptUpdate.FraisDeplacement = frais_Deplacement.FraisDeplacement;
            fraisDeptUpdate.Periode_Deplacement = frais_Deplacement.Periode;
            fraisDeptUpdate.Circulation = frais_Deplacement.Circulation;
            fraisDeptUpdate.Date_Regelement = frais_Deplacement.Date_Regelement;
            fraisDeptUpdate.Reprise_Frais = frais_Deplacement.Reprise_Frais;
            fraisDeptUpdate.Date_Avancement = frais_Deplacement.Date_Avancement;
            fraisDeptUpdate.Montant_Avance = frais_Deplacement.Montant_Avance;
            fraisDeptUpdate.Mat_PER = frais_Deplacement.Mat_PER;
            fraisDeptUpdate.Ville_Region = frais_Deplacement.Ville_Region;
            fraisDeptUpdate.Mode_Reglement = frais_Deplacement.Mode_Reglement;
            fraisDeptUpdate.Date_Preparation = frais_Deplacement.Date_Preparation;
            fraisDeptUpdate.Periode_De = frais_Deplacement.Periode_De;
            fraisDeptUpdate.Periode = frais_Deplacement.Periode;
            fraisDeptUpdate.Personnel_id = frais_Deplacement.Personnel_id;
            return await _blocDbContext.SaveChangesAsync();
        }

        public async Task<dynamic> GetBy_Mat_Nom_Async(string Mat_Nom)
        {
            dynamic ListFraisdeplacemetParMatNom = await _blocDbContext.frais_Deplacement
                                                         .Where(x => x.Mat_PER.Equals(Mat_Nom)).ToListAsync();

            return ListFraisdeplacemetParMatNom;
        }

        public async Task<IEnumerable<dynamic>> GetParDate_Async(DateTime date)
        {
            dynamic ListFraisdeplacemetParDate =  _blocDbContext.frais_Deplacement.AsEnumerable().
                Where(x=> Convert.ToDateTime(x.Date_Saisie.ToString("dd/MM/yyyy")) == Convert.ToDateTime(date.ToString("dd/MM/yyyy")));

            return await Task.FromResult(ListFraisdeplacemetParDate);
        }

        public async Task<dynamic> GetByIdAsync(int id)
        {
            var fraisDept = await _blocDbContext.frais_Deplacement.FirstOrDefaultAsync(x => x.ID_Frais == id);
            return fraisDept;
        }
    }
}
