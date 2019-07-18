using Microsoft.Extensions.Caching.Memory;

namespace PlinxPlanner.Caching.MemCache
{
    public interface ICustomMemCache
    {
        MemoryCache Cache { get; set; }
    }
}