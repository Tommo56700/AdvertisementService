using System;
using System.Runtime.Caching;
using Adv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirdParty;

namespace BadProjectTest
{
    [TestClass]
    public class CacheInternalAdvProviderTest
    {
        [TestMethod]
        public void GetAdvertisementReturnsNullWhenCacheDoesNotContainKey()
        {
            var cache = new MemoryCache("test");

            var sut = new CacheInternalAdvProvider(cache);
            const string id = "test";

            var result = sut.GetAdvertisement(id);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAdvertisementReturnsAdvWhenCacheDoesContainKey()
        {
            const string id = "test";

            var adv = new Advertisement { WebId = id, Name = $"Advertisement #{id}" };

            var cache = new MemoryCache("test");
            var sut = new CacheInternalAdvProvider(cache);

            cache.Set($"AdvKey_{id}", adv, DateTimeOffset.Now.AddMinutes(5));

            var result = sut.GetAdvertisement(id);

            Assert.AreEqual(adv, result);
        }
    }
}