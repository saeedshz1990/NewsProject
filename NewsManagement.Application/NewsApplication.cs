using _0_Framework.Application;
using _0_FrameWork.Application;
using NewsManagement.Application.Contracts.News;
using NewsManagement.Domain.NewsAgg;
using NewsManagement.Domain.NewsCategoryAgg;
using System.Collections.Generic;
using System.IO;

namespace NewsManagement.Application
{
    public class NewsApplication : INewsApplication
    {
        private readonly INewsRepository _newsRepository;
        private readonly INewsCategoryRepository _newsCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public NewsApplication(INewsRepository newsRepository ,
            INewsCategoryRepository newsCategoryRepository, IFileUploader fileUploader)
        {
            _newsRepository = newsRepository;
            _newsCategoryRepository = newsCategoryRepository;
            _fileUploader = fileUploader;   

        }

        public OperationResult Create(CreateNews command)
        {
            var operation = new OperationResult();

            if (_newsRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = _newsCategoryRepository.GetSlugBy(command.CategoryId);
            var path = $"{categorySlug}/{slug}";

            var pictureName = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            var news = new News(command.Title, command.ShortDescription, command.Description,
                pictureName, command.PictureAlt, command.PictureTitle, publishDate, slug,
                command.KeyWords, command.Metadescription, command.CanonicalAddress,
                command.CategoryId);

            _newsRepository.Create(news);
            _newsRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditNews command)
        {
            var operation = new OperationResult();
            var news = _newsRepository.GetWithCategory(command.Id);

            if (news == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            if (_newsRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            // var categorySlug = _articleCategoryRepository.GetSlugBy(command.categoryId);
            var path = $"{news.Category.Slug}/{slug}";
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            var pictureName = _fileUploader.Upload(command.Picture, path);
            news.Edit(command.Title, command.ShortDescription, command.Description, pictureName,
        command.PictureAlt, command.PictureTitle, publishDate, slug, command.KeyWords, command.Metadescription,
        command.CanonicalAddress, command.CategoryId);

            _newsRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditNews GetDetails(long id)
        {
            return _newsRepository.GetDetails(id);
        }

        public List<NewsViewModel> Search(NewsSearchModel searchModel)
        {
            return _newsRepository.Search(searchModel);
        }
    }
}
