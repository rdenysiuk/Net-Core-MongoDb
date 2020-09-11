using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;
using CarBL.Services;
using Xunit;
using Moq;
using AutoMapper;
using CarBL.Models;
using CarDL.Entities;

namespace CarXUnitTest
{
    public class CarServiceTest
    {
        public string carIdExample = "1234567890abcdefghklmnop";
        public string carIdZero = "0000";
        private readonly CarService _sut;
        private readonly Mock<ICarRepository> _carRepoMock = new Mock<ICarRepository>();
        private readonly IMapper _mapper;

        public CarServiceTest()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.AddProfile(new DtoToEntity());
            });
            _mapper = mapperConfig.CreateMapper();
            _sut = new CarService(_carRepoMock.Object, _mapper);
        }
        [Fact]
        public async Task Get_ShouldReturnCar_WhenExist()
        {
            //Arange
            var car = new Car(carIdExample, "Skoda", "Skoda", 12000);
            _carRepoMock.Setup(x => x.Get(carIdExample))
                .ReturnsAsync(car);

            //Act
            var carModel = await _sut.Get(carIdExample);

            //Assert
            Assert.NotNull(carModel);
            Assert.Equal(carIdExample, carModel.Id);
            Assert.IsType<CarModel>(carModel);
        }

        [Fact]
        public async Task Get_ShouldReturnNull_WhenDoNotExist()
        {
            //Arange
            var car = new Car(carIdExample, "Skoda", "Skoda", 12000);
            _carRepoMock.Setup(x => x.Get(carIdExample))
                .ReturnsAsync(car);

            //Act
            var carModel = await _sut.Get(carIdZero);

            //Assert
            Assert.Null(carModel);  
        }

        [Fact]
        public async Task GetAll_ShouldReturnCars()
        {
            //Arange
            var carList4 = new List<Car>
            {
                new Car(carIdExample, "Skoda", "Octavia", 9000),
                new Car(carIdExample, "Skoda", "Superb", 12000),
                new Car(carIdExample, "Skoda", "Fabia", 5000),
                new Car(carIdExample, "Skoda", "Karoq", 22000)
            };
            _carRepoMock.Setup(x => x.GetAll())
                .ReturnsAsync(carList4);

            //Act
            var carModelList4 = await _sut.GetAll();

            //Assert
            Assert.NotNull(carModelList4);
            Assert.Equal(4, carModelList4.Count);
        }

        //TODO
        public async Task New_ShouldReturnCar_AfterAdd()
        {
            //Arange
            var car = new Car(carIdExample, "Skoda", "Skoda", 12000);

            _carRepoMock.Setup(x => x.New(car))
                .ReturnsAsync(car.Id);

            //Act
            var carModelId = await _sut.New(_mapper.Map<CarModel>(car));

            //Assert
            Assert.NotNull(carModelId);
            Assert.NotEmpty(carModelId);
            Assert.Equal(carIdExample, carModelId);
        }
        
        //TODO
        /*
         * Repo method has a filter and update definishion
         * it can be reason why the test is fails
         */
        public async Task Edit_ShouldReturnEditResult_AfterEdit()
        {
            //Arange
            var car = new Car(carIdExample, "Skoda", "Skoda", 12000);
            var updateResultMock = new Mock<UpdateResult>();
            updateResultMock.Setup(x => x.IsAcknowledged).Returns(true);
            updateResultMock.Setup(x => x.ModifiedCount).Returns(1);

            _carRepoMock.Setup(x => x.Edit(car))
                .ReturnsAsync(updateResultMock.Object);

            //Act
            UpdateResult updateResultCar = await _sut.Edit(_mapper.Map<CarModel>(car));

            //Assert
            Assert.NotNull(updateResultCar);
            Assert.True(updateResultCar.IsAcknowledged);
            Assert.InRange(updateResultCar.ModifiedCount, 1, 2);
        }

        [Fact]
        public async Task Delete_ShouldReturnDeleteResult_AfterDeleting()
        {
            //Arange
            var deleteResultMock = new Mock<DeleteResult>();
            deleteResultMock.Setup(x => x.IsAcknowledged).Returns(true);
            deleteResultMock.Setup(x => x.DeletedCount).Returns(1);

            _carRepoMock.Setup(x => x.Delete(carIdExample))
                .ReturnsAsync(deleteResultMock.Object);

            //Act
            DeleteResult deleteResultCar = await _sut.Delete(carIdExample);

            //Assert
            Assert.NotNull(deleteResultCar);
            Assert.True(deleteResultCar.IsAcknowledged);
            Assert.InRange(deleteResultCar.DeletedCount, 1, 2);
        }
    }
}
