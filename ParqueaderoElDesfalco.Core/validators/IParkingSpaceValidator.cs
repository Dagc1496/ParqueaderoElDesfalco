namespace ParqueaderoElDesfalco.Core.Validators
{
    public interface IParkingSpaceValidator
    {
        bool IsCarSpaceInParkingLot();
        bool IsMotorcycleSpaceInParkingLot();
    }
}
