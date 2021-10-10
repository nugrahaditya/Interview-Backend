using Microsoft.AspNetCore.Mvc;
using Moduit.Interview.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Moduit.Interview.Controllers
{
    [Route("api/One")]
    [ApiController]
    public class OneController : Controller
    {
        private readonly Uri _moduitUrl = new Uri("https://screening.moduit.id/");

        public IActionResult Index()
        {
            return View();
        }

        /**
         * Question One
         * Assumption:
         *  None
         */
        [HttpGet]
        public async Task<ActionResult<QOne>> GetOne()
        {
            var qOne = new QOne();
            var qOneUri = new Uri(_moduitUrl, "backend/question/one");

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(qOneUri);
                var apiResponse = await response.Content.ReadAsStringAsync();
                qOne = JsonConvert.DeserializeObject<QOne>(apiResponse);
            }

            return qOne;
        }
    }
}
