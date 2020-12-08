namespace NatureShot.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using Xunit;

    public class CameraServiceTests
    {
        public CameraServiceTests()
        {
        }

        [Fact]
        public async Task GetCameraByNameShouldReturnCorrectCamera()
        {
            var list = new List<Camera>
            {
                new Camera
                {
                   Id = 1,
                   Model = "IphoneX",
                },
                new Camera
                {
                   Id = 2,
                   Model = "Iphone6",
                },
                new Camera
                {
                   Id = 3,
                   Model = "Xiomi Mi A3",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Camera>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            var service = new CameraService(repository.Object);

            var camera = await service.GetCameraByNameAsync("Iphone6");

            Assert.Equal("Iphone6", camera.Model);
            repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public async Task GetCameraByNameShouldAddTheCameraWhenThereIsNotSuch()
        {
            var list = new List<Camera>
            {
                new Camera
                {
                   Id = 1,
                   Model = "IphoneX",
                },
                new Camera
                {
                   Id = 2,
                   Model = "Iphone6",
                },
                new Camera
                {
                   Id = 3,
                   Model = "Xiomi Mi A3",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Camera>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            repository.Setup(r => r.AddAsync(It.IsAny<Camera>())).Callback((Camera camera) => list.Add(camera));
            var service = new CameraService(repository.Object);

            var camera = await service.GetCameraByNameAsync("Iphone7");

            Assert.Equal("Iphone7", camera.Model);
            Assert.Equal(4, list.Count);
            repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public void GetAllCameraKeyValuePairShouldReturnCorrectNumber()
        {
            var list = new List<Camera>
            {
                new Camera
                {
                   Id = 1,
                   Model = "IphoneX",
                },
                new Camera
                {
                   Id = 2,
                   Model = "Iphone6",
                },
                new Camera
                {
                   Id = 3,
                   Model = "Xiomi Mi A3",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Camera>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new CameraService(repository.Object);

            var cameras = service.GetAllCamerasAsKeyValuePair();

            Assert.Equal(3, cameras.Count());
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void GetAllCameraKeyValuePairShouldReturnZeroWhenEmpty()
        {
            var list = new List<Camera>();

            var repository = new Mock<IDeletableEntityRepository<Camera>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new CameraService(repository.Object);

            var cameras = service.GetAllCamerasAsKeyValuePair();

            Assert.Empty(cameras);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }
    }
}
