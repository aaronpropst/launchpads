using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LaunchPads.Models;

namespace LaunchPads
{
    public class APIPadRepo : IPadRepo
    {
        public APIPadRepo(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }
        private readonly string apiUrl;

        private SpaceXPad[] cache;

        public async Task<Pad> Get(string id)
        {
            await fetch();

            return cache.SingleOrDefault(x => x.Id == id).ToPad();
        }


        public async Task<Pad[]> GetAll()
        {
            await fetch();

            return cache.Select(x => x.ToPad()).ToArray();
        }

        async Task fetch()
        {
            if (cache == null)
            {
                var client = new HttpClient();
                var resp = await client.GetAsync(apiUrl);

                cache = await resp.Content.ReadAsAsync<SpaceXPad[]>();

            }
            //TODO: deal with api call failure, retries, backoffs, etc.

        }
    }
}
