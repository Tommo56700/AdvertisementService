using System.Runtime.Caching;
using Adv;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadProjectTest
{
    [TestClass]
    public class InternalAdvProviderCacheDecoratorTest
    {
        [TestMethod]
        public void AdvNotAddedToCacheWhenNull()
        {
            var cache = new MemoryCache("test");

            var sut = new InternalAdvProviderCacheDecorator(new NullInternalAdvProvider(), cache);
            const string id = "test";

            var adv = sut.GetAdvertisement(id);

            Assert.IsTrue(cache.GetCount() == 0);
        }

        [TestMethod]
        public void AdvAddedToCache()
        {
            var cache = new MemoryCache("test");

            var sut = new InternalAdvProviderCacheDecorator(new SqlInternalAdvProvider(), cache);
            const string id = "test";

            var adv = sut.GetAdvertisement(id);

            Assert.IsTrue(cache.GetCount() == 1);
        }
    }
}