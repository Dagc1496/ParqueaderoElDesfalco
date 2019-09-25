using System.Threading.Tasks;

namespace ParqueaderoElDesfalco.Core.Validators
{
    public interface IParkingSpaceValidator
    {
        Task<bool> IsCarSpaceInParkingLot();

        Task<bool> IsMotorcycleSpaceInParkingLot();
    }
}
