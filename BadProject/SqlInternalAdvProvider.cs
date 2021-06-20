using BadProject.Interfaces;
using ThirdParty;

namespace Adv
{
    public class SqlInternalAdvProvider : IInternalAdvProvider
    {
        public Advertisement GetAdvertisement(string id) => SQLAdvProvider.GetAdv(id);
    }
}