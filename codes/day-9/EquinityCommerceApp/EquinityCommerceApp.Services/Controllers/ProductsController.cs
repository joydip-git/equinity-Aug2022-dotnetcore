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
    public class ProductsController : ControllerBase
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly IUnitOfWork unitOfWork;

        public ProductsController(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
        {
            this.loggerFactory = loggerFactory;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<IEnumerable<Product>>>> GetAllRecordsAsync()
        {
            var results = await unitOfWork.Product.GetAllAsync("Category,CoverType");
            if (results == null || results.Count == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "No records found" });
            }
            else
            {
                return Ok(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.Found, Message = "Records found", Record = results.ToList<Product>() });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResponseModel<Product>>> GetRecordAsync(int? id = 0)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "categroy id was not proper" });
            }
            var result = await unitOfWork.Product.GetByIdAsync(id.Value, "Category,CoverType");
            if (result == null)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = $"No record found with the give id: {id.Value}" });
            }
            else
            {
                return Ok(new ResponseModel<Product> { ResponseCode = HttpStatusCode.Found, Message = "Record found", Record = result });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<Product>>> Create([FromBody] Product product)
        {
            var result = await unitOfWork.Product.AddAsync(product);
            return CreatedAtAction("Create", new ResponseModel<Product> { ResponseCode = HttpStatusCode.Created, Message = "Product created successfully", Record = result });
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<Product>>> Edit([FromBody] Product product)
        {
            if (product.Id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "Product does not have id" });
            }
            var found = await unitOfWork.Product.GetByIdAsync(product.Id);
            if (found == null)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "Product not found" });
            }
            var result = await unitOfWork.Product.UpdateAsync(product);
            return Ok(new ResponseModel<Product> { ResponseCode = HttpStatusCode.OK, Message = "Product updated successfully", Record = result });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResponseModel<Product>>> Delete(int? id = 0)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "Product id not proper" });
            }
            var found = await unitOfWork.Product.GetByIdAsync(id.Value);
            if (found == null)
            {
                return NotFound(new ResponseModel<IEnumerable<Product>> { ResponseCode = HttpStatusCode.NotFound, Message = "Product not found" });
            }
            var result = await unitOfWork.Product.DeleteAsync(found);
            return Ok(new ResponseModel<Product> { ResponseCode = HttpStatusCode.OK, Message = "Product deleted successfully", Record = result });
        }
    }
}
