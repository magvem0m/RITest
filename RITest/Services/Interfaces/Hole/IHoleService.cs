using RITest.Controllers.Interfaces;
using RITest.Dto.Hole;
using RITest.Entities;

namespace RITest.Services.Interfaces.Hole
{
    public interface IHoleService : ICRUD<HoleEntity, HoleCreate, HoleUpdate>
    {
    }
}