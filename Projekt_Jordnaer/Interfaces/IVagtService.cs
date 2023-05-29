using Projekt_Jordnaer.Models;

namespace Projekt_Jordnaer.Interfaces
{
    public interface IVagtService
    {
        Task<List<Vagt>> GetAllVagtAsync();

        Task<Vagt> GetVagtFromIdAsync(int id);
        Task<bool> CreateVagtAsync(Vagt vagt);
        Task<bool> UpdateVagtAsync(Vagt vagt, int id);
        Task<Vagt> DeleteVagtAsync(int id);
    }
}
