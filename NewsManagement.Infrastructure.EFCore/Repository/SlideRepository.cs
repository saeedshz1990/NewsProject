using _0_Framework.Application;
using _0_FrameWork.Infrasutructure;
using NewsManagement.Application.Contract.Slide;
using NewsManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly NewsManagementContext _context;

        public SlideRepository(NewsManagementContext context): base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x=> new EditSlide 
            {
                Id = id,
                Heading = x.Heading,
                Text = x.Text,
                Title = x.Title,
                Link = x.Link,
                BtnText = x.BtnText,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x=> new SlideViewModel 
            {
                Id = x.Id,
                Heading = x.Heading,
                Title = x.Title,    
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,
            }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
