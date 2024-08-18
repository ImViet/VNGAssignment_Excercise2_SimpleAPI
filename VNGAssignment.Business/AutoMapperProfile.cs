using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.Contracts.Dtos.BookDto;
using VNGAssignment.DataAccessor.Entities;

namespace VNGAssignment.Business
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }
        private void FromPresentationLayer()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();
        }
        private void FromDataAccessorLayer()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
