using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavv.Contract;
using Test.Entitis;
using Test.Service.play.Contracts;
using Test.Service.play.Contracts.Dtos;
using Test.Service.Play.Contracts;
using Test.Service.Teams.Contracts;

namespace Test.Service.play
{
    public class PlyersAppService : playersService
    {
        private readonly playersRepozitory _repozitory;
        private readonly UnitOfWork _unitOfWork;
        public PlyersAppService(playersRepozitory repozitory, UnitOfWork unitOfWork)
        {
            _repozitory = repozitory;
            _unitOfWork = unitOfWork;

        }
        public async Task Add(Addplayersdto dto)
        {
            var bb = _repozitory.IsExistteam(dto.TeamID);
            if (bb is null)
            {
                throw new Exception("no find team");
            }
            var player = new Players
            {
            PlayerName = dto.PlayerName,
            Born = dto.Born,
            TeamID = dto.TeamID,
            };

            var aa = _repozitory.IsSameplayer(dto.PlayerName);
            if (aa == true)
            {
                throw new Exception("playername uniq");
            }
            _repozitory.Add(player);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var team = _repozitory.IsExistplayer(id);
            if (team is null)
            {
                throw new Exception("player not found");
            }

            _repozitory.Delete(team);
            await _unitOfWork.Complete();
        }

        public List<GetPlayersDto> GetAll(GetplayersFillterDto dto)
        {
            return _repozitory.GetAll(dto);
        }

     

        public async Task Update(int id, UpdatePlayersDto dto)
        {
            var player = _repozitory.IsExistplayer(id);
            if (player is null)
            {
                throw new Exception("team not found");
            }
            player.PlayerName = dto.PlayerName;
            player.Born = dto.Born;
            player.TeamID = dto.TeamID;
            _repozitory.Update(player);
            await _unitOfWork.Complete();
        }
    }
}
