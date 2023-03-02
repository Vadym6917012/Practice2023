using AutoMapper;
using AutomobileCatalog.Server.Core;
using AutomobileCatalog.Shared.Dtos;
using Microsoft.EntityFrameworkCore;


namespace AutomobileCatalog.Server.Infrastructure
{
    public class VehicleRepository
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public VehicleRepository(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<VehicleReadDto>>(await _ctx.Vehicles
                .Include(x => x.VehicleModel)
                .ThenInclude(x =>x.Make)
                .Include(x =>x.Price).ToListAsync());
        }

        public async Task<VehicleReadDto> GetVehicleByIdAsync(int id)
        {
            return _mapper.Map<VehicleReadDto>(await _ctx.Vehicles.Include(x => x.VehicleModel)
                .ThenInclude(x => x.VehicleColor)
                .Include(x => x.VehicleModel)
                .ThenInclude(x => x.Make)
                .Include(x => x.Price)
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public Vehicle GetVehicleById(int id)
        {
            return _ctx.Vehicles.Include(x => x.VehicleModel).ThenInclude(x => x.Make).Include(x => x.Price).FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> AddAsync(VehicleCreateDto vehicleDto)
        {
			var entity = await _ctx.Vehicles.AddAsync(_mapper.Map<Vehicle>(vehicleDto));

            _ctx.SaveChanges();

            return entity.Entity.Id;

        }

        public async Task DeleteAsync(int id)
        {
            _ctx.Remove(GetVehicleById(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, VehicleCreateDto vehicleDto)
        {
            var vehicle = GetVehicleById(id);

            if (vehicle.VehicleModelId != vehicleDto.VehicleModelId)
                vehicle.VehicleModel = _ctx.Models.FirstOrDefault(x => x.Id == vehicleDto.VehicleModelId);
            if (vehicle.EngineCapacity != vehicleDto.EngineCapacity)
                vehicle.EngineCapacity = vehicleDto.EngineCapacity;
            if (vehicle.ImageUrl != vehicleDto.ImageUrl)
                vehicle.ImageUrl = vehicleDto.ImageUrl;
            //if (vehicle.PriceId != vehicleDto.PriceId)
            //    vehicle.Price = _ctx.Prices.FirstOrDefault(x => x.Id == vehicleDto.PriceId);
            if (vehicle.Description != vehicleDto.Description)
                vehicle.Description = vehicleDto.Description;

            await _ctx.SaveChangesAsync();
        }
    }
}
