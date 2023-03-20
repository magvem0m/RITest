using RITest.Controllers.Interfaces;
using RITest.Dto.HolePoint;
using RITest.Entities;

namespace RITest.Services.Interfaces.HolePoint
{
    public interface IHolePointService : ICRUD<HolePointEntity, HolePointCreate, HolePointUpdate>
    {
    }
}