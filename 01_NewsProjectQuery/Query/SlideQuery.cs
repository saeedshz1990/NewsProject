using _01_NewsProjectQuery.Contracts.Slide;
using NewsManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_NewsProjectQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly NewsManagementContext _context;

        public SlideQuery(NewsManagementContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _context.Slides
                .Where(x => x.IsRemoved == false)
                .Select(x => new SlideQueryModel
                {
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    BtnText = x.BtnText,
                    Heading = x.Heading,
                    Link = x.Link,
                    Text = x.Text,
                    Title = x.Title
                }).ToList();
        }
    }
}
