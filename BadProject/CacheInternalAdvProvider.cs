using BadProject.Interfaces;
using System.Runtime.Caching;
using ThirdParty;

namespace Adv
{
    public class CacheInternalAdvProvider : IInternalAdvProvider
    {
        private readonly MemoryCache _cache;

        public CacheInternalAdvProvider(MemoryCache cache)
        {
            _cache = cache;
        }

        public Advertisement GetAdvertisement(string id) =>
            (Advertisement)_cache.Get($"AdvKey_{id}");
    }
}