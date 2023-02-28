using AutomobileCatalog.Server.Core;
using AutomobileCatalog.Server.Infrastructure;
using AutomobileCatalog.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        private readonly DataContext _ctx;
        private readonly MakeRepository _makeRepository;

        public MakeController(MakeRepository makeRepository, DataContext ctx)
        {
            _makeRepository = makeRepository;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<MakeReadDto>> GetListAsync()
        {
            return await _makeRepository.GetListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<MakeReadDto> GetMakeByIdAsync(int id)
        {
            return await _makeRepository.GetMakeByIdAsync(id);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<MakeReadDto> GetMakeByName(string name)
        {
            return await _makeRepository.GetMakeByNameAsync(name);
        }

        [HttpPost]
        public async Task<int> AddAsync(MakeCreateDto makeDto)
        {
            return await _makeRepository.AddAsync(makeDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _ctx.Makes.FindAsync(id);

            if (item is null)
                return NotFound();

            await _makeRepository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task UpdateAsync(MakeCreateDto makeDto, int id)
        {
            await _makeRepository.UpdateAsync(makeDto, id);
        }
    }
}
