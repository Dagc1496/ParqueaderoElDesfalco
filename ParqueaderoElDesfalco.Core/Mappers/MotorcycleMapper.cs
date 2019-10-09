using AutoMapper;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Mappers
{
    public class MotorcycleMapper : IGeneralMapper<Motorcycle,MotorcycleEntity>
    {

        #region Class vars and constants

        private IMapper mapper;

        #endregion

        #region Constructor

        public MotorcycleMapper()
        {
            InitializeMapper();
        }

        #endregion

        #region Class methods

        public void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(mapperCfg => mapperCfg.CreateMap<Motorcycle, MotorcycleEntity>()
                                                       .ForMember(entity => entity.MotorcycleId,
                                                       model => model.MapFrom(src => src.VehicleId))
                                                       .ReverseMap()
                                                       .ConstructUsing(entity => new Motorcycle(entity.MotorcycleId, entity.DateOfEntry, entity.Cilindraje)));
            mapper = mapperConfig.CreateMapper();
        }

        public Motorcycle MapEntityToObject(MotorcycleEntity vehicleEntity)
        {
            Motorcycle motorcycle = mapper.Map<Motorcycle>(vehicleEntity);
            return motorcycle;
        }

        public MotorcycleEntity MapObjectToEntity(Motorcycle vehicleObject)
        {
            MotorcycleEntity motorcycleEntity = mapper.Map<MotorcycleEntity>(vehicleObject);
            return motorcycleEntity;
        }

        #endregion
    }
}
