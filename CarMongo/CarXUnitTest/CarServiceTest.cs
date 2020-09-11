using System.Collections.Generic;
using System.Threading.Tasks;
using CarBL.Services;
using Xunit;
using Moq;
using AutoMapper;
using CarBL.Models;
using CarBL.Interfaces;
using CarDL.Mapping;

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
                conf.AddProfile(new MappingProfile());
            });
            _mapper = mapperConfig.CreateMapper();
            _sut = new CarService(_carRepoMock.Object);
        }
        [Fact]
        public async Task Get_ShouldReturnCar_WhenExist()
        {
            //Arange
            var car = new CarModel(carIdExample, "Skoda", "Skoda", 12000);
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
            var car = new CarModel(carIdExample, "Skoda", "Skoda", 12000);
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
            var carList4 = new List<CarModel>
            {
                new CarModel(carIdExample, "Skoda", "Octavia", 9000),
                new CarModel(carIdExample, "Skoda", "Superb", 12000),
                new CarModel(carIdExample, "Skoda", "Fabia", 5000),
                new CarModel(carIdExample, "Skoda", "Karoq", 22000)
            };
            _carRepoMock.Setup(x => x.GetAll())
                .ReturnsAsync(carList4);

            //Act
            var carModelList4 = await _sut.GetAll();

            //Assert
            Assert.NotNull(carModelList4);
            Assert.Equal(4, carModelList4.Count);
        }

        [Fact]
        public async Task New_ShouldReturnCar_AfterAdd()
        {
            //Arange
            var car = new CarModel(carIdExample, "Skoda", "Skoda", 12000);

            _carRepoMock.Setup(x => x.New(car))
                .ReturnsAsync(car.Id);

            //Act
            var carModelId = await _sut.New(_mapper.Map<CarModel>(car));

            //Assert
            Assert.NotNull(carModelId);
            Assert.NotEmpty(carModelId);
            Assert.Equal(carIdExample, carModelId);
        }
                
        [Fact]
        public async Task Edit_ShouldReturnEditResult_AfterEdit()
        {
            //Arange
            var car = new CarModel(carIdExample, "Skoda", "Skoda", 12000);
            long updatedCountMock = 1;
            _carRepoMock.Setup(x => x.Edit(car))
                .ReturnsAsync(updatedCountMock);

            //Act
            var updatedCount = await _sut.Edit(_mapper.Map<CarModel>(car));

            //Assert
            Assert.InRange(updatedCount, 1, 2);
        }

        [Fact]
        public async Task Delete_ShouldReturnDeleteResult_AfterDeleting()
        {
            //Arange
            long updatedCountMock = 1;

            _carRepoMock.Setup(x => x.Delete(carIdExample))
                .ReturnsAsync(updatedCountMock);

            //Act
            long updatedCount = await _sut.Delete(carIdExample);

            //Assert
            Assert.InRange(updatedCount, 1, 2);
        }
    }
}
