using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entitis;
using Test.Service.Teams.Contracts.Dtos;

namespace Test.Service.Teams.Contracts
{
    public interface TeamRepozitory
    {
        void Add(team team);
       
        team IsExistTeam(int Id);
        bool IsSameTeam( string name);

        void Update(team team);
        void Delete(team team);
        List<GetTeamDto> GetAll(GetTeamFilterDto dto);

    }
}
