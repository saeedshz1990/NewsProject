using _0_FrameWork.Domain;
using NewsManagement.Application.Contracts.NewsCategory;
using System.Collections.Generic;

namespace NewsManagement.Domain.NewsCategoryAgg
{
    public interface INewsCategoryRepository : IRepository<long , NewsCategory>
    {
        string GetSlugBy(long id);
        EditNewsCategory GetDetails(long id);
        List<NewsCategoryViewModel> GetNewsCategories();
        List<NewsCategoryViewModel> Search(NewsCategorySearchModel searchModel);
    }
}
