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
            return _mapper.Map<IEnumerable<MakeReadDto>>(await _ctx.Makes.Include(x => x.Models).ToListAsync());
        }

        public async Task<MakeReadDto> GetMakeByIdAsync(int id)
        {
            return _mapper.Map<MakeReadDto>(await _ctx.Makes.FirstOrDefaultAsync(x => x.Id == id));
        }

        public Make GetMakeById(int id)
        {
            return _ctx.Makes.FirstOrDefault(x => x.Id == id);
        }

        public async Task<MakeReadDto> GetMakeByNameAsync(string name)
        {
            return _mapper.Map<MakeReadDto>(await _ctx.Makes.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
        }

        public async Task<int> AddAsync(MakeCreateDto makeDto)
        {
            var entity = await _ctx.Makes.AddAsync(_mapper.Map<Make>(makeDto));
            
            _ctx.SaveChanges();

            return entity.Entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            _ctx.Remove(GetMakeById(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(MakeCreateDto makeDto, int id)
        {
            var make = _ctx.Makes.Find(id);

            if (make.Name != makeDto.Name)
                make.Name = makeDto.Name;

            await _ctx.SaveChangesAsync();
        }
    }
}
