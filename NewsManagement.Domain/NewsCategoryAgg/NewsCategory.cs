using _0_FrameWork.Domain;
using NewsManagement.Domain.NewsAgg;
using System.Collections.Generic;

namespace NewsManagement.Domain.NewsCategoryAgg
{
    public class NewsCategory :EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Description { get; private set; }
        public int ShowOrder { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public List<News> News { get; private set; }

        public NewsCategory(string name, string picture, string pictureAlt, string pictureTitle,
            string description, int showOrder, string slug, string keywords, string metaDescription,
            string canonicalAddress)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle,
            string description, int showOrder, string slug, string keywords, string metaDescription,
            string canonicalAddress)
        {
            Name = name;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
        }
    }
}
