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
    public class MakeRepository
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public MakeRepository(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MakeReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<MakeReadDto>>(await _ctx.Makes.ToListAsync());
        }
    }
}
