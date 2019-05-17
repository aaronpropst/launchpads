using System;
using System.Threading.Tasks;
using LaunchPads;
using LaunchPads.Controllers;
using LaunchPads.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LaunchPadsTest
{
    public class ControllerTests
    {
        ILogger<LaunchpadsController> logger = new Mock<ILogger<LaunchpadsController>>().Object;


        //A mostly useless unit test that shows I know how to mock, etc.

        [Fact]
        public async Task GetRunsGetAll()
        {
            var m = new Mock<IPadRepo>();
            m.Setup(ir => ir.GetAll()).ReturnsAsync(new Pad[] { 
                new Pad
                {
                    Status="yep",
                    Id="yep",
                    Name="Ed"
                }
            });

            var lpc = new LaunchpadsController(m.Object, logger);

            var response = await lpc.Get();

            Assert.Equal("yep", response.Value[0].Id);
        }


        [Fact]
        public async Task GetShould404()
        {
            var m = new Mock<IPadRepo>();
            m.Setup(ir => ir.Get(It.IsAny<string>())).ReturnsAsync(default(Pad));

            var lpc = new LaunchpadsController(m.Object, logger);

            var response = await lpc.Get("garbage");
            Assert.IsType<NotFoundResult>(response.Result);
                
        }

    }
}
