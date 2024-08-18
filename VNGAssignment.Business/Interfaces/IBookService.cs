using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.Contracts.Common;
using VNGAssignment.Contracts.Dtos.BookDto;

namespace VNGAssignment.Business.Interfaces
{
    public interface IBookService
    {
        Task<ResponseResult> GetAllAsync();
        Task<ResponseResult> GetByIdAsync(int id);
        Task<ResponseResult> AddAsync(BookCreateDto model);
        Task<ResponseResult> UpdateAsync(int id, BookUpdateDto model);
        Task<ResponseResult> DeleteAsync(int id);
    }
}
