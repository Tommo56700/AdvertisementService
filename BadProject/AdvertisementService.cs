using BadProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using ThirdParty;

namespace Adv
{
    public class AdvertisementService
    {
        private static readonly MemoryCache Cache = new MemoryCache("");

        // This would ideally be done in IoC
        private static readonly IReadOnlyCollection<IInternalAdvProvider> AdvProviders = new IInternalAdvProvider[]
        {
            new CacheInternalAdvProvider(Cache),
            new InternalAdvProviderCacheDecorator(new NoSqlInternalAdvProvider(new Queue<DateTime>(), new NoSqlAdvProvider()), Cache),
            new InternalAdvProviderCacheDecorator(new SqlInternalAdvProvider(), Cache),
            new NullInternalAdvProvider()
        };

        public Advertisement GetAdvertisement(string id) =>
            AdvProviders.Select(ap => ap.GetAdvertisement(id)).FirstOrDefault(a => a != null);
    }
}