
namespace NextGenSoftware.OASIS.API.ONODE.WebAPI.Models.Avatar
{
    public class LinkProviderKeyToAvatarParams
    {
        public string AvatarID { get; set; }
        public string AvatarUsername { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderTypeToLinkTo { get; set; }
        public string ProviderTypeToLoadAvatarFrom { get; set; }
    }
}