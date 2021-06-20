using BadProject.Interfaces;
using System;
using System.Runtime.Caching;
using ThirdParty;

namespace Adv
{
    public class InternalAdvProviderCacheDecorator : IInternalAdvProvider
    {
        private readonly IInternalAdvProvider _internalAdvProvider;
        private readonly MemoryCache _cache;

        public InternalAdvProviderCacheDecorator(
            IInternalAdvProvider internalAdvProvider,
            MemoryCache cache)
        {
            _internalAdvProvider = internalAdvProvider;
            _cache = cache;
        }

        public Advertisement GetAdvertisement(string id)
        {
            var adv = _internalAdvProvider.GetAdvertisement(id);

            if (adv != null)
                _cache.Set($"AdvKey_{id}", adv, DateTimeOffset.Now.AddMinutes(5));

            return adv;
        }
    }
}