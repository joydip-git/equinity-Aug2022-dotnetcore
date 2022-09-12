using EquinityCommerceApp.Core.Entities;
using EquinityCommerceApp.Core.Repositories;
using EquinityCommerceApp.DataAccess.Repositories.Base;
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
        private readonly IUnitOfWork unitOfWork;

        public CategoriesController(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
        {
            this.loggerFactory = loggerFactory;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<IEnumerable<Category>>>> GetAllRecordsAsync()
        {
            var results = await unitOfWork.Category.GetAllAsync();
            if (results == null || results.Count == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.NotFound, Message = "No records found" });
            }
            else
            {
                return Ok(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.Found, Message = "Records found", Record = results.ToList<Category>() });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResponseModel<Category>>> GetRecordAsync(int? id = 0)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.NotFound, Message = "categroy id was not proper" });
            }
            var result = await unitOfWork.Category.GetByIdAsync(id.Value);
            if (result == null)
            {
                return NotFound(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.NotFound, Message = $"No record found with the give id: {id.Value}" });
            }
            else
            {
                return Ok(new ResponseModel<Category> { ResponseCode = HttpStatusCode.Found, Message = "Record found", Record = result });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<Category>>> Create([FromBody] Category category)
        {
            var result = await unitOfWork.Category.AddAsync(category);
            return CreatedAtAction("Create", new ResponseModel<Category> { ResponseCode = HttpStatusCode.Created, Message = "Category created successfully", Record = result });
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<Category>>> Edit([FromBody] Category category)
        {
            if (category.Id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.NotFound, Message = "Category does not have id" });
            }
            var found = await unitOfWork.Category.GetByIdAsync(category.Id);
            if (found == null)
            {
                return NotFound(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.NotFound, Message = "Category not found" });
            }
            var result = await unitOfWork.Category.UpdateAsync(category);
            return Ok(new ResponseModel<Category> { ResponseCode = HttpStatusCode.OK, Message = "Category updated successfully", Record = result });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResponseModel<Category>>> Delete(int? id = 0)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.NotFound, Message = "Category id not proper" });
            }
            var found = await unitOfWork.Category.GetByIdAsync(id.Value);
            if (found == null)
            {
                return NotFound(new ResponseModel<IEnumerable<Category>> { ResponseCode = HttpStatusCode.NotFound, Message = "Category not found" });
            }
            var result = await unitOfWork.Category.DeleteAsync(found);
            return Ok(new ResponseModel<Category> { ResponseCode = HttpStatusCode.OK, Message = "Category deleted successfully", Record = result });
        }
    }
}
