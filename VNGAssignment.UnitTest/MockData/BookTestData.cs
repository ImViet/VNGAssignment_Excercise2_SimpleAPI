using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.Contracts.Dtos.BookDto;
using VNGAssignment.DataAccessor.Entities;

namespace VNGAssignment.UnitTest.MockData
{
    public static class BookTestData
    {
        private static List<BookDto> books = new List<BookDto>()
        {
            new BookDto() { Id = 1, Title = "Tôi thấy hoa vàng trên cỏ xanh", Author = "Nguyễn Nhật Ánh", PublishedYear = 2010 },
            new BookDto() { Id = 2, Title = "Đất rừng Phương Nam", Author = "Đoàn Giỏi", PublishedYear = 2014 },
            new BookDto() { Id = 3, Title = "Sổ đỏ", Author = "Vũ Trọng Phụng", PublishedYear = 2012 }
        };
        public static List<BookDto> GetAllBooks()
        {
            return books;
        }
        public static BookDto GetBookById(int id)
        {
            return books.Find(b => b.Id == id);
        }

        public static BookCreateDto GetNewBook()
        {
            return new BookCreateDto
            {
                Title = "Sách mới",
                Author = "Tác giả mới",
                PublishedYear = 2024
            };
        }

        public static BookUpdateDto GetUpdatedBook()
        {
            return new BookUpdateDto
            {
                Title = "Sách cập nhật",
                Author = "Tác giả cập nhật",
                PublishedYear = 2025
            };
        }

        public static BookDto GetBookForUpdate()
        {
            return new BookDto
            {
                Id = 4,
                Title = "Sách cập nhật hoàn chỉnh",
                Author = "Tác giả cập nhật hoàn chỉnh",
                PublishedYear = 2026
            };
        }
    }
}
