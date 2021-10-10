using Microsoft.AspNetCore.Mvc;
using Moduit.Interview.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Moduit.Interview.Controllers
{
    [Route("api/Three")]
    [ApiController]
    public class ThreeController : Controller
    {
        private readonly Uri _moduitUrl = new Uri("https://screening.moduit.id/");

        public IActionResult Index()
        {
            return View();
        }

        /**
         * Question Three
         * Assumption:
         *  1. If response object doesn't have Items, then it won't be added to the result list 
         */
        [HttpGet]
        public async Task<ActionResult<List<QThreeFlatten>>> GetThree()
        {
            var qThreeList = new List<QThreeFlatten>();
            var qThree = new List<QThree>();
            var qThreeUri = new Uri(_moduitUrl, "backend/question/three");

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(qThreeUri);
                var apiResponse = await response.Content.ReadAsStringAsync();
                qThree = JsonConvert.DeserializeObject<List<QThree>>(apiResponse);
            }

            foreach (var qthree in qThree)
            {
                foreach (var qthreeItem in qthree.Items)
                {
                    qThreeList.Add(new QThreeFlatten
                    {
                        Id = qthree.Id,
                        Category = qthree.Category,
                        CreatedAt = qthree.CreatedAt,
                        Title = qthreeItem.Title,
                        Description = qthreeItem.Description,
                        Footer = qthreeItem.Footer,
                        Tags = qthree.Tags
                    });
                }
            }

            return qThreeList;
        }
    }
}
