using RITest.Database.Repositories.Interfaces;
using RITest.Dto.Hole;
using RITest.Entities;
using RITest.Services.Interfaces.Hole;

namespace RITest.Services
{
    public class HoleService: IHoleService
    {
        private IBaseRepository<HoleEntity> _holeRepository;

        public HoleService(IBaseRepository<HoleEntity> holeRepository)
        {
            _holeRepository = holeRepository;
        }

        public async Task<HoleEntity> Create(HoleCreate dto)
        {
            return await Task.Run(() => _holeRepository
            .Create(new HoleEntity { Name = dto.Name, DrillBlockId = dto.DrillBlockId, DEPTH = dto.DEPTH }));
        }

        public async Task<int> Delete(int Id)
        {
            return await Task.Run(() => _holeRepository.Delete(Id));
        }

        public async Task<HoleEntity> Get(int Id)
        {
            return await Task.Run(() => _holeRepository.Get(Id));
        }

        public async Task<List<HoleEntity>> GetAll()
        {
            return await Task.Run(() => _holeRepository.GetAll());
        }

        public async Task<HoleEntity> Update(HoleUpdate dto)
        {
            return await Task.Run(() => _holeRepository
            .Update(new HoleEntity { Id = dto.Id, Name = dto.Name, DEPTH = dto.DEPTH, DrillBlockId = dto.DrillBlockId }));
        }
    }
}
