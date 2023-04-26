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
            throw new NotImplementedException();
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
