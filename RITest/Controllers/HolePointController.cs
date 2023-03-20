using Microsoft.AspNetCore.Mvc;
using RITest.Controllers.Interfaces;
using RITest.Dto.HolePoint;
using RITest.Entities;
using RITest.Services.Interfaces.HolePoint;

namespace RITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolePointController : ControllerBase, ICRUD<HolePointEntity, HolePointCreate, HolePointUpdate>
    {
        private IHolePointService _holePointService;
        public HolePointController(IHolePointService holePointService)
        {
            _holePointService = holePointService;
        }

        [HttpPost]
        public async Task<HolePointEntity> Create(HolePointCreate dto)
        {
            return await _holePointService.Create(dto);
        }

        [HttpDelete]
        public async Task<int> Delete(int Id)
        {
            return await _holePointService.Delete(Id);
        }

        [HttpGet]
        public async Task<HolePointEntity> Get(int Id)
        {
            return await _holePointService.Get(Id);
        }

        [HttpGet("all")]
        public async Task<List<HolePointEntity>> GetAll()
        {
            return await _holePointService.GetAll();
        }

        [HttpPut]
        public async Task<HolePointEntity> Update(HolePointUpdate dto)
        {
            return await _holePointService.Update(dto);
        }
    }
}