﻿using Projekt_Jordnaer.Models;
using System.Threading.Tasks;

namespace Projekt_Jordnaer.Interfaces
{
    public interface IMedlemService
    {
        //Hent alle medlemmer fra database
        Task<List<Medlem>> GetAllMembersAsync();

        //Hent medlem ud fra ID fra db
        Task<Medlem> GetMemberFromIDAsync(int memberID);

        //Hent medlem ud fra navn fra db
        Task<List<Medlem>> GetMemberByNameAsync(string name);

        //Tilføj medlem til db
        Task<bool> CreateMemberAsync(Medlem medlem);

        //Slet medlem fra db
        Task<Medlem> DeleteMemberAsync(int memberID);

        //Opdater medlem
        Task<bool> UpdateMemberAsync(Medlem medlem, int memberID);
    }
}
