using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using Mojifier.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace Mojifier.Helpers
{
    public static class CreateMojifyImage
    {
        async public static Task<byte[]> CreateMojifiedImage(string imageUrl, List<Face> faces)
        {
            string STORAGE_ACCOUNT_URL= System.Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_URL", EnvironmentVariableTarget.Process);
            byte[] imageBytes = null;
            try
            {


                var client = new HttpClient();
                
                    imageBytes = await client.GetByteArrayAsync(imageUrl);
                

                using (MemoryStream faceImageStream = new MemoryStream(imageBytes))
                {
                    Image faceImage = Image.Load(faceImageStream);
                    foreach (var face in faces)
                    {
                        byte[] emojiImageBytes =
                            await client.GetByteArrayAsync(string.Format("{0}/{1}.png", STORAGE_ACCOUNT_URL, face.moji.MojiName));
                        using (MemoryStream emojiImageStream = new MemoryStream(emojiImageBytes))
                        {
                            Image emojiImage = Image.Load(emojiImageStream);
                            emojiImage.Mutate(x=>x.Resize(face.FaceRectangle.width, face.FaceRectangle.height));
                            faceImage.Mutate(x=>x.DrawImage(emojiImage,new Point(face.FaceRectangle.left, face.FaceRectangle.top),1));
                        }
                    }

                    using (var ms=new MemoryStream())
                    {
                        faceImage.Save(ms,new PngEncoder());
                        return ms.ToArray();
                    }
                    //var finalImage = faceImage
                    //return finalImage;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
    }
}