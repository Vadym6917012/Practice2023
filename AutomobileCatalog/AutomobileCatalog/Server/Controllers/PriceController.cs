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

        [HttpGet("id")]
        public async Task<PriceReadDto> GetPriceByIdAsync(int id)
        {
            return await _priceRepository.GetPriceByIdAsync(id);
        }

        [HttpGet("Date")]
        public async Task<PriceReadDto> GetPriceByDateAsync(DateTime userTime)
        {
            return await _priceRepository.GetPriceByDateAsync(userTime);
        }

        [HttpGet("value")]
        public async Task<PriceReadDto> GetPriceByValue(decimal value)
        {
            return await _priceRepository.GetPriceByValue(value);
        }

        [HttpGet("from to")]
        public async Task<PriceReadDto> GetPriceFromTo(DateTime from, DateTime to)
        {
            return await _priceRepository.GetPriceByDateFromTo(from, to);
        }
    }
}
