using System;
using Emergent_Software_Version_Software_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Emergent_Software_Version_Software_Api.Controllers
{
    [Route("software/")]
    public class SoftwareService : Controller
    {
        public readonly ISoftwareManager manager;
        public SoftwareService(ISoftwareManager manager)
        {
            this.manager = manager;
        }

        [HttpGet("{version}")]
        public IActionResult Get(string version)
        {
            try
            {
                return Ok(this.manager.GetHigherVersion(version));
            }
            catch (Exception)
            {
                return BadRequest(); 
            }
        }
    }
}
