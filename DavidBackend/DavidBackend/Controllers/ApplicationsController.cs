using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using DavidBackend.Models;
using DavidBackend.Services;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DavidBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private ApplicationRepository _applicationsRepository;

        public ApplicationsController()
        {
            _applicationsRepository = new ApplicationRepository();
        }

        /// <summary>
        /// This returns a list of applications for the specific room.
        /// </summary>
        /// <param name="room">This is used to return only applications for this room.</param>
        /// <returns></returns>
        [Route("api/room/{room}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Application>), Description = "Success.")]
        public ActionResult GetApplications(string room)
        {
            return Ok(_applicationsRepository.GetApplications(room));
        }
    }
}
