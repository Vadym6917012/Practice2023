using AutomobileCatalog.Server.Infrastructure;
using AutomobileCatalog.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleColorController : ControllerBase
    {
        private readonly VehicleColorRepository _vehicleColorRepository;

        public VehicleColorController(VehicleColorRepository vehicleColorRepository)
        {
            _vehicleColorRepository = vehicleColorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleColorReadDto>> GetListAsync()
        {
            return await _vehicleColorRepository.GetListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<VehicleColorReadDto> GetColorById([FromRoute] int id)
        {
            return await _vehicleColorRepository.GetColorByIdAsync(id);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<int> GetColorByName(string name)
        {
            return await _vehicleColorRepository.GetColorByNameAsync(name);
        }

        [HttpPost]
        public async Task<int> AddAsync(VehicleColorCreateDto colorDto)
        {
			return await _vehicleColorRepository.AddAsync(colorDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var item = _vehicleColorRepository.GetColorById(id);

            if (item is null)
                return NotFound();

            await _vehicleColorRepository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task UpdateAsync(int id, VehicleColorCreateDto colorDto)
        {
            await _vehicleColorRepository.UpdateAsync(id, colorDto);
        }
    }
}
