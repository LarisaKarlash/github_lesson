using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExz.Models
{
    public class MockNewsRepository : INewsRepository 
    {
        
        private List<News> _news = new List<News>
        {
            new News { Id = 0, Title = "Humanity finally colonized the Mercury!!", Text = "", AuthorName = "Jeremy Clarkson", IsFake = true},
            new News { Id = 1, Title = "Increase your lifespan by 10 years, every morning you need...", Text = "", AuthorName = "Svetlana Sokolova", IsFake = true},
            new News { Id = 2, Title = "Scientists estimed the time of the vaccine invension: it is a summer of 2021", Text = "", AuthorName = "John Jones", IsFake = false},
            new News { Id = 3, Title = "Ukraine reduces the cost of its obligations!", Text = "", AuthorName = "Cerol Denvers", IsFake = false},
            new News { Id = 4, Title = "A species were discovered in Africa: it is blue legless cat", Text = "", AuthorName = "Jimmy Felon", IsFake = true}
        };

        public List<News> GetNews()
        {
            return (_news);
        }
        public void AddNews(News news)
        {
            //добавлять новости только с уникальным Id
            int kol = _news.Count(x => x.Id == news.Id);

            if (kol == 0)
               _news.Add(news);
        }

        public void DeleteNews(int id)
        {
            var news = _news.Single(x=>x.Id==id);
            _news.Remove(news);
        }

        // Частичная замена News
        public void UpdatePartNews(News news)
        {
            var news_m= _news.Where(x => x.Id == news.Id);

            // заменяем Text, AuthorName по всем Id = входящему
            foreach (var news_i in news_m)
            {
                if (news_i.Text != news.Text)
                    news_i.Text = news.Text;

                if (news_i.AuthorName != news.AuthorName)
                    news_i.AuthorName = news.AuthorName;
            }
        }

        // Полная замена News
        public void UpdateFullNews(News news)
        {
            var news_m = _news.Where(x => x.Id == news.Id);

            foreach (var news_i in news_m)
            {
                if (news_i.Title != news.Title)
                    news_i.Title = news.Title;

                if (news_i.Text != news.Text)
                    news_i.Text = news.Text;

                if (news_i.AuthorName != news.AuthorName)
                    news_i.AuthorName = news.AuthorName;

                if (news_i.IsFake != news.IsFake)
                    news_i.IsFake = news.IsFake;
               
            }
        }

    }
}
