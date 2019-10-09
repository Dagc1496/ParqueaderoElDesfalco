using ParqueaderoElDesfalco.Core.Domain.Models;

namespace ParqueaderoElDesfalco.Core.Mappers
{
    public interface IGeneralMapper<TModel, TEntity>
    {
        void InitializeMapper();

        TModel MapEntityToObject(TEntity vehicleEntity);

        TEntity MapObjectToEntity(TModel vehicleObject);
    }
}
