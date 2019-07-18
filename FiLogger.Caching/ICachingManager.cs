using System;

namespace PlinxPlanner.Caching
{
    public interface ICachingManager
    {
        T GetCache<T>(CacheKeys key);
        T GetCache<T>(string key);

        T SetCache<T>(T obj, CacheKeys key, TimeSpan? timeSpan = null, bool useRollingInterval = false, int entrySize = 1);
        T SetCache<T>(T obj, string key, TimeSpan? timeSpan = null, bool useRollingInterval = false, int entrySize = 1);

        void RemoveCache(CacheKeys key);
        void ClearAllCache();
    }
}