using Adv;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadProjectTest
{
    [TestClass]
    public class NullInternalAdvProviderTest
    {
        [TestMethod]
        public void GetAdvertisementReturnsNull()
        {
            var sut = new NullInternalAdvProvider();

            var result = sut.GetAdvertisement("test");

            Assert.IsNull(result);
        }
    }
}
