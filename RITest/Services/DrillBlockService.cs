using RITest.Controllers.Interfaces;
using RITest.Database.Repositories.Interfaces;
using RITest.Dto.DrillBlock;
using RITest.Entities;
using RITest.Services.Interfaces.DrillBlock;

namespace RITest.Services
{
    public class DrillBlockService: IDrillBlockService
    {
        private IBaseRepository<DrillBlockEntity> _drillBlockRepository;

        public DrillBlockService(IBaseRepository<DrillBlockEntity> drillBlockRepository)
        {
            _drillBlockRepository = drillBlockRepository;
        }

        public async Task<DrillBlockEntity> Create(DrillBlockCreate dto)
        {
            return await Task.Run(()=>_drillBlockRepository.Create(new DrillBlockEntity { Name = dto.Name }));
        }

        public async Task<int> Delete(int Id)
        {
            return await Task.Run(() => _drillBlockRepository.Delete(Id));
        }

        public async Task<DrillBlockEntity> Get(int Id)
        {
            return await Task.Run(() => _drillBlockRepository.Get(Id));
        }

        public async Task<List<DrillBlockEntity>> GetAll()
        {
            return await Task.Run(() => _drillBlockRepository.GetAll());
        }

        public async Task<DrillBlockEntity> Update(DrillBlockUpdate dto)
        {
            return await Task.Run(() => _drillBlockRepository.Update(new DrillBlockEntity { Id = dto.Id, Name = dto.Name }));
        }
    }
}
