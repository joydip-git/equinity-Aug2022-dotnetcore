using EquinityCommerceApp.Core.Entities;
using EquinityCommerceApp.Core.Repositories;
using EquinityCommerceApp.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EquinityCommerceApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly ICategoryRepository repository;

        public CategoriesController(ILoggerFactory loggerFactory, ICategoryRepository repository)
        {
            this.loggerFactory = loggerFactory;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<IEnumerable<Category>>>> GetAllRecordsAsync()
        {
            var results = await repository.GetAllAsync();
            if (results == null || results.Count == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.NotFound, Message = "No records found" });
            }
            else
            {
                return Ok(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.Found, Message = "Records found", Data = results.ToList<Category>() });
            }
        }
    }
}
