using RITest.Database.Repositories.Interfaces;
using RITest.Dto.HolePoint;
using RITest.Entities;
using RITest.Services.Interfaces.HolePoint;

namespace RITest.Services
{
    public class HolePointService : IHolePointService
    {
        private IBaseRepository<HolePointEntity> _holeRepository;

        public HolePointService(IBaseRepository<HolePointEntity> holeRepository)
        {
            _holeRepository = holeRepository;
        }

        public async Task<HolePointEntity> Create(HolePointCreate dto)
        {
            return await Task.Run(() => _holeRepository
            .Create(new HolePointEntity { HoleId = dto.HoleId, X = dto.X, Y = dto.Y, Z = dto.Z }));
        }

        public async Task<int> Delete(int Id)
        {
            return await Task.Run(() => _holeRepository.Delete(Id));
        }

        public async Task<HolePointEntity> Get(int Id)
        {
            return await Task.Run(() => _holeRepository.Get(Id));
        }

        public async Task<List<HolePointEntity>> GetAll()
        {
            return await Task.Run(() => _holeRepository.GetAll());
        }

        public async Task<HolePointEntity> Update(HolePointUpdate dto)
        {
            return await Task.Run(() => _holeRepository
            .Update(dto));
        }
    }
}