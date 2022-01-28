using _0_FrameWork.Application;
using System.Collections.Generic;

namespace NewsManagement.Application.Contracts.NewsCategory
{
    public interface INewsCategoryApplication
    {
        OperationResult Edit(EditNewsCategory command);
        OperationResult Create(CreateNewsCategory command);
        EditNewsCategory GetDetails(long id);
        List<NewsCategoryViewModel> GetNewsCategories();
        List<NewsCategoryViewModel> Search(NewsCategorySearchModel searchModel);
    }
}
