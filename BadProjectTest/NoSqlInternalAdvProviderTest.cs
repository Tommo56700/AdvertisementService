using Adv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ThirdParty;

namespace BadProjectTest
{
    [TestClass]
    public class NoSqlInternalAdvProviderTest
    {
        [TestMethod]
        public void GetAdvertisementReturnsNullWhen10Errors()
        {
            var errorQueue = new Queue<DateTime>();

            for (var i = 0; i < 10; i++)
            {
                errorQueue.Enqueue(DateTime.Now);
            }

            var sut = new NoSqlInternalAdvProvider(errorQueue, new NoSqlAdvProvider());
            const string id = "test";

            var result = sut.GetAdvertisement(id);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAdvertisementReturnsAdvWhenLessThan10Errors()
        {
            var errorQueue = new Queue<DateTime>();

            for (var i = 0; i < 9; i++)
            {
                errorQueue.Enqueue(DateTime.Now);
            }

            var sut = new NoSqlInternalAdvProvider(errorQueue, new NoSqlAdvProvider());
            const string id = "test";

            var result = sut.GetAdvertisement(id);

            Assert.AreEqual(id, result.WebId);
        }

        [TestMethod]
        public void GetAdvertisementRemovesOldErrors()
        {
            var errorQueue = new Queue<DateTime>();

            for (var i = 0; i < 9; i++)
            {
                errorQueue.Enqueue(DateTime.Now.AddHours(-1));
            }

            for (var i = 0; i < 9; i++)
            {
                errorQueue.Enqueue(DateTime.Now);
            }

            var sut = new NoSqlInternalAdvProvider(errorQueue, new NoSqlAdvProvider());
            const string id = "test";

            var result = sut.GetAdvertisement(id);

            Assert.AreEqual(id, result.WebId);
        }
    }
}