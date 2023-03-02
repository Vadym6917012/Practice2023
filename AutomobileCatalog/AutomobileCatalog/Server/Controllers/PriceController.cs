using AutomobileCatalog.Server.Infrastructure;
using AutomobileCatalog.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly PriceRepository _priceRepository;

        public PriceController(PriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PriceReadDto>> GetListAsync()
        {
            return await _priceRepository.GetListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PriceReadDto> GetPriceByIdAsync(int id)
        {
            return await _priceRepository.GetPriceByIdAsync(id);
        }
    }
}
