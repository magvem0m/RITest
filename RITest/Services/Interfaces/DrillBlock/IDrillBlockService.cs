using RITest.Controllers.Interfaces;
using RITest.Dto.DrillBlock;
using RITest.Entities;

namespace RITest.Services.Interfaces.DrillBlock
{
    public interface IDrillBlockService : ICRUD<DrillBlockEntity, DrillBlockCreate, DrillBlockUpdate>
    {
    }
}