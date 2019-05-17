using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LaunchPads.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LaunchPads.Controllers
{


    [Route("api/launchpads")]
    [ApiController]
    public class LaunchpadsController : ControllerBase
    {
        IPadRepo Pads;
        ILogger Logger;

        public LaunchpadsController(IPadRepo pads, ILogger<LaunchpadsController> logger)
        {
            this.Pads = pads;
            this.Logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Pad[]>> Get()
        {
            return await Pads.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pad>> Get(string id)
        {
            Logger.Log(LogLevel.Information, "Someone's getting {0}", id);

            var pad = await Pads.Get(id);
            if (pad == null)
            {
                Logger.Log(LogLevel.Information, "..But they didn't get it.");
                return NotFound();
            }
            return pad;
        }

    }
}
