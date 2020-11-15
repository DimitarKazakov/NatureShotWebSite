namespace NatureShot.Web.CloudinaryHelper
{
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryExtension
    {
        public CloudinaryExtension()
        {

        }

        public static async Task<string> UploadImageAsync(Cloudinary cloudinary, IFormFile imageFile)
        {
            var result = "";
            byte[] destinationImage;

            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(destinationImage))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(imageFile.FileName, destinationStream),
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                result = uploadResult.Url.AbsoluteUri;
            }

            return result;
        }
    }
}
