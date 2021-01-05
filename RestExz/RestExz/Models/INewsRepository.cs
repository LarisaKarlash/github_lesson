using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExz.Models
{
    public interface INewsRepository
    {
        List<News> GetNews();

        void AddNews(News news);

        void DeleteNews(int id);

        void UpdatePartNews(News news);
        void UpdateFullNews(News news);

    }
}
