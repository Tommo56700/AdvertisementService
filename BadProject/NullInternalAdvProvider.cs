using BadProject.Interfaces;
using ThirdParty;

namespace Adv
{
    public class NullInternalAdvProvider : IInternalAdvProvider
    {
        public Advertisement GetAdvertisement(string id) => null;
    }
}