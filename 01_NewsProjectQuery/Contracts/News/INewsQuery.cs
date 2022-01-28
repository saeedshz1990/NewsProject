using System.Collections.Generic;

namespace _01_NewsProjectQuery.Contracts.News
{
    public interface INewsQuery
    {
        List<NewsQueryModel> LatestNews();
        NewsQueryModel GetNewsDetails(string slug);

    }
}
