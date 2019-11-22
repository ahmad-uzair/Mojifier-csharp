# Mojifier-csharp : Overlay emojis on faces based on the emotion detected using Microsoft Cognitive Services and Azure Functions

### Hey there! :wave:

This project was an inspiration from one of the [courses at Microsoft Learn for making a Mojifier slackbot](https://docs.microsoft.com/en-us/learn/modules/replace-faces-with-emojis-matching-emotion/?WT.mc_id=mojiifierweb-mojifier-ashussai) but using Typescript. 

This project has been completely rewritten in C# and using different libraries and methods.



### What is it exactly? :question::thinking:

We are leveraging the power of serverless computing and AI to detect faces and their emotions from a picture and overlaying appropriate emojis on them. We use Face API from Microsoft Cognitive Services to detect faces and their emotions in a picture and then the Azure Function processes the image, adds an overlay and returns the Mojified image. The flow is as shown below:

