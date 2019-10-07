namespace ParqueaderoElDesfalco.Core.Mappers
{
    public interface IGeneralMapper<TModel, TEntity>
    {
        TModel MapEntityToObject(TEntity vehicleEntity);

        TEntity MapObjectToEntity(TModel vehicleObject);
    }
}
