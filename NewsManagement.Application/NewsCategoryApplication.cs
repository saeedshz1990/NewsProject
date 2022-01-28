using _0_Framework.Application;
using _0_FrameWork.Application;
using NewsManagement.Application.Contracts.NewsCategory;
using NewsManagement.Domain.NewsAgg;
using NewsManagement.Domain.NewsCategoryAgg;
using System.Collections.Generic;

namespace NewsManagement.Application
{
    public class NewsCategoryApplication : INewsCategoryApplication
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;
        private readonly INewsRepository _newsRepository;
        private readonly IFileUploader _fileUploader;

        public NewsCategoryApplication(INewsCategoryRepository newsCategoryRepository ,
           INewsRepository newsRepository , IFileUploader fileUploader)
        {
            _newsCategoryRepository = newsCategoryRepository;
            _newsRepository = newsRepository;
            _fileUploader = fileUploader;

        }

        public OperationResult Create(CreateNewsCategory command)
        {
            var operation = new OperationResult();
            if (_newsCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            var newsCategory = new NewsCategory(command.Name,pictureName,command.PictureAlt,
                command.PictureTitle,command.Description, command.ShowOrder,slug,
                command.Keywords, command.MetaDescription,command.CanonicalAddress);

            _newsCategoryRepository.Create(newsCategory);
            _newsCategoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditNewsCategory command)
        {
            var operation = new OperationResult();
            var newsCategories = _newsCategoryRepository.Get(command.Id);

            if(newsCategories == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_newsCategoryRepository.Exists(x => x.Name == command.Name || x.Id==command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            newsCategories.Edit(command.Name, pictureName, command.PictureAlt,
                command.PictureTitle, command.Description, command.ShowOrder, slug,
                command.Keywords, command.MetaDescription, command.CanonicalAddress);

            _newsCategoryRepository.SaveChanges();

            return operation.Succedded();

        }

        public EditNewsCategory GetDetails(long id)
        {
            return _newsCategoryRepository.GetDetails(id);
        }

        public List<NewsCategoryViewModel> GetNewsCategories()
        {
            return _newsCategoryRepository.GetNewsCategories();
        }

        public List<NewsCategoryViewModel> Search(NewsCategorySearchModel searchModel)
        {
            return _newsCategoryRepository.Search(searchModel);
        }
    }
}
