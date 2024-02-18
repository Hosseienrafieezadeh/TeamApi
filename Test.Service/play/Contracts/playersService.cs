using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entitis;
using Test.Service.play.Contracts.Dtos;
using Test.Service.Teams.Contracts.Dtos;

namespace Test.Service.play.Contracts
{
    public interface playersService
    {

        Task Add(Addplayersdto dto);
        Task Update(int id, UpdatePlayersDto dto);
        Task Delete(int id);
        List<GetPlayersDto> GetAll(GetplayersFillterDto dto);
    }
}
