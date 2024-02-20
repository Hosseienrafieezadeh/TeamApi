using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entitis;
using Test.Persistence.EF.EntitisMaps;
using Test.Service.play.Contracts.Dtos;
using Test.Service.Play.Contracts;
using Test.Service.Teams.Contracts.Dtos;

namespace Test.Persistence.EF.Play
{
    public class EFPlayersRepozitory :playersRepozitory
    {
        private readonly EFDataContext _context;

        public EFPlayersRepozitory(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Players players)
        {
            _context.Players.Add(players);
        }

        public void Delete(Players players)
        {
            _context.Players.Remove(players);
        }



        public List<GetPlayersDto> GetAll(GetplayersFillterDto dto)
        {
            var players = _context.Players.Include(_ => _.Team)
               .Select(player => new GetPlayersDto()
               {
                   Id = player.Id,
                   PlayerName = player.PlayerName,
                  BirthDate = (DateTime.UtcNow - player.Born).Days / 365,
                    TeamTitle= player.Team.TeamName

               }).ToList();
            if (!string.IsNullOrWhiteSpace(dto.PlayerName))
            {
                players = players.Where(_ => _.PlayerName.Contains(dto.PlayerName)).ToList();
            }
            if (dto.MaxAge != null)
            {

                players = players.Where(_ => _.BirthDate < dto.MaxAge).ToList();

            }
            if (dto.MinAge != null)
            {
                players = players.Where(_ => _.BirthDate > dto.MinAge).ToList();
            }
            return players;
            //IQueryable<Players> query = _context.Players.Include(_ => _.Team);
            //if (!string.IsNullOrEmpty(dto.PlayerName))
            //{
            //    query = query.Where(b => b.PlayerName.Contains(dto.PlayerName));
            //}

            //var age = (int)((DateTime.UtcNow - dto.Born).TotalDays / 365);
            //dto.Age = age; 
            //query = query.Where(b => b.Born >= dto.Born);

            //if (dto.TeamID > 0)
            //{
            //    query = query.Where(b => b.TeamID >= dto.TeamID);
            //}
            //return query.ToList();
        }



        public Players IsExistplayer(int Id)
        {
            return _context.Players.Find(Id);
        }

        public team IsExistteam(int Id)
        {
            return _context.Teams.Find(Id);
        } 


        public bool IsSameplayer(string name)
        {
            return _context.Players.Any(_ => _.PlayerName == name);
        }

        

        public void Update(Players players)
        {
            _context.Players.Update(players);
        }
    }
}
