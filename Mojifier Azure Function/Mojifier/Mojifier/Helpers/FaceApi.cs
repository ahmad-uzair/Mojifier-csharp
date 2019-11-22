using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Mojifier.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mojifier.Helpers
{
    public static class FaceApi
    { 


        async public static Task<List<Face>> GetFaces(byte[] image)
        {
            string API_URL = System.Environment.GetEnvironmentVariable("FACE_API_URL", EnvironmentVariableTarget.Process);
            string API_KEY =
                System.Environment.GetEnvironmentVariable("FACE_API_KEY", EnvironmentVariableTarget.Process);
            // Request parameters".
            string FaceApiUrlWithParams =
                API_URL + "/detect?returnFaceId=false&returnFaceLandmarks=false&returnFaceAttributes=emotion";

            HttpClient client=new HttpClient();

            // Request headers.
            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", API_KEY);

            ByteArrayContent content = new ByteArrayContent(image);

            content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

            HttpResponseMessage response=await client.PostAsync(FaceApiUrlWithParams,content);

            List<Face> facesToProcess = new List<Face>();
            var faces = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(faces);
            foreach (var face in data)
            {
                var emotionScore = JsonConvert.DeserializeObject<EmotivePoint>(face.faceAttributes.emotion);
                var faceRectangle = JsonConvert.DeserializeObject<FaceRectangle>(face.faceRectangle);
                var newFace = new Face(emotionScore, faceRectangle);
                facesToProcess.Add(newFace);
            }

            return facesToProcess;
        }

        async public static Task<List<Face>> GetFaces(string imageUrl)
        {
            string API_URL = System.Environment.GetEnvironmentVariable("FACE_API_URL", EnvironmentVariableTarget.Process);
            string API_KEY =
                System.Environment.GetEnvironmentVariable("FACE_API_KEY", EnvironmentVariableTarget.Process);
            // Request parameters".
            string FaceApiUrlWithParams =
                API_URL + "/detect?returnFaceId=false&returnFaceLandmarks=false&returnFaceAttributes=emotion";

            HttpClient client = new HttpClient();

            // Request headers.
            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", API_KEY);

            //var jsonURL = "{ url : " + imageUrl+ " }";
            var jsonURL = JsonConvert.SerializeObject(new {url = imageUrl});


            StringContent content = new StringContent(jsonURL);

            content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/json");
            try
            {

          
            HttpResponseMessage response = await client.PostAsync(FaceApiUrlWithParams, content);

            List<Face> facesToProcess= new List<Face>();
            var faces = await response.Content.ReadAsStringAsync();
            JArray data = JArray.Parse(faces);
            foreach (var face in data)
            {
                //var emotionScore= JsonConvert.DeserializeObject<EmotivePoint>(face.faceAttributes.emotion);
                var emotionScore=new EmotivePoint(face["faceAttributes"]["emotion"]["anger"].Value<double>(), face["faceAttributes"]["emotion"]["contempt"].Value<double>(), face["faceAttributes"]["emotion"]["disgust"].Value<double>(), face["faceAttributes"]["emotion"]["fear"].Value<double>(), face["faceAttributes"]["emotion"]["happiness"].Value<double>(), face["faceAttributes"]["emotion"]["neutral"].Value<double>(), face["faceAttributes"]["emotion"]["sadness"].Value<double>(), face["faceAttributes"]["emotion"]["surprise"].Value<double>());
                //var faceRectangle= JsonConvert.DeserializeObject<FaceRectangle>(face.faceRectangle);
                var faceRectangle=new FaceRectangle(face["faceRectangle"]["top"].Value<int>(), face["faceRectangle"]["left"].Value<int>(), face["faceRectangle"]["width"].Value<int>(), face["faceRectangle"]["height"].Value<int>());
                var newFace = new Face(emotionScore, faceRectangle);
                facesToProcess.Add(newFace);
            }

            return facesToProcess;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}