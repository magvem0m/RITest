using Microsoft.AspNetCore.Mvc;
using RITest.Controllers.Interfaces;
using RITest.Dto.DrillBlockPoint;
using RITest.Entities;
using RITest.Services.Interfaces.DrillBlockPoint;

namespace RITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrillBlockPointController : ControllerBase, ICRUD<DrillBlockPointEntity, DrillBlockPointCreate, DrillBlockPointUpdate>
    {
        private IDrillBlockPointService _drillBlockPointService;
        public DrillBlockPointController(IDrillBlockPointService drillBlockPointService)
        {
            _drillBlockPointService = drillBlockPointService;
        }

        [HttpPost]
        public async Task<DrillBlockPointEntity> Create([FromBody] DrillBlockPointCreate dto)
        {
            return await _drillBlockPointService.Create(dto);
        }

        [HttpDelete]
        public async Task<int> Delete(int Id)
        {
            return await _drillBlockPointService.Delete(Id);
        }

        [HttpGet]
        public async Task<DrillBlockPointEntity> Get(int Id)
        {
            return await _drillBlockPointService.Get(Id);
        }

        [HttpGet("all")]
        public async Task<List<DrillBlockPointEntity>> GetAll()
        {
            return await _drillBlockPointService.GetAll();
        }

        [HttpPut]
        public async Task<DrillBlockPointEntity> Update(DrillBlockPointUpdate dto)
        {
            return await _drillBlockPointService.Update(dto);
        }
    }
}