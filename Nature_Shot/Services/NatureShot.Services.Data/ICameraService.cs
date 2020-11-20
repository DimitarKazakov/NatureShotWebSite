namespace NatureShot.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using NatureShot.Data.Models;

    public interface ICameraService
    {
        Task<Camera> GetCameraByNameAsync(string cameraName);
    }
}
