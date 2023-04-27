using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;

namespace Projekt_Jordnaer.Services
{
    public class MedlemService : Connection, IMedlemService 
	{
        private string queryString = "SELECT * from Medlem";
        private string insertSql = "INSERT INTO Medlem Values (@MedlemID, @Navn, @Adresse, @Email, @Telefon nr., @Certifikat(er), @Admin)";
        private string deleteSql = "";
        private string queryStringFromID = "SELECT * from Medlem WHERE Medlem_Nr = @MedlemID";

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
                    command.Parameters.AddWithValue("@Admin", medlem.Admin); //anderledes hvis bool?
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

        public Task<Medlem> DeleteMemberAsync(int memberID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Medlem>> GetAllMembersAsync()
        {
            List<Medlem> medlemmer = new List<Medlem>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        await command.Connection.OpenAsync();
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            int memberID = reader.GetInt32(0);
                            String memberName = reader.GetString(1);
                            String memberAddress = reader.GetString(2);
                            String memberEmail = reader.GetString(3);
                            String memberPhoneNr = reader.GetString(4);
                            String memberCert = reader.GetString(5);
                            //bool memberAdmin = reader. hvordan bool = true eller false

                            Medlem medlem = new Medlem(memberID, memberName, memberAddress, memberEmail, memberPhoneNr, memberCert);
                            medlemmer.Add(medlem);
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine("Database error " + sqlEx.Message);
                        return null;
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Generel fejl" + exp.Message);
                        return null;
                    }
                }
            }
            return medlemmer;
        }

        public Task<Medlem> GetMemberByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Medlem> GetMemberFromIDAsync(int memberID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand commmand = new SqlCommand(queryStringFromID, connection);
                    commmand.Parameters.AddWithValue("@MedlemID", memberID);
                    await commmand.Connection.OpenAsync();

                    SqlDataReader reader = await commmand.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        int memberID = reader.GetInt32(0);
                        String memberName = reader.GetString(1);
                        String memberAddress = reader.GetString(2);
                        String memberEmail = reader.GetString(3);
                        String memberPhoneNr = reader.GetString(4);
                        String memberCert = reader.GetString(5);
                        //bool memberAdmin = reader. hvordan bool = true eller false

                        Medlem medlem = new Medlem(memberID, memberName, memberAddress, memberEmail, memberPhoneNr, memberCert);
                        return medlem;
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Database error " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl " + ex.Message);
                }
                finally
                {
                   
                }
            }
            return null;
        }

        public Task<List<Medlem>> GetMembersByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMemberAsync(Medlem medlem, int memberID)
        {
            throw new NotImplementedException();
        }
    }
}
