using _0_FrameWork.Domain;
using NewsManagement.Application.Contracts.News;
using System.Collections.Generic;

namespace NewsManagement.Domain.NewsAgg
{
    public interface INewsRepository :IRepository<long , News>
    {
        EditNews GetDetails(long id);
        News GetWithCategory(long id);
        List<NewsViewModel> Search(NewsSearchModel searchModel);
    }
}
