using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VNGAssignment.Business.Interfaces;
using VNGAssignment.Contracts.Dtos.BookDto;

namespace VNGAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _bookService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]BookCreateDto model)
        {
            return Ok(await _bookService.AddAsync(model));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]BookUpdateDto model)
        {
            return Ok(await _bookService.UpdateAsync(id, model));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _bookService.DeleteAsync(id));
        }
    }
}
