using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Test.Entitis;
using Test.Service.play.Contracts.Dtos;
using Test.Service.Teams.Contracts.Dtos;

namespace Test.Service.Play.Contracts
{
   public interface playersRepozitory
    {
        void Add(Players players);

        Players IsExistplayer(int Id);
        team IsExistteam(int Id);
        bool IsSameplayer(string name);

        void Update(Players players);
        void Delete(Players players);
        List<GetPlayersDto> GetAll(GetplayersFillterDto dto);
    }
}
