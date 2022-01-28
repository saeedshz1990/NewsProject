﻿using _0_FrameWork.Domain;
using NewsManagement.Domain.NewsCategoryAgg;
using System;

namespace NewsManagement.Domain.NewsAgg
{
    public class News : EntityBase
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string Metadescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long CategoryId { get; private set; }
        public NewsCategory Category { get; private set; }

        public News(string title, string shortDescription, string description, string picture,
     string pictureAlt, string pictureTitle, DateTime publishDate, string slug, string keyWords,
     string metadescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            KeyWords = keyWords;
            Metadescription = metadescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;

        }

        public void Edit(string title, string shortDescription, string description, string picture,
       string pictureAlt, string pictureTitle, DateTime publishDate, string slug, string keyWords,
       string metadescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            KeyWords = keyWords;
            Metadescription = metadescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;

        }
    }
}
