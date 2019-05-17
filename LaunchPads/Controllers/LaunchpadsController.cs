using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LaunchPads.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LaunchPads.Controllers
{


    [Route("api/launchpads")]
    [ApiController]
    public class LaunchpadsController : ControllerBase
    {
        IPadRepo Pads;

        public LaunchpadsController(IPadRepo Pads)
        {
            this.Pads = Pads;
        }

        [HttpGet]
        public async Task<ActionResult<Pad[]>> Get()
        {
            return await Pads.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pad>> Get(string id)
        {
            return await Pads.Get(id);
        }

    }
}
