using AutomobileCatalog.Server.Infrastructure;
using AutomobileCatalog.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        private readonly MakeRepository _makeRepository;

        public MakeController(MakeRepository makeRepository)
        {
            _makeRepository = makeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MakeReadDto>> GetListAsync()
        {
            return await _makeRepository.GetListAsync();
        }
    }
}
