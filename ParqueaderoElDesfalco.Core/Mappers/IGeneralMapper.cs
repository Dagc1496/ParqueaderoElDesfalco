namespace ParqueaderoElDesfalco.Core.Mappers
{
    public interface IGeneralMapper<T,U>
    {
        T MapEntityToObject(U entity);

        U MapObjectToEntity(T obj);
    }
}