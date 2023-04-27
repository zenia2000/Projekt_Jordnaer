using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;

public namespace Projekt_Jordnaer.Services
{
    public class MedlemService : Connection, IMedlemService //ingen connection + medlemservice
	{
        private string queryString = "SELECT * from Medlem";
        private string insertSql = "";
        private string deleteSql = "";

        public MedlemService (IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> CreateMemberAsync(Medlem medlem)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@MedlemID", medlem.MemberID);
                    command.Parameters.AddWithValue("@Navn", medlem.Name);
                    command.Parameters.AddWithValue("@Adresse", medlem.Address);
                    command.Parameters.AddWithValue("@Email", medlem.Email);
                    command.Parameters.AddWithValue("@Telefon nr.", medlem.PhoneNr);
                    command.Parameters.AddWithValue("@Certifikat(er)", medlem.Certificate);
                    command.Parameters.AddWithValue("@Admin", medlem.Admin);
                    try
                    {
                        command.Connection.Open();
                        int noOfRows = await command.ExecuteNonQueryAsync();
                        if (noOfRows == 1)
                        {
                            return true;
                        }

                        return false;
                    }
                    catch (SqlException sqlex)
                    {
                        Console.WriteLine("Database error");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Generel error");
                    }
                }
            }
            return false;
        }

        ////Hent alle medlemmer fra database
        //Task<List<Medlem>> GetAllMembersAsync();

        ////Hent medlem ud fra ID fra db
        //Task<Medlem> GetMemberFromIDAsync(int memberID);

        ////Hent medlem ud fra navn fra db
        //Task<Medlem> GetMemberByNameAsync(string name);

        ////Tilføj medlem til db
        //Task<bool> CreateMemberAsync(Medlem medlem);

        ////Slet medlem fra db
        //Task<Medlem> DeleteMemberAsync(int memberID);

        ////Opdater medlem, find ud af hvordan alt opdateres??
        //Task<bool> UpdateMemberAsync(Medlem medlem, int memberID);

        ////Hent alle medlemmer i db ud fra navn
        //Task<List<Medlem>> GetMembersByNameAsync(string name);

    }
}
