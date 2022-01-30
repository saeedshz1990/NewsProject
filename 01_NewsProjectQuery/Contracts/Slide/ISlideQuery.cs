using System.Collections.Generic;

namespace _01_NewsProjectQuery.Contracts.Slide
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlides();
    }
}
