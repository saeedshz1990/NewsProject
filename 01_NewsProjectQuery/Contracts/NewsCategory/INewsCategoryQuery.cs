using System.Collections.Generic;

namespace _01_NewsProjectQuery.Contracts.NewsCategory
{
    public interface INewsCategoryQuery
    {
        NewsCategoryQueryModel GetNewsCategory(string slug);
        List<NewsCategoryQueryModel> GetNewsCategories();
    }
}
