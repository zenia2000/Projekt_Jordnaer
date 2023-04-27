using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Projekt_Jordnaer.Services
{
    public class VagtService : Connection, IVagtService
    {
        private string queryString = "SELECT * From Vagt";
        private string insertSql = "insert into Vagt Values(@ID, @Name, @Desc, @Start, @End)";

        public VagtService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> CreateVagtAsync(Vagt vagt)
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand(insertSql, connection);
            command.Parameters.AddWithValue("@ID", vagt.VagtId);
            command.Parameters.AddWithValue("@Name", vagt.VagtName);
            command.Parameters.AddWithValue("@Desc", vagt.VagtDescription);
            command.Parameters.AddWithValue("@Start", vagt.VagtStart);
            command.Parameters.AddWithValue("@End", vagt.VagtEnd);
            try
            {
                command.Connection.Open();
                int noOfRows = await command.ExecuteNonQueryAsync(); //bruges ved update, delete, insert
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
            return false;
        }

        public async Task<Vagt> DeleteVagtAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Vagt>> GetAllVagtAsync()
        {
            List<Vagt> vagter = new List<Vagt>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        await command.Connection.OpenAsync();//aSynkront

                        SqlDataReader reader = await command.ExecuteReaderAsync();//aSynkront

                        while (await reader.ReadAsync())
                        {
                            String VagtID = reader.GetString(0);
                            String VagtName = reader.GetString(1);
                            String VagtDesc = reader.GetString(2);
                            DateTime VagtStart = reader.GetDateTime(3);
                            DateTime VagtEnd = reader.GetDateTime(4);
                            Vagt vagt = new Vagt(VagtID, VagtName, VagtDesc, VagtStart, VagtEnd);
                            vagter.Add(vagt);
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
            return vagter;
        }


        public async Task<Vagt> GetVagtFromIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateVagtAsync(Vagt vagt, int id)
        {
            throw new NotImplementedException();
        }
    }    
}

