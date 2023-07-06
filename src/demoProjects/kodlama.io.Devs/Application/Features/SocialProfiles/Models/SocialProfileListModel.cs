using Application.Features.SocialProfiles.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SocialProfiles.Models
{
    public class SocialProfileListModel : BasePageableModel
    {
        public IList<SocialProfileListDto> Items { get; set; }
    }
}