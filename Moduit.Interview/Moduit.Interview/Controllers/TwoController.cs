using Microsoft.AspNetCore.Mvc;
using Moduit.Interview.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Moduit.Interview.Controllers
{
    [Route("api/Two")]
    [ApiController]
    public class TwoController : Controller
    {
        private readonly Uri _moduitUrl = new Uri("https://screening.moduit.id/");

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<List<QOne>>> GetTwo()
        {
            var qTwoUri = new Uri(_moduitUrl, "backend/question/two");
            List<QOne> qTwoList = new List<QOne>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(qTwoUri))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    qTwoList = JsonConvert.DeserializeObject<List<QOne>>(apiResponse);
                }
            }

            return qTwoList.Where(t => (t.Description.ToLower().Contains("ergonomics") || t.Title.ToLower().Contains("ergonomics")) && 
                                        (t.Tags != null && t.Tags.Contains("Sports")))
                .OrderByDescending(t => t.Id)
                .Take(3)
                .ToList();
        }

    }
}
