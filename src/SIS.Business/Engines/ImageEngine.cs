using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json;
using RedStarter.Business.DataContract.Note;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.Engines
{
    public class ImageEngine : IImageEngine
    {
        public string UploadImageAndGetURL(NoteImageDTO image)
        {
            //TODO 7: Get a Cloudinary Account. Create the object like below.
            Account account = new Account(
                    "appname",
                    "publickey",  //You'll need to get these and hide them....
                    "secretkey"
                );

            //TODO 8: Follow the code below. Set a breakpoint and study each thing
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(image.Image.FileName, image.Image.OpenReadStream())
            };

            var cloudinary = new Cloudinary(account);
            var uploadResult = cloudinary.Upload(uploadParams);  //Hover over each one of these and ask questions. You should see
                                                                    //an image in Cloudinary after you run this line.
            var id = uploadResult.JsonObj;
            var data = JsonConvert.DeserializeObject<RawUploadResult>(id.ToString()); //Discussion question with partner: What is all this?

            var result = data.SecureUri.ToString();  

            return result;
        }
    }
}
