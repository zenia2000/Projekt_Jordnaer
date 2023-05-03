using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Projekt_Jordnaer.Services
{
    public class VagtService : Connection, IVagtService
    {
        private string queryString = "SELECT * From Vagt";
        private string insertSql = "insert into Vagt Values(@Name, @Desc, @Start, @End, @Type)";
        private string queryDelete = "delete from Vagt where VagtId=@ID";
        private string queryStringFromID = "select * from Vagt where VagtId = @ID";
        private string updateSql = "Update Vagt Set VagtName = @Name, Description= @Desc, VagtStart = @Start, VagtEnd = @End, VagtTypeId = @Type, where VagtId = @ID";
        public VagtService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> CreateVagtAsync(Vagt vagt)
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand(insertSql, connection);

            command.Parameters.AddWithValue("@Name", vagt.VagtName);
            command.Parameters.AddWithValue("@Desc", vagt.VagtDescription);
            command.Parameters.AddWithValue("@Start", vagt.VagtStart);
            command.Parameters.AddWithValue("@End", vagt.VagtEnd);
            command.Parameters.AddWithValue("@Type", vagt.VagtTypeId);
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    Vagt vagtToReturn = await GetVagtFromIdAsync(id);
                    SqlCommand command = new SqlCommand(queryDelete, connection);
                    command.Parameters.AddWithValue("@ID", id);
                    await command.Connection.OpenAsync();
                    int noOfRows = await command.ExecuteNonQueryAsync();
                    return vagtToReturn;
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Database error " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl " + ex.Message);
                }
            }
            return null;
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
                            int VagtID = reader.GetInt32(0);
                            String VagtName = reader.GetString(1);
                            String VagtDesc = reader.GetString(2);
                            DateTime VagtStart = reader.GetDateTime(3);
                            DateTime VagtEnd = reader.GetDateTime(4);
                            VTypes VagtType = (VTypes)reader.GetInt32(5); //spørg poul
                            Vagt vagt = new Vagt(VagtID, VagtName, VagtDesc, VagtStart, VagtEnd, VagtType);
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand commmand = new SqlCommand(queryStringFromID, connection);
                    commmand.Parameters.AddWithValue("@ID", id);
                    await commmand.Connection.OpenAsync();

                    SqlDataReader reader = commmand.ExecuteReader();
                    if (await reader.ReadAsync())
                    {

                        int VagtID = reader.GetInt32(0);
                        String VagtName = reader.GetString(1);
                        String VagtDesc = reader.GetString(2);
                        DateTime VagtStart = reader.GetDateTime(3);
                        DateTime VagtEnd = reader.GetDateTime(4);
                        VTypes VagtType = (VTypes)reader.GetInt32(5); //spørg poul

                        Vagt vagt = new Vagt(VagtID, VagtName, VagtDesc, VagtStart, VagtEnd, VagtType);
                        return vagt;
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
                    //her kommer man altid
                }
            }
            return null;

        }

        public async Task<bool> UpdateVagtAsync(Vagt vagt, int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                using SqlCommand command = new SqlCommand(updateSql, connection);
                {

                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", vagt.VagtName);
                    command.Parameters.AddWithValue("@Desc", vagt.VagtDescription);
                    command.Parameters.AddWithValue("@Start", vagt.VagtStart);
                    command.Parameters.AddWithValue("@End", vagt.VagtEnd);
                    command.Parameters.AddWithValue("@Type", vagt.VagtTypeId);
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
            }
        }
    }
}
