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
        //This is a kludge to allow backing this repo with test data.  
        //I'd probably replace it with better injection or something, inject
        //the fetcher into the repo, etc.
        public APIPadRepo(SpaceXPad[] testData)
        {
            cache = testData;
        }

        private readonly string apiUrl;

        private SpaceXPad[] cache; //TODO: periodically expire.

        public async Task<Pad> Get(string id)
        {
            await fetch();

            var xpad = cache.SingleOrDefault(x => x.Id == id);

            if (xpad == null) return null;

            return xpad.ToPad();
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
