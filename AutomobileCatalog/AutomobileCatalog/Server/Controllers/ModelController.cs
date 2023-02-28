using AutomobileCatalog.Server.Core;
using AutomobileCatalog.Server.Infrastructure;
using AutomobileCatalog.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly ModelRepository _modelRepository;
        private readonly MakeRepository _makeRepository;
        private readonly VehicleColorRepository _vehicleColorRepository;
        private readonly DataContext _ctx;

        public ModelController(ModelRepository modelRepository, DataContext ctx, MakeRepository makeRepository, VehicleColorRepository vehicleColorRepository)
        {
            _modelRepository = modelRepository;
            _ctx = ctx;
            _makeRepository = makeRepository;
            _vehicleColorRepository = vehicleColorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ModelReadDto>> GetListAsync()
        {
            return await _modelRepository.GetListAsync();
        }

        [HttpGet]
		[Route("{id:int}")]
		public async Task<ModelReadDto> GetModelById(int id)
        {
            return await _modelRepository.GetModelByIdAsync(id);
        }

        [HttpGet]
		[Route("{name}")]
		public async Task<ModelReadDto> GetModelByName(string name)
        {
            return await _modelRepository.GetModelByNameAsync(name);
        }

        [HttpPost]
        public async Task<int> AddAsync(ModelCreateDto modelDto)
        {
            return await _modelRepository.AddAsync(modelDto);
        }

        [HttpDelete]
		[Route("{id:int}")]
		public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _ctx.Models.FindAsync(id);

            if (item is null)
                return NotFound();

            await _modelRepository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
		[Route("{id:int}")]
		public async Task UpdateAsync(int id, ModelCreateDto modelDto)
        {
            await _modelRepository.UpdateAsync(id, modelDto);
        }
    }
}
