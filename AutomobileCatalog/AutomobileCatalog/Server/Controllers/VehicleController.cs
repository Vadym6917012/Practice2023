using AutomobileCatalog.Server.Infrastructure;
using AutomobileCatalog.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleController(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleReadDto>> GetListAsync()
        {
            return await _vehicleRepository.GetListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<VehicleReadDto> GetVehicleByIdAsync(int id)
        {
            return await _vehicleRepository.GetVehicleByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> AddAsync(VehicleCreateDto vehicleDto)
        {
            return await _vehicleRepository.AddAsync(vehicleDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = _vehicleRepository.GetVehicleById(id);

            if (item is null)
                return NotFound();

            await _vehicleRepository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, VehicleCreateDto vehicleDto)
        {
            var item = _vehicleRepository.GetVehicleById(id);

            if (item is null)
                return NotFound();

            await _vehicleRepository.UpdateAsync(id, vehicleDto);

            return Ok();
        }
    }
}
