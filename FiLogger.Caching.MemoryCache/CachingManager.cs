using Microsoft.Extensions.Caching.Memory;
using System;

namespace PlinxPlanner.Caching.MemCache
{
    public class CachingManager : ICachingManager
    {
        private readonly IMemoryCache _cache;

        private TimeSpan _timeSpan = TimeSpan.FromHours(1);
        private bool _useRollingInterval = false;
        private int _entrySize = 1;

        public CachingManager(ICustomMemCache cache)
        {
            _cache = cache.Cache;           
        }


        #region Public methods
        /// <summary>
        /// Attempt to get the object from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetCache<T>(CacheKeys key) => (T)_cache.Get(key.ToString());

        /// <summary>
        /// Overflow method to allow cache to be retrieved via a string key.
        /// Should be used if the key is dynamic. For a static key use the Cachekeys ENUM to ensure integrity. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetCache<T>(string key) => (T)_cache.Get(key);

        /// <summary>
        /// Set cache in memory and return original object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="cacheKey"></param>
        /// <param name="timeSpan"></param>
        /// <param name="useRollingInterval"></param>
        /// <returns></returns>
        public T SetCache<T>(T obj, CacheKeys cacheKey, 
            TimeSpan? timeSpan = null, 
            bool useRollingInterval = false, 
            int entrySize = 1) => ActionSetCache(obj, timeSpan, useRollingInterval, cacheKey.ToString());

        /// <summary>
        /// Overflow method to allow cache to be set via a string key.
        /// Should be used if the key is dynamic. For a static key use the Cachekeys ENUM to ensure integrity. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="cacheKey"></param>
        /// <param name="timeSpan"></param>
        /// <param name="useRollingInterval"></param>
        /// <returns></returns>
        public T SetCache<T>(T obj, 
            string key, TimeSpan? timeSpan = null, 
            bool useRollingInterval = false, 
            int entrySize = 1) => ActionSetCache(obj, timeSpan, useRollingInterval, key);

        /// <summary>
        /// Remove cache on requested key
        /// </summary>
        /// <param name="key"></param>
        public void RemoveCache(CacheKeys key) => _cache.Remove(key.ToString());

        /// <summary>
        /// Overflow to Remove cache on requested string key 
        /// </summary>
        /// <param name="key"></param>
        public void RemoveCache(string key) => _cache.Remove(key);

        /// <summary>
        /// Clear cache on all keys
        /// </summary>
        public void ClearAllCache() {
            foreach (var key in Enum.GetNames(typeof(CacheKeys)))
            {
                _cache.Remove(key);
            }
        }
        #endregion


        #region Private Helper methods
        /// <summary>
        /// Set the caching options
        /// </summary>
        /// <returns></returns>
        private MemoryCacheEntryOptions GetCachingOption()
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(_entrySize);
            if (_useRollingInterval) cacheEntryOptions.SetSlidingExpiration(_timeSpan); 
            else cacheEntryOptions.SetAbsoluteExpiration(_timeSpan);

            return cacheEntryOptions;
        }

        /// <summary>
        /// Action setting the cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="timeSpan"></param>
        /// <param name="useRollingInterval"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private T ActionSetCache<T>(T obj, TimeSpan? timeSpan, bool useRollingInterval, string key, int entrySize = 1)
        {
            if (timeSpan != null) _timeSpan = (TimeSpan)timeSpan;
            _useRollingInterval = useRollingInterval;
            _entrySize = entrySize;
            _cache.Set(key, obj, GetCachingOption());
            return obj;
        }
        #endregion
    }
}

