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
    public class VehicleColorRepository
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public VehicleColorRepository(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleColorReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<VehicleColorReadDto>>(await _ctx.VehicleColors.Include(x => x.Models).ToListAsync());
        }

        public async Task<VehicleColorReadDto> GetColorByIdAsync(int id)
        {
            return _mapper.Map<VehicleColorReadDto>(await _ctx.VehicleColors.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<VehicleColorReadDto> GetColorByNameAsync(string name)
        {
            return _mapper.Map<VehicleColorReadDto>(await _ctx.VehicleColors.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
        }

        public VehicleColor GetColorById(int id)
        {
            return _ctx.VehicleColors.FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> AddAsync (VehicleColorCreateDto colorDto)
        {
            var entity = await _ctx.VehicleColors.AddAsync(_mapper.Map<VehicleColor>(colorDto));

            await _ctx.SaveChangesAsync();

            return entity.Entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            _ctx.Remove(GetColorById(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, VehicleColorCreateDto colorDto)
        {
            var color = GetColorById(id);

            if (color.Name != colorDto.Name)
                color.Name = colorDto.Name;

            await _ctx.SaveChangesAsync();
        }
    }
}
