namespace ParqueaderoElDesfalco.Core.Mappers
{
    public interface IGeneralMapper<T,U>
    {
        T MapEntityToObject(U vehicleEntity);

        U MapObjectToEntity(T vehicleObject);
    }
}
