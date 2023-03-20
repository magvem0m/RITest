using Microsoft.AspNetCore.Mvc;
using RITest.Controllers.Interfaces;
using RITest.Dto.Hole;
using RITest.Entities;
using RITest.Services.Interfaces.Hole;

namespace RITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoleController : ControllerBase, ICRUD<HoleEntity, HoleCreate, HoleUpdate>
    {
        private IHoleService _holeService;
        public HoleController(IHoleService holeService)
        {
            _holeService = holeService;
        }

        [HttpPost]
        public async Task<HoleEntity> Create([FromBody] HoleCreate dto)
        {
            return await _holeService.Create(dto);
        }

        [HttpDelete]
        public async Task<int> Delete(int Id)
        {
            return await _holeService.Delete(Id);
        }

        [HttpGet]
        public async Task<HoleEntity> Get(int Id)
        {
            return await _holeService.Get(Id);
        }

        [HttpGet("all")]
        public async Task<List<HoleEntity>> GetAll()
        {
            return await _holeService.GetAll();
        }

        [HttpPut]
        public async Task<HoleEntity> Update(HoleUpdate dto)
        {
            return await _holeService.Update(dto);
        }
    }
}