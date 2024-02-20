using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavv.Contract;
using Test.Entitis;
using Test.Service.Teams.Contracts;
using Test.Service.Teams.Contracts.Dtos;

namespace Test.Service.Teams
{
    public class TeamAppService : TeamService
    {
        private readonly TeamRepozitory _repozitory;
        private readonly UnitOfWork _unitOfWork;
        public TeamAppService(TeamRepozitory repozitory, UnitOfWork unitOfWork)
        {
            _repozitory = repozitory;
            _unitOfWork = unitOfWork;

        }
        public async Task Add(AddTeamDto dto)
        {
           
            var teams = new team 
            {
                TeamName = dto.TeamName,
                TshirSub=dto.TshirSub,
                
                TshirOriginally=dto.TshirOriginally,
            };
            if (dto.TshirSub == dto.TshirOriginally) 
            {
                throw new Exception(" please TshirSub  and TshirOriginally not same");
            }
                var aa = _repozitory.IsSameTeam(dto.TeamName);
            if (aa ==true) 
            {
                throw new Exception("teamNamae uniq");
            }
            _repozitory.Add(teams);
        await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var team = _repozitory.IsExistTeam(id);
            if (team is null)
            {
                throw new Exception("team not found");
            }
         
            _repozitory.Delete(team);
      await      _unitOfWork.Complete();

        }

        public List<GetTeamDto> GetAll(GetTeamFilterDto dto)
        {
            return _repozitory.GetAll(dto);
        }

        public async Task Update(int id, UpdateTeamDto dto)
        {
            var team = _repozitory.IsExistTeam(id);
            if (team is null)
            {
                throw new Exception("team not found");
            }
            team.TeamName = dto.TeamName;
            team.TshirSub = dto.TshirSub;   
            team.TshirOriginally = dto.TshirOriginally;
            _repozitory.Update(team);
        await    _unitOfWork.Complete();
        }
    }
}
