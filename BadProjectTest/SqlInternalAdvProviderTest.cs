using Adv;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadProjectTest
{
    [TestClass]
    public class SqlInternalAdvProviderTest
    {
        [TestMethod]
        public void GetAdvertisementReturnsAdvWithCorrectId()
        {
            var sut = new SqlInternalAdvProvider();
            const string id = "test";

            var result = sut.GetAdvertisement(id);

            Assert.AreEqual(id, result.WebId);
        }
    }
}