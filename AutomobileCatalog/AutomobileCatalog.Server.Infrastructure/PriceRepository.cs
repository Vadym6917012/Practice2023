using AutoMapper;
using AutomobileCatalog.Server.Core;
using AutomobileCatalog.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileCatalog.Server.Infrastructure
{
    public class PriceRepository
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public PriceRepository(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PriceReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<PriceReadDto>>(await _ctx.Prices.Include(x => x.Vehicle).ToListAsync());
        }

        public async Task<PriceReadDto> GetPriceByIdAsync(int id)
        {
            return _mapper.Map<PriceReadDto>(await _ctx.Prices.FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}
