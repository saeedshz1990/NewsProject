using _0_FrameWork.Application;
using System.Collections.Generic;

namespace NewsManagement.Application.Contracts.News
{
    public interface INewsApplication
    {
        OperationResult Create(CreateNews command);
        OperationResult Edit(EditNews command);
        EditNews GetDetails(long id);
        List<NewsViewModel> Search(NewsSearchModel searchModel);
    }
}
