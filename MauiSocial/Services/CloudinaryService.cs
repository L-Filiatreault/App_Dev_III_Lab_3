
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using System.Reflection;


namespace MauiSocial.Services
{
    /// <summary>
    /// This service provides an interface with the Cloudinary functionalities of upload pictures online
    /// </summary>
    public class CloudinaryService
    {
        CloudinaryConfig _config { get; }
        Cloudinary _cloudinary   { get; }
        public CloudinaryService()
        {
            ///\ TODO: Get the appsettings.json stream and parse it into a CloudinaryConfig object. 
            ///then use it to initialize the Cloudinary object with a valid account. Don't forget to handle exceptions.
            
        }
        /// <summary>
        /// Uploads and image asynchronously on cloudinary
        /// </summary>
        /// <param name="imageFilePath">local path to the image file</param>
        /// <param name="imageName">name underwhich the image is saved</param>
        /// <returns>ImageUpload result</returns>
        public async Task<ImageUploadResult> UploadImageAsync(string imageFilePath,string imageName)
        {
            ///\ TODO: Create ImageUploadParams and Upload the image asynchronously and return the result
            ///Don't forget to handle exceptions.
            return new ImageUploadResult();

        }
    }
}
