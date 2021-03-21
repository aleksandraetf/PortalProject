using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NewsPortal.BusinessLogic.News;
using NewsPortal.BusinessLogic.News.Model;
using NewsPortal.BusinessLogic.User.Model;

namespace NewsPortalApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly INewsService _newsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NewsController(INewsService newsService,IHttpContextAccessor httpContextAccessor)
        {
            _newsService = newsService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/News
        [Route("all")]
        [HttpGet]
        public ActionResult<IEnumerable<NewsViewModel>> Get(string search="",int pageNumber=1,int pageSize=250)
        {
            try
            {
              return _newsService.GetAll(search,pageNumber,pageSize);
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<NewsViewModel>> GetByUser(string search = "", int pageNumber = 1, int pageSize = 250)
        {
            try
            {
                var user = (UserModel)_httpContextAccessor.HttpContext.Items["User"];
                return _newsService.GetByUser(search, pageNumber, pageSize,user);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }


        // POST: api/News
        [Authorize]
        [HttpPost]
        public ActionResult Post(NewsCreateModel model)
        {
            try
            {
                var user = (UserModel)_httpContextAccessor.HttpContext.Items["User"];

                _newsService.Add(model,user);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
           
        }


        // PUT: api/News/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Put(int id,NewsEditModel model)
        {
            try
            {
                var user = (UserModel)_httpContextAccessor.HttpContext.Items["User"];
                var newsModel = _newsService.GetById(id);

                if (newsModel == null ) return NotFound();
                if (newsModel.UserId != user.Id) return Unauthorized();

                model.Id = id;
                _newsService.Edit(model);
                return Ok();
            }
            catch(Exception e)
            {
                
                return BadRequest();
            }
         
        }
    }
}
