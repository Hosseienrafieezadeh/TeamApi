using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entitis;
using Test.Service.Teams.Contracts.Dtos;

namespace Test.Service.Teams.Contracts
{
   public interface TeamService
    {
         Task Add(AddTeamDto dto);
        Task Update(int id,UpdateTeamDto dto);
        Task Delete(int id);
        List<team> GetAll(GetTeamDto dto);
    }
}
