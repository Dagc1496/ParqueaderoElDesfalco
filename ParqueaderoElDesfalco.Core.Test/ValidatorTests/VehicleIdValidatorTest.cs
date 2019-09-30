using System;
using Xunit;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;

namespace ParqueaderoElDesfalco.Core.Test
{
    public class VehicleIdValidatorTest
    {
        #region Vars and const of TestClass

        private readonly string notAllowedIdUpper = "ALE-567";
        private readonly string notAllowedIdLower = "ale-567";
        private readonly string allowedId = "bki-475";
        private readonly DateTimeOffset AllowedDateMonday = new DateTimeOffset(2019,09,23,8,0,0, new TimeSpan(0,0,0));
        private readonly DateTimeOffset NotAllowedDateTuesday = new DateTimeOffset(2019, 09, 24, 8, 0, 0, new TimeSpan(0, 0, 0));

        #endregion

        #region Tests

        [Fact]
        public void TestNotAllowedVechicleIdAllowedDate()
        {
            //Arrange
            VehicleIdParkingDayValidator vehicleIdParkingDayValidator = new VehicleIdParkingDayValidator();

            //Act
            bool resultOfValidationUpper = vehicleIdParkingDayValidator.
                                           IsAllowedToPark(notAllowedIdUpper,AllowedDateMonday);
            bool resultOfValidationLower = vehicleIdParkingDayValidator.
                                           IsAllowedToPark(notAllowedIdLower,NotAllowedDateTuesday);

            //Assert
            Assert.True(resultOfValidationUpper);
            Assert.False(resultOfValidationLower);
        }

        [Fact]
        public void TestNotAllowedVechicleIdNotAllowedDate()
        {
            //Arrange
            VehicleIdParkingDayValidator vehicleIdParkingDayValidator = new VehicleIdParkingDayValidator();

            //Act
            bool resultOfValidationUpper = vehicleIdParkingDayValidator.
                                           IsAllowedToPark(notAllowedIdUpper,NotAllowedDateTuesday);
            bool resultOfValidationLower = vehicleIdParkingDayValidator.
                                           IsAllowedToPark(notAllowedIdLower,NotAllowedDateTuesday);

            //Assert
            Assert.False(resultOfValidationUpper);
            Assert.False(resultOfValidationLower);
        }

        [Fact]
        public void TestAllowedVechicleIdAllowedDate()
        {
            //Arrange
            VehicleIdParkingDayValidator vehicleIdParkingDayValidator = new VehicleIdParkingDayValidator();

            //Act
            bool resultOfValidation = vehicleIdParkingDayValidator.
                                      IsAllowedToPark(allowedId, AllowedDateMonday);

            //Assert
            Assert.True(resultOfValidation);
        }

        #endregion
    }
}
