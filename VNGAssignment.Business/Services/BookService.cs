using AutoMapper;
using VNGAssignment.Business.Interfaces;
using VNGAssignment.Contracts.Common;
using VNGAssignment.Contracts.Dtos.BookDto;
using VNGAssignment.Contracts.Exceptions;
using VNGAssignment.DataAccessor.Data;
using VNGAssignment.DataAccessor.Entities;
using VNGAssignment.Contracts.Enums;
namespace VNGAssignment.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBaseRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ResponseResult> AddAsync(BookCreateDto model)
        {
            var newBook = _mapper.Map<Book>(model);
            var result =  await _bookRepository.AddAsync(newBook);
            return new ResponseResult(ResultCode.Success, "Success", result);            
        }

        public async Task<ResponseResult> DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is null)
            {
                throw new BadRequestException("Book does not exist.");
            }
            var result = await _bookRepository.DeleteAsync(book);
            return new ResponseResult(ResultCode.Success, "Success", result);
        }

        public async Task<ResponseResult> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            var result = _mapper.Map<List<BookDto>>(books);
            return new ResponseResult(ResultCode.Success, "Success", result);
        }

        public async Task<ResponseResult> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if(book is null)
            {
                throw new NotFoundException("BookId does not exist.");
            }    
            var result = _mapper.Map<BookDto>(book);
            return new ResponseResult(ResultCode.Success, "Success", result);
        }

        public async Task<ResponseResult> UpdateAsync(int id,BookUpdateDto model)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is null)
            {
                throw new BadRequestException("Book does not exist.");
            }
            _mapper.Map(model, book);
            var result = await _bookRepository.UpdateAsync(book);
            return new ResponseResult(ResultCode.Success, "Success", result);
        }
    }
}
