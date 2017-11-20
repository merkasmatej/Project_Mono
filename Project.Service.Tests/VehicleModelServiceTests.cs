using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;
using Project.Service;
using Project.Repository.Common;
using Project.Service.Common;
using Project.Model.Common;
using Project.Model;
using Project.Common;

namespace Project.Service.Tests
{
    public class VehicleModelServiceTests
    {
        

        [Fact]

        public void GetByModelIDAsync_ModelNotFound_ThrowsNull()
        {   //arrange
            var repository = new Mock<IVehicleModelRepository>();
            Guid modelIdArg = Guid.Empty;

            repository
                .Setup(m => m.GetByModelIDAsync(It.Is<Guid>(id => id == modelIdArg)))
                .ReturnsAsync(() => null);


            var classForTesting = new VehicleModelService(repository.Object);
            //act
            var result = classForTesting.GetByModelIDAsync(modelIdArg);
            //assert
            result.Should().BeNull();

            
        }

        [Fact]

        public async void GetByModelIDAsync_Success_ReturnNotNull()
        {   //arrange
            var repository = new Mock<IVehicleModelRepository>();
            Guid modelIdArg = Guid.NewGuid();

            repository
                .Setup(m => m.GetByModelIDAsync(It.Is<Guid>(id => id == modelIdArg)))
                .ReturnsAsync(() => new VehicleModel());

            var classForTesting = new VehicleModelService(repository.Object);

            //act
            var result = await classForTesting.GetByModelIDAsync(modelIdArg);

            //assert

            result.Should().NotBeNull();
        }

        [Fact]

        public async void AddAsync_InvalidParameters_ReturnsMinus1()
        {   //arrange
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            //1. test
            var result = await classForTesting.AddAsync(Guid.NewGuid(), Guid.NewGuid(), null, "test");
            result.Should().Be(-1);
        }

        [Fact]

        public async void AddAsync_InvalidParameters_ReturnsMinus2()
        {   //arrange
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            //2. test
            var result = await classForTesting.AddAsync(Guid.NewGuid(), Guid.NewGuid(), "test", null);
            result.Should().Be(-2);
        }

        [Fact]

        public async void AddAsync_InvalidParameters_ReturnsMinus3()
        {   //arrange
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            //3. test
            var result = await classForTesting.AddAsync(Guid.Empty, Guid.NewGuid(), "test", "test");
            result.Should().Be(-3);
        }

        [Fact]

        public async void AddAsync_InvalidParameters_ReturnsMinus4()
        {
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            var result = await classForTesting.AddAsync(Guid.NewGuid(), Guid.Empty, "test", "test");
            result.Should().Be(-4);

        }

        [Fact]

        public async void AddAsync_validParameters_ReturnsNull()
        {
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            var result = await classForTesting.AddAsync(Guid.NewGuid(), Guid.NewGuid(), "test", "test");

            result.Should().Be(0);
        }

        [Fact]

        public async void UpdateAsync_InvalidParameters_ReturnsMinus1()
        {
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            var result = await classForTesting.UpdateAsync(Guid.NewGuid(), Guid.NewGuid(), null, "test");

            result.Should().Be(-1);
        }

        [Fact]

        public async void UpdateAsync_InvalidParameters_ReturnsMinus2()
        {
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            var result = await classForTesting.UpdateAsync(Guid.NewGuid(), Guid.NewGuid(), "test", null);

            result.Should().Be(-2);
        }

        [Fact]

        public async void UpdateAsync_InvalidParameters_ReturnsMinus3()
        {
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            var result = await classForTesting.UpdateAsync(Guid.Empty, Guid.NewGuid(), "test", "test");

            result.Should().Be(-3);
        }

        [Fact]

        public async void UpdateAsync_InvalidParameters_ReturnsMinus4()
        {
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            var result = await classForTesting.UpdateAsync(Guid.NewGuid(), Guid.Empty, "test", "test");
            result.Should().Be(-4);

        }

        

        [Fact]

        public async void DeleteAsync_Success_Returns0()
        {
            var repository = new Mock<IVehicleModelRepository>();

            var classForTesting = new VehicleModelService(repository.Object);

            var result = await classForTesting.DeleteAsync(Guid.NewGuid());
            result.Should().Be(0);

        }

       
    }

    


}
