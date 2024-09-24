using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.PortableExecutable;
using CleanArchitecture.Domain.Entities;
using Azure;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class EtatsRepository:IEtatsRepository
    {
        //string ConnectionString = @"Data Source=DESKTOP-263UF4M\TALSSI;Initial Catalog=Dimatit_Projet;Integrated Security=True;Encrypt=False;";
       string ConnectionString = @"Data Source=PcTalssiM\TALSSI;Initial Catalog=Dimatit_Projet;Integrated Security=True;Encrypt=False;";
        private readonly BlogDbContext _blocDbContext;
        public EtatsRepository(BlogDbContext blocDbContext)
        {
            this._blocDbContext = blocDbContext;
        }
        public async Task<IEnumerable<dynamic>> Get_Frais_ANT()
        {
            dynamic frais_ANT = new System.Dynamic.ExpandoObject();
            dynamic list = new List<dynamic>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Get_Frais_ANT", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        frais_ANT.Circulation = reader["Circulation Frais"];
                        frais_ANT.Matricule= reader["Matricule"];
                        frais_ANT.Nom= reader["Nom"];
                        frais_ANT.CodeAnalytique= reader["Code Analytique"];
                        frais_ANT.Total_frais_Deplacement= reader["Total frais Deplacement"];
                        frais_ANT.Total_frais_KM= reader["Total frais KM"];
                        frais_ANT.Total_frais_AV= reader["Total frais AV"];
                        frais_ANT.Date_Saisie= reader["Date_Saisie"];
                        list.Add(frais_ANT);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return  list;
        }   
           
    

        public async Task<IEnumerable<dynamic>> Get_Frais_Avancement()
        {
            dynamic listAvance = new List<dynamic>();
            
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Get_EtatDesAvances02", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        dynamic frais_Avance = new System.Dynamic.ExpandoObject();
                        frais_Avance.Circulation = reader["Circulation"];
                        frais_Avance.Nom= reader["Nom"];
                        frais_Avance.Matricule = reader["Matricule"];
                        frais_Avance.DateAvance = reader["DateAvance"];
                        frais_Avance.VilleRegion = reader["VilleRegion"];
                        frais_Avance.Total = reader["Total"];
                        
                       
                        listAvance.Add(frais_Avance);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return listAvance;
        }

        public async Task<IEnumerable<dynamic>> Get_Frais_Circulation(string etat)
        {
            
            dynamic listFraisCirculation = new List<dynamic>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Get_Frais_Circulation", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Etat", etat));
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        dynamic frais_Circulation = new System.Dynamic.ExpandoObject();
                        frais_Circulation.Circulation = reader["Circulation"];
                        frais_Circulation.Nom = reader["Nom"];
                        frais_Circulation.Matricule = reader["Matricule"];
                        frais_Circulation.CodeAnalytique = reader["CodeAnalytique"];
                        frais_Circulation.Total = reader["Total"];
                        listFraisCirculation.Add(frais_Circulation);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return listFraisCirculation;
        }

        public async Task<IEnumerable<dynamic>> Get_Frais_ParModReglement(string mode)
        {
            
            dynamic listModeRglement = new List<dynamic>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Get_EtatParMod2", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Mode", mode));
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        dynamic frais_ModeReglement = new System.Dynamic.ExpandoObject();
                        frais_ModeReglement.Circulation = reader["Circulation"];
                        frais_ModeReglement.Nom = reader["Nom"];
                        frais_ModeReglement.Matricule = reader["Matricule"];
                        frais_ModeReglement.ModeReglement = reader["ModeReglement"];
                        frais_ModeReglement.VilleRegion = reader["VilleRegion"];
                        frais_ModeReglement.Total = reader["Total"];
                        listModeRglement.Add(frais_ModeReglement);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return listModeRglement;
        }

        public async Task<IEnumerable<dynamic>> Get_Frais_Provision(DateTime dateDebut, DateTime dateFin)
        {
           
            dynamic listProvision = new List<dynamic>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Get_FraisProv", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@DateSaisi1", dateDebut));
                    command.Parameters.Add(new SqlParameter("@DateSaisi2", dateFin));
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        dynamic frais_Provision = new System.Dynamic.ExpandoObject();
                        frais_Provision.Nom = reader["Nom"];
                        frais_Provision.Matricule = reader["Matricule"];
                        frais_Provision.CodeAnalytique = reader["CodeAnalytique"];
                        frais_Provision.TotalFR = reader["Total frais Deplacement"];
                        frais_Provision.TotalKM = reader["Total frais KM"];
                        frais_Provision.TotalAV = reader["Total frais AV"];
                        frais_Provision.DateSaisie = reader["Date_Saisie"];
                        frais_Provision.DateReglement = reader["Date_Regelement"];
                        listProvision.Add(frais_Provision);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return listProvision;
        }

        public async Task<IEnumerable<dynamic>> Get_Frais_ParVirement(string mode)
        {
            dynamic frais_Virement = new System.Dynamic.ExpandoObject();
            dynamic listVirement = new List<dynamic>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Get_EtatParVirement", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Mode", mode));
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        frais_Virement.Circulation = reader["Circulation Frais"];
                        frais_Virement.Nom = reader["Nom"];
                        frais_Virement.Matricule = reader["Matricule"];
                        frais_Virement.ModeReglemen = reader["Mode Reglement"];
                        frais_Virement.VilleRegion = reader["Ville ou Region"];
                        frais_Virement.Total = reader["Total Frais Avancement"];
                        listVirement.Add(frais_Virement);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return listVirement;
        }
    }
}
