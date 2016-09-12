﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    public class DoStuffController : Controller
    {
        private string _doSomethingBaseAddress;
        private string _doSomethingAPIUrl;
        public DoStuffController()
        {
            _doSomethingBaseAddress = "http://dostuffwebapi";
            _doSomethingAPIUrl = "/api/DoSomething";
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            //
            // Get the HttpRequest
            //
            HttpClient client = new HttpClient();
            HttpRequestMessage request = 
                new HttpRequestMessage(HttpMethod.Get, _doSomethingBaseAddress + _doSomethingAPIUrl);

            HttpResponseMessage response = await client.SendAsync(request);

            //
            // Return a response from the Crazy 8 Ball Service
            //
            if (response.IsSuccessStatusCode)
            {
                List<Dictionary<String, String>> responseElements = new List<Dictionary<String, String>>();
                JsonSerializerSettings settings = new JsonSerializerSettings();
                String responseString = await response.Content.ReadAsStringAsync();
                ViewData["Answer"] = responseString;

            }
            return View();
        }
    }
}
