using _01_NewsProjectQuery.Contracts.News;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestNewsViewComponent : ViewComponent
    {
        private readonly INewsQuery _newsQuery;

        public LatestNewsViewComponent(INewsQuery newsQuery)
        {
            _newsQuery = newsQuery;
        }

        public IViewComponentResult Invoke()
        {
            var news = _newsQuery.LatestNews();
            return View(news);
        }
    }
}
