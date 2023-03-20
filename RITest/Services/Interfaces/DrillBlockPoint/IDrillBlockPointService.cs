using RITest.Controllers.Interfaces;
using RITest.Dto.DrillBlockPoint;
using RITest.Entities;

namespace RITest.Services.Interfaces.DrillBlockPoint
{
    public interface IDrillBlockPointService : ICRUD<DrillBlockPointEntity, DrillBlockPointCreate, DrillBlockPointUpdate>
    {
    }
}