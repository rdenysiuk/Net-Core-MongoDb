using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarBL.Services;
using Xunit;
using Moq;
using CarBL.Services.Repository;
using CarEntities;

namespace CarXUnitTest
{
    public class CarServiceTest
    {
        public string fakeCarId = "1234567890abcdefghklmnop";
        private readonly CarService _sut;
        private Mock<ICarRepository> _carRepoMock = new Mock<ICarRepository>();
        public CarServiceTest()
        {
            _sut = new CarService(_carRepoMock.Object);
        }
        [Fact]
        public async Task Get_ShouldReturnCar_WhenExist()
        {
            //Arange
            
            var carDto = new Car {
                Id = fakeCarId,
                Name = "Skoda",
                Description = "Skoda",
                Price = 12000
            };
            _carRepoMock.Setup(x => x.Get(fakeCarId))
                .ReturnsAsync(carDto);

            //Act
            var car = await _sut.Get(fakeCarId);

            //Assert
            Assert.Equal(fakeCarId, car.Id);
        }
    }
}
