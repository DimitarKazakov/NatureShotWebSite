namespace NatureShot.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data.Models;

    public class CameraService : ICameraService
    {
        private readonly IDeletableEntityRepository<Camera> cameraRepository;

        public CameraService(IDeletableEntityRepository<Camera> cameraRepository)
        {
            this.cameraRepository = cameraRepository;
        }

        public async Task<Camera> GetCameraByNameAsync(string cameraName)
        {
            var camera = this.cameraRepository.All().FirstOrDefault(x => x.Model == cameraName);
            if (camera == null)
            {
                camera = new Camera
                {
                    Model = cameraName,
                };

                await this.cameraRepository.AddAsync(camera);
                await this.cameraRepository.SaveChangesAsync();
            }

            return camera;
        }
    }
}
