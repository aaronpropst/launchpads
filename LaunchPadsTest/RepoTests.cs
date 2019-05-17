using System;
using System.Threading.Tasks;
using LaunchPads;
using LaunchPads.Controllers;
using LaunchPads.Models;
using Moq;
using Xunit;


namespace LaunchPadsTest
{
    public class RepoTests
    {

        [Fact]
        public async Task GetByIdCanFilter()
        {
            var fakeSpaceXPayload = new SpaceXPad[]{
                new SpaceXPad
                {
                    Id = "fsp1"
                },
                new SpaceXPad
                {
                    Id = "fsp2"
                },
                new SpaceXPad
                {
                    Id = "fsp3"
                },
            };

            var ar = new APIPadRepo(fakeSpaceXPayload);

            Assert.Equal(
                fakeSpaceXPayload[2].Id,
                (await ar.Get(fakeSpaceXPayload[2].Id)).Id
                );


            var blah = (await ar.Get("garbage"));
            Assert.True(blah == null);

        }


        [Fact]
        public async Task EmptyListsDoNoHarm()
        {
            var fakeSpaceXPayload = new SpaceXPad[]{};

            var ar = new APIPadRepo(fakeSpaceXPayload);

            
            var blah = (await ar.GetAll());

            Assert.True(blah.Length == 0);


            var blah2 = (await ar.Get("garbage"));
            Assert.True(blah2 == null);

        }
    }
}
