using AutoMapper;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Mappers
{
    public class CarMapper : IGeneralMapper<Car,CarEntity>
    {

        #region Class vars and constants

        private IMapper mapper;

        #endregion

        #region Constructor

        public CarMapper()
        {
            InitializeMapper();
        }

        #endregion

        #region Class methods

        public void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(mapperCfg => mapperCfg.CreateMap<Car, CarEntity>()
                                                       .ForMember(entity => entity.CarId,
                                                       model => model.MapFrom(src => src.VehicleId))
                                                       .ReverseMap()
                                                       .ConstructUsing(entity => new Car(entity.CarId, entity.DateOfEntry)));
            mapper = mapperConfig.CreateMapper();
        }

        public Car MapEntityToObject(CarEntity vehicleEntity)
        {
            Car car = mapper.Map<Car>(vehicleEntity);
            return car;
        }

        public CarEntity MapObjectToEntity(Car vehicleObject)
        {
            CarEntity carEntity = mapper.Map<CarEntity>(vehicleObject);
            return carEntity;
        }

        #endregion
    }
}
