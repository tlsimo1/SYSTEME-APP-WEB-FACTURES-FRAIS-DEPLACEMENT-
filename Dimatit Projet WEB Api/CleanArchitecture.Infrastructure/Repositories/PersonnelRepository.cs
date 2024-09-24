using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PersonnelRepository : IPersonnelRepository
    {
        private readonly BlogDbContext _blocDbContext;
        public PersonnelRepository(BlogDbContext blocDbContext)
        {
            this._blocDbContext = blocDbContext;
        }
        public async Task<Personnel> CreateAsync(Personnel personnel)
        {
            await _blocDbContext.personnel.AddAsync(personnel);
            await _blocDbContext.SaveChangesAsync();
            return personnel;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var deletePersonnel = await _blocDbContext.personnel.FirstOrDefaultAsync(x => x.ID_Personnel == id);
             _blocDbContext.personnel.Remove(deletePersonnel);
            return await _blocDbContext.SaveChangesAsync();
        }

        public async  Task<IEnumerable<dynamic>> GetAllAsync()
        {
            dynamic listEmployee = new List<dynamic>();

             listEmployee = await (from p in _blocDbContext.personnel
                                       join ca in _blocDbContext.code_Analytique
                                       on p.Analytique_id equals ca.ID_Analytique into ps_jointable
                                       from ps in ps_jointable.DefaultIfEmpty()
                                       select new
                                       {
                                           ID_Personnel = p.ID_Personnel,
                                           Matricule = p.Matricule,
                                           Nom = p.Nom,
                                           Analytique_id = p.Analytique_id==null?0: p.Analytique_id,

                                           ID_Analytique = ps.ID_Analytique == null ? 0 : ps.ID_Analytique,
                                           CodeAnalytique = ps.CodeAnalytique == null ? "" : ps.CodeAnalytique,
                                           Activite_Service = ps.Activite_Service == null ? "" : ps.Activite_Service
                                       }).ToListAsync();

            return listEmployee;
        }

        public async Task<dynamic> GetByIdAsync(int id)
        {
            dynamic Personnel =await (from p in _blocDbContext.personnel.Where(x=>x.ID_Personnel==id)
                                      join ca in _blocDbContext.code_Analytique
                                on p.Analytique_id equals ca.ID_Analytique into ps_jointable
                                from ps in ps_jointable.DefaultIfEmpty()
                                select new
                                {
                                    ID_Personnel = p.ID_Personnel,
                                    Matricule = p.Matricule,
                                    Nom = p.Nom,
                                    Analytique_id = p.Analytique_id == null ? 0 : p.Analytique_id,

                                    ID_Analytique = ps.ID_Analytique == null ? 0 : ps.ID_Analytique,
                                    CodeAnalytique = ps.CodeAnalytique == null ? "" : ps.CodeAnalytique,
                                    Activite_Service = ps.Activite_Service == null ? "" : ps.Activite_Service
                                }).FirstOrDefaultAsync();


            return  Personnel;
        }

        public async Task<Personnel> GetBy_Mat_Nom_Async(string Mat_Nom)
        {
            var personnel = await _blocDbContext.personnel.FirstOrDefaultAsync(x => x.Nom.Contains(Mat_Nom) || x.Matricule.Contains(Mat_Nom));
            return personnel;


        }

        public async Task<dynamic> Get_Mat_CA_Async(int id)
        {
            var Per_Mat_Ca = await (from p in _blocDbContext.personnel
                                    join ca in _blocDbContext.code_Analytique
                                    on p.Analytique_id equals ca.ID_Analytique
                                    where p.ID_Personnel == id
                                    select new
                                    {
                                        p.Matricule,
                                        p.Nom,
                                        ca.CodeAnalytique
                                    }).FirstOrDefaultAsync();
            return Per_Mat_Ca;
        }

        public async Task<int> UpdateAsync(int id, Personnel personnel)
        {
            var Updatepersonnel = await _blocDbContext.personnel.FirstOrDefaultAsync(x => x.ID_Personnel==id);
            Updatepersonnel.Matricule = personnel.Matricule;
            Updatepersonnel.Nom = personnel.Nom;
            Updatepersonnel.Activite_Service = personnel.Activite_Service;
            Updatepersonnel.Analytique_id = personnel.Analytique_id;
            return await _blocDbContext.SaveChangesAsync();
        }
    }
}
