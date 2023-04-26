using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
namespace BlogAppAPI.Services.UploadImage
{
    public class UploadImageService
    {   
        public UploadImageService() { }
        public void upload()
        {
            var cloudinary = new Cloudinary(new Account("dnshdled2", "278276873974371", "uA82HjnDFeTVYnLLtdshkwouFcE"));

            // Upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"https://upload.wikimedia.org/wikipedia/commons/a/ae/Olympic_flag.jpg"),
                PublicId = "olympic_flag"
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            //Transformation
            cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(100).Height(150).Crop("fill")).BuildUrl("olympic_flag");
        }
    }
}
