using Microsoft.AspNetCore.Mvc;
using RITest.Controllers.Interfaces;
using RITest.Dto.DrillBlock;
using RITest.Entities;
using RITest.Services.Interfaces.DrillBlock;

namespace RITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrillBlockController : ControllerBase, ICRUD<DrillBlockEntity, DrillBlockCreate, DrillBlockUpdate>
    {
        private IDrillBlockService _drillBlockService;
        public DrillBlockController(IDrillBlockService drillBlockService)
        {
            _drillBlockService = drillBlockService;
        }

        [HttpPost]
        public async Task<DrillBlockEntity> Create([FromBody] DrillBlockCreate dto)
        {
            return await _drillBlockService.Create(dto);
        }

        [HttpDelete]
        public async Task<int> Delete(int Id)
        {
            return await _drillBlockService.Delete(Id);
        }

        [HttpGet]
        public async Task<DrillBlockEntity> Get(int Id)
        {
            return await _drillBlockService.Get(Id);
        }

        [HttpGet("all")]
        public async Task<List<DrillBlockEntity>> GetAll()
        {
            return await _drillBlockService.GetAll();
        }

        [HttpPut]
        public async Task<DrillBlockEntity> Update([FromBody] DrillBlockUpdate dto)
        {
            return await _drillBlockService.Update(dto);
        }
    }
}
