using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Service.Teams.Contracts.Dtos;
using Test.Service.Teams.Contracts;
using Test.Service.play.Contracts;
using Test.Service.play.Contracts.Dtos;

namespace Test.RestApi.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly playersService _service;
        public PlayerController(playersService service)
        {
            _service = service;
        }
        [HttpPost("add")]
        public async Task Add([FromBody] Addplayersdto dto)
        {
            await _service.Add(dto);

        }

        [HttpPatch("update/{id}")]
        public async Task Update(int id, [FromBody] UpdatePlayersDto dto)
        {
            await _service.Update(id, dto);

        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);

        }

        [HttpGet("get")]
        public void Get(GetPlayersDto dto)
        {
            _service.GetAll(dto);

        }
    }
}
