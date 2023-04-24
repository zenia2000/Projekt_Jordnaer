using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using System.Data.SqlClient;

namespace Projekt_Jordnaer.Services
{
    public class VagtService : Connection, IVagtService
    {
        public VagtService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> CreateVagtAsync(Vagt vagt)
        {
            throw new NotImplementedException();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(insertSql, connection))
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
