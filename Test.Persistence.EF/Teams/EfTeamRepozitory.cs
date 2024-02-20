using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entitis;
using Test.Persistence.EF.EntitisMaps;
using Test.Service.Teams.Contracts;
using Test.Service.Teams.Contracts.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Test.Persistence.EF.Teams
{
    public class EfTeamRepozitory : TeamRepozitory
    {
        private readonly EFDataContext _context;

        public EfTeamRepozitory(EFDataContext context)
        {
            _context = context;
        }

        public void Add(team team)
        {
            _context.Teams.Add(team);
        }

        public void Delete(team team)
        {
            _context.Teams.Remove(team);
        }

        public List<GetTeamDto> GetAll(GetTeamFilterDto dto)
        {
            IQueryable<team> query = _context.Teams;
            if (!string.IsNullOrWhiteSpace(dto.Name))
            {
                query = query.Where(_ => _.TeamName.Contains(dto.Name));
            }
            if (dto.sub != null)
            {
                query = query.Where(_ => _.TshirSub == dto.sub);
            }
            if (dto.Main != null)
            {
                query = query.Where(_ => _.TshirOriginally == dto.Main);
            }
            List<GetTeamDto> teams = query.Select(team => new GetTeamDto
            {
                Id= team.Id,
                TeamName = team.TeamName,
                TshirOriginally = team.TshirOriginally,
                TshirSub = team.TshirSub,
            }).ToList();
            return teams;
        }

        public team IsExistTeam(int Id)
        {
            return _context.Teams.Find(Id);
        }

        public bool IsSameTeam(string name)
        {
            return _context.Teams.Any(_=>_.TeamName== name);
        }

      

        public void Update(team team)
        {
          _context.Teams.Update(team);
        }
    }
}
