using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExz.Models;
using Microsoft.AspNetCore.Http;

namespace RestExz.Controllers
{
    //[Route("api/News/v1")]
    [Route("News/v1")]
    [ApiController] // указывает, что это методы Rest
    public class NewsController : ControllerBase
    {
        private INewsRepository _newsRepository { get; }

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }


        //[HttpGet("News/{pv1}")]
        [HttpGet]
        public IActionResult Index([FromQuery]int id, [FromQuery]string authorName, [FromQuery] bool isFake)
        {
            try
            {
                if (id != 0 && authorName != null && isFake)
                    return Ok(_newsRepository.GetNews().Where(x => x.Id == id && x.AuthorName == authorName && x.IsFake == isFake));

                else if (id != 0)
                    return Ok(_newsRepository.GetNews().Where(x => x.Id == id));

                else if (authorName != null)
                    return Ok(_newsRepository.GetNews().Where(x => x.AuthorName == authorName));

                else if (isFake)
                    return Ok(_newsRepository.GetNews().Where(x => x.IsFake == isFake));
               
                else
                    return Ok(_newsRepository.GetNews().ToList());
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //Добавление новости
        //[HttpPost("MyNews/{pv1}")]
        [HttpPost]
        public IActionResult AddNews(News news) //объект получаем из тела запроса
        {
            _newsRepository.AddNews(news);
            return Ok();
        }


        //Указываем fromroute
        //[HttpDelete("News/{newsId}")]
        //public IActionResult DeleteNews([FromRoute] int newsId)

        ////Указываем fromquery
        //[HttpDelete("News/{newsId}")]
        //public IActionResult DeleteNews([FromQuery] int newsId)

        //Указываем fromheader
        //[HttpDelete("News/{newsId}")]
        //public IActionResult DeleteNews([FromHeader] int newsId)


        //[HttpDelete("News/{pv1}")]
        [HttpDelete]
        public IActionResult DeleteNews(int newsId)
        {
            try
            {
                _newsRepository.DeleteNews(newsId);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /*
         * Частичное изменения записи коллекции News
         */
        // [HttpPut("News/{pv1}")]
        [HttpPatch]
        public IActionResult UpdatePartNews(News news)
        {
            try
            {
                _newsRepository.UpdatePartNews(news);//, text);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /*
         * Полная замена News
         */
        //[HttpPost("News/{pv1}")]
        [HttpPut]
        public IActionResult UpdateFullNews(News news)
        {
            try
            {
                _newsRepository.UpdateFullNews(news);
               
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}