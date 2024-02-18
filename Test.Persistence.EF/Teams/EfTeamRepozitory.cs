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

        public List<team> GetAll(GetTeamDto dto)
        {
            IQueryable<team> query = _context.Teams.Include(_ => _.Players);

            if (!string.IsNullOrEmpty(dto.TeamName))
            {
                query = query.Where(b => b.TeamName.Contains(dto.TeamName));
            }

            if (dto.TshirSub > 0 && dto.TshirOriginally > 0)
            {
                query = query.Where(b => b.TshirSub >= dto.TshirSub && b.TshirOriginally >= dto.TshirOriginally);
            }
            else if (dto.TshirSub > 0)
            {
                query = query.Where(b => b.TshirSub >= dto.TshirSub);
            }
            else if (dto.TshirOriginally > 0)
            {
                query = query.Where(b => b.TshirOriginally >= dto.TshirOriginally);
            }

            return query.ToList();
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
