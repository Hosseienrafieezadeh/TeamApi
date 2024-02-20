using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Service.Teams.Contracts;
using Test.Service.Teams.Contracts.Dtos;

namespace Test.RestApi.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamService  _service;
        public TeamController(TeamService service)
        {
            _service = service;
        }
        [HttpPost("add")]
        public async Task Add([FromBody] AddTeamDto dto)
        {
            await _service.Add(dto);

        }

        [HttpPatch("update/{id}")]
        public async Task Update( int id, [FromBody] UpdateTeamDto dto)
        {
            await _service.Update(id, dto);

        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);

        }

        [HttpGet("get")]
        public List<GetTeamDto> GetAll([FromQuery] GetTeamFilterDto dto)
        {
            return _service.GetAll(dto);
        }
    }
}
