using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ImageProcessor.Imaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Mojifier.Helpers;
using Mojifier.Models;

namespace Mojifier
{
    public static class MojifyImage
    {

        [FunctionName("MojifyImage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<Face> facesResponse = new List<Face>();
            log.LogInformation("C# HTTP trigger function processed a request.");
            byte[] mojifiedImage = null;
            if (req.Query.ContainsKey("imageUrl"))
            {
                string imageUrl = req.Query["imageUrl"];
                facesResponse = await FaceApi.GetFaces(imageUrl);
                mojifiedImage = await CreateMojifyImage.CreateMojifiedImage(imageUrl,facesResponse);
            }
            else
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                facesResponse = await FaceApi.GetFaces(requestBody);
                mojifiedImage = await CreateMojifyImage.CreateMojifiedImage(requestBody,facesResponse);
            }


            //req.HttpContext.Response.ContentType = "image/png";
            //name = name ?? data?.name;

            return mojifiedImage != null
                ? (ActionResult)new FileContentResult(mojifiedImage, "image/png")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
