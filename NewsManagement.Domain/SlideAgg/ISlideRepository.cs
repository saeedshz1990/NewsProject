using _0_FrameWork.Domain;
using NewsManagement.Application.Contract.Slide;
using System.Collections.Generic;

namespace NewsManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long, Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
