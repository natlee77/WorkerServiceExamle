﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctions
{
    public static class GetTemperature// class 
    { // vi ser funk.

        [FunctionName("GetTemperature")]   //property funk name atribbut помечает точку входа 
        
        public static async Task<IActionResult> Run(      //i <> skrivs vilken data typ förväntas tillbaka
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {


            // http://localhost:7071/api/GetTemperature?name=Hans

            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            //{"name": "Hans", "surname": "ML", "theage":36}

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var data = JsonConvert.DeserializeObject<dynamic>(requestBody);

            //?=nullable
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
