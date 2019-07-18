using Microsoft.Extensions.Caching.Memory;

namespace PlinxPlanner.Caching.MemCache
{
    public class FiLoggerMemCache : ICustomMemCache
    {
        public MemoryCache Cache { get; set; }
        public FiLoggerMemCache(int sizeLimit = 1000)
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = sizeLimit          
            });
        }
    }
}
