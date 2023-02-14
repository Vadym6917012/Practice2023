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
    public class ModelRepository
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public ModelRepository(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ModelReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<ModelReadDto>>(await _ctx.Models.Include(x => x.Make).Include(x => x.VehicleColor).ToListAsync());
        }

        public async Task<ModelReadDto> GetModelByIdAsync(int id)
        {
            return _mapper.Map<ModelReadDto>(await _ctx.Models.Include(x => x.Make).Include(x => x.VehicleColor).FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<ModelReadDto> GetModelByNameAsync(string name)
        {
            return _mapper.Map<ModelReadDto>(await _ctx.Models.Include(x => x.Make).Include(x => x.VehicleColor).FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
        }

        public Model GetModelById(int id)
        {
            return _ctx.Models.Include(x => x.Make).Include(x => x.VehicleColor).FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> AddAsync(ModelCreateDto modelDto)
        {
            var entity = await _ctx.Models.AddAsync(_mapper.Map<Model>(modelDto));

            _ctx.SaveChanges();

            return entity.Entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            _ctx.Remove(GetModelById(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ModelCreateDto modelDto)
        {
            var model = _ctx.Models.Include(x => x.Make).Include(x => x.VehicleColor).FirstOrDefault(x => x.Id == id);

            if (model.Name != modelDto.Name)
                model.Name = modelDto.Name.ToLower();
            if(model.MakeId != modelDto.MakeId)
                model.Make = _ctx.Makes.FirstOrDefault(x => x.Id == modelDto.MakeId);
            if (model.VehicleColorId != modelDto.VehicleColorId)
                model.VehicleColor = _ctx.VehicleColors.FirstOrDefault(x => x.Id == modelDto.VehicleColorId);

            _ctx.SaveChanges();
        }
    }
}
