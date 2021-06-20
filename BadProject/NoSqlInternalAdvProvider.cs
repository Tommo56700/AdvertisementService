using BadProject.Interfaces;
using BadProject.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ThirdParty;

namespace Adv
{
    public class NoSqlInternalAdvProvider : IInternalAdvProvider
    {
        private readonly Queue<DateTime> _errorQueue;
        private readonly NoSqlAdvProvider _noSqlAdvProvider;

        public NoSqlInternalAdvProvider(Queue<DateTime> errorQueue, NoSqlAdvProvider noSqlAdvProvider)
        {
            _errorQueue = errorQueue;
            _noSqlAdvProvider = noSqlAdvProvider;
        }

        public Advertisement GetAdvertisement(string id)
        {
            var lastHour = DateTime.Now.AddHours(-1);
            while (_errorQueue.Any() && _errorQueue.Peek() < lastHour) _errorQueue.Dequeue();

            return _errorQueue.Count < 10
                ? Retry.Do(() => _noSqlAdvProvider.GetAdv(id), _errorQueue, 1000, int.Parse(ConfigurationManager.AppSettings["RetryCount"]))
                : null;
        }
    }
}