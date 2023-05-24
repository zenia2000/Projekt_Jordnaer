using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using System.Reflection.PortableExecutable;

namespace Projekt_Jordnaer.Services
{
    public class MedlemService : Connection, IMedlemService 
	{
        private string insertMemberSql = "INSERT INTO Medlem Values (@MemberID, @Name, @Address, @Email, @PhoneNr, @Certificate, @Admin)";
        private string deleteMemberSql = "DELETE FROM Medlem WHERE Medlem_Nr = @MemberID";
        private string membersString = "SELECT * FROM Medlem";
        private string updateMemberSql = "UPDATE Medlem " + 
                                         "SET Medlem_Nr = @MemberID, Navn = @Name, Adresse = @Address, Email = @Email, Telefon nr. = @PhoneNr, Certifikat = @Certificate, Admin = @Admin"
                                         + "WHERE Medlem_Nr = @MemberID";
        private string queryMemberName = "SELECT * FROM Medlem WHERE Navn LIKE @Name"; 
        private string queryMemberFromID = "SELECT * FROM Medlem WHERE Medlem_Nr = @MemberID";

        public MedlemService (IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> CreateMemberAsync(Medlem medlem)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertMemberSql, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", medlem.MemberID);
                    command.Parameters.AddWithValue("@Name", medlem.Name);
                    command.Parameters.AddWithValue("@Address", medlem.Address);
                    command.Parameters.AddWithValue("@Email", medlem.Email);
                    command.Parameters.AddWithValue("@PhoneNr", medlem.PhoneNr);
                    command.Parameters.AddWithValue("@Certificate", medlem.Certificate);
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

        public async Task<Medlem> DeleteMemberAsync(int memberID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteMemberSql, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", memberID);
                    try
                    {
                        Medlem deleteMember = await GetMemberFromIDAsync(memberID);
                        command.Connection.Open();
                        int noOfRows = await command.ExecuteNonQueryAsync();
                        if (noOfRows == 1)
                        {
                            return deleteMember;
                        }
                        return null;
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
            return null;
        }

        public async Task<List<Medlem>> GetAllMembersAsync()
        {
            List<Medlem> medlemmer = new List<Medlem>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(membersString, connection))
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
                            bool memberCert = reader.GetBoolean(5);
                            bool memberAdmin = reader.GetBoolean(6);

                            Medlem medlem = new Medlem(memberID, memberName, memberAddress, memberEmail, memberPhoneNr, memberCert, memberAdmin);
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

        public async Task<bool> UpdateMemberAsync(Medlem medlem, int memberID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateMemberSql, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", medlem.MemberID);
                    command.Parameters.AddWithValue("@Name", medlem.Name);
                    command.Parameters.AddWithValue("@Address", medlem.Address);
                    command.Parameters.AddWithValue("@Email", medlem.Email);
                    command.Parameters.AddWithValue("@PhoneNr", medlem.PhoneNr);
                    command.Parameters.AddWithValue("@Certificate", medlem.Certificate);
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

        public async Task<List<Medlem>> GetMemberByNameAsync(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    List<Medlem> medlemmer = new List<Medlem>();
                    SqlCommand command = new SqlCommand(queryMemberName, connection);
                    string nameMember = "%" + name + "%";
                    command.Parameters.AddWithValue("@Name", nameMember);
                    command.Connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        int memberID = reader.GetInt32(0);
                        String memberName = reader.GetString(1);
                        String memberAddress = reader.GetString(2);
                        String memberEmail = reader.GetString(3);
                        String memberPhoneNr = reader.GetString(4);
                        bool memberCert = reader.GetBoolean(5);
                        bool memberAdmin = reader.GetBoolean(6);
                        
                        Medlem m = new Medlem(memberID, memberName, memberAddress, memberEmail, memberPhoneNr, memberCert, memberAdmin);
                        medlemmer.Add(m);
                    }
                    return medlemmer;
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Der skete en database fejl! " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Der skete en generel fejl! " + ex.Message);
                }
            }
            return null; 
        }

        public async Task<Medlem> GetMemberFromIDAsync(int memberID)
        {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand commmand = new SqlCommand(queryMemberFromID, connection);
                        commmand.Parameters.AddWithValue("@MemberID", memberID);
                        await commmand.Connection.OpenAsync();

                        SqlDataReader reader = await commmand.ExecuteReaderAsync();
                        if (await reader.ReadAsync())
                        {
                            String memberName = reader.GetString(1);
                            String memberAddress = reader.GetString(2);
                            String memberEmail = reader.GetString(3);
                            String memberPhoneNr = reader.GetString(4);
                            bool memberCert = reader.GetBoolean(5);
                            bool memberAdmin = reader.GetBoolean(6);

                            Medlem medlem = new Medlem(memberID, memberName, memberAddress, memberEmail, memberPhoneNr, memberCert, memberAdmin);
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
    }
}
