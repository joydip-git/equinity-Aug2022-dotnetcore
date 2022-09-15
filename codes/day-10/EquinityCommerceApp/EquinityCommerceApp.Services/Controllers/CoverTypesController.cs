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
    public class CoverTypesController : ControllerBase
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly IUnitOfWork unitOfWork;

        public CoverTypesController(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
        {
            this.loggerFactory = loggerFactory;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<IEnumerable<CoverType>>>> GetAllRecordsAsync()
        {
            var results = await unitOfWork.CoverType.GetAllAsync();
            if (results == null || results.Count == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<CoverType>> { ResponseCode = HttpStatusCode.NotFound, Message = "No records found" });
            }
            else
            {
                return Ok(new ResponseModel<IEnumerable<CoverType>> { ResponseCode = HttpStatusCode.Found, Message = "Records found", Record = results.ToList<CoverType>() });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResponseModel<CoverType>>> GetRecordAsync(int? id = 0)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<CoverType>> { ResponseCode = HttpStatusCode.NotFound, Message = "cover type id was not proper" });
            }
            var result = await unitOfWork.CoverType.GetByIdAsync(id.Value);
            if (result == null)
            {
                return NotFound(new ResponseModel<IEnumerable<CoverType>> { ResponseCode = HttpStatusCode.NotFound, Message = $"No record found with the give id: {id.Value}" });
            }
            else
            {
                return Ok(new ResponseModel<CoverType> { ResponseCode = HttpStatusCode.Found, Message = "Record found", Record = result });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<CoverType>>> Create([FromBody] CoverType coverType)
        {
            var result = await unitOfWork.CoverType.AddAsync(coverType);
            return CreatedAtAction("Create", new ResponseModel<CoverType> { ResponseCode = HttpStatusCode.Created, Message = "Cover Type created successfully", Record = result });
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<CoverType>>> Edit([FromBody] CoverType coverType)
        {
            if (coverType.Id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<CoverType>> { ResponseCode = HttpStatusCode.NotFound, Message = "CoverType does not have id" });
            }
            var found = await unitOfWork.CoverType.GetByIdAsync(coverType.Id);
            if (found == null)
            {
                return NotFound(new ResponseModel<IEnumerable<CoverType>> { ResponseCode = HttpStatusCode.NotFound, Message = "CoverType not found" });
            }
            var result = await unitOfWork.CoverType.UpdateAsync(coverType);
            return Ok(new ResponseModel<CoverType> { ResponseCode = HttpStatusCode.OK, Message = "CoverType updated successfully", Record = result });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResponseModel<CoverType>>> Delete(int? id = 0)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound(new ResponseModel<IEnumerable<CoverType>> { ResponseCode = HttpStatusCode.NotFound, Message = "CoverType id not proper" });
            }
            var found = await unitOfWork.CoverType.GetByIdAsync(id.Value);
            if (found == null)
            {
                return NotFound(new ResponseModel<IEnumerable<CoverType>> { ResponseCode = HttpStatusCode.NotFound, Message = "CoverType not found" });
            }
            var result = await unitOfWork.CoverType.DeleteAsync(found);
            return Ok(new ResponseModel<CoverType> { ResponseCode = HttpStatusCode.OK, Message = "CoverType deleted successfully", Record = result });
        }
    }
}
