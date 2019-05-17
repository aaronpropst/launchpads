using System;
using System.Threading.Tasks;
using LaunchPads.Models;

namespace LaunchPads
{
    public interface IPadRepo
    {
        Task<Pad[]> GetAll();
        Task<Pad> Get(string id);
    }
}
