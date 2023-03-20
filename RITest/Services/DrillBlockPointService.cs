using Microsoft.EntityFrameworkCore;
using RITest.Database.Repositories.Interfaces;
using RITest.Dto.DrillBlockPoint;
using RITest.Entities;
using RITest.Services.Interfaces.DrillBlockPoint;

namespace RITest.Services
{
    public class DrillBlockPointService: IDrillBlockPointService
    {
        private IBaseRepository<DrillBlockPointEntity> _drillBlockPointRepository;

        public DrillBlockPointService(IBaseRepository<DrillBlockPointEntity> drillBlockPointRepository)
        {
            _drillBlockPointRepository = drillBlockPointRepository;
        }

        public async Task<DrillBlockPointEntity> Create(DrillBlockPointCreate dto)
        {
            return await Task.Run(() => _drillBlockPointRepository
                .Create(new DrillBlockPointEntity { DrillBlockId = dto.DrillBlockId, X = dto.X, Y = dto.Y, Z = dto.Z })
            );
        }

        public async Task<int> Delete(int Id)
        {
            return await Task.Run(()=>_drillBlockPointRepository.Delete(Id));
        }

        public async Task<DrillBlockPointEntity> Get(int Id)
        {
            return await Task.Run(() =>_drillBlockPointRepository.Get(Id));
        }

        public async Task<List<DrillBlockPointEntity>> GetAll()
        {
            return await Task.Run(() => _drillBlockPointRepository
                .GetContext()
                .Include(s => s.DrillBlock).ToList());
        }

        public async Task<DrillBlockPointEntity> Update(DrillBlockPointUpdate dto)
        {
            return await Task.Run(() =>
            {
                return _drillBlockPointRepository
                .Update(new DrillBlockPointEntity { X = dto.X, Y = dto.Y, Z = dto.Z });
            });
        }
    }
}
