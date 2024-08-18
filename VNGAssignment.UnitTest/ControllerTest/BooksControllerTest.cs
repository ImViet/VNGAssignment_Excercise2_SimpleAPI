using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.Business.Interfaces;
using VNGAssignment.Business.Services;
using VNGAssignment.Contracts.Common;
using VNGAssignment.Contracts.Dtos.BookDto;
using VNGAssignment.Contracts.Enums;
using VNGAssignment.Contracts.Exceptions;
using VNGAssignment.DataAccessor.Entities;
using VNGAssignment.UnitTest.MockData;
using VNGAssignment.WebAPI.Controllers;
using Xunit.Sdk;

namespace VNGAssignment.UnitTest.ControllerTest
{
    public class BooksControllerTest
    {
        private readonly BooksController _booksController;
        private readonly Mock<IBookService> _mockBookService;

        public BooksControllerTest()
        {
            _mockBookService = new Mock<IBookService>();
            _booksController = new BooksController(_mockBookService.Object);
        }
        #region Should Return Success
        [Fact] 
        public async Task GetAll_ReturnsOkResult_WithListOfBooks()
        {
            var bookMockData = BookTestData.GetAllBooks();
            // Arrange
            var resultMock = new ResponseResult(ResultCode.Success, "Success", bookMockData);
            _mockBookService.Setup(service => service.GetAllAsync()).ReturnsAsync(resultMock);

            // Act
            var result = await _booksController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResult = Assert.IsType<ResponseResult>(okResult.Value);

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(ResultCode.Success, actualResult.StatusCode);
            Assert.Equal("Success", actualResult.Message);
            Assert.Equal(bookMockData, actualResult.Data);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WithBookDto()
        {
            // Arrange
            var bookId = 1;
            var bookMockData = BookTestData.GetBookById(bookId);
            var resultMock = new ResponseResult(ResultCode.Success, "Success", bookMockData);
            _mockBookService.Setup(service => service.GetByIdAsync(bookId)).ReturnsAsync(resultMock);

            // Act
            var result = await _booksController.GetById(bookId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResult = Assert.IsType<ResponseResult>(okResult.Value);

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(ResultCode.Success, actualResult.StatusCode);
            Assert.Equal("Success", actualResult.Message);
            Assert.Equal(bookMockData, actualResult.Data);
            var actualDataResult = Assert.IsType<BookDto>(actualResult.Data);
            Assert.Equal(1, actualDataResult.Id);
            Assert.Equal("Tôi thấy hoa vàng trên cỏ xanh", actualDataResult.Title);
        }

        [Fact]
        public async Task Add_ReturnsOkResult_WithSuccessMessage()
        {
            // Arrange
            var newBook = BookTestData.GetNewBook();
            var resultMock = new ResponseResult(ResultCode.Success, "Success", true);
            _mockBookService.Setup(service => service.AddAsync(newBook)).ReturnsAsync(resultMock);

            // Act
            var result = await _booksController.Add(newBook);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResult = Assert.IsType<ResponseResult>(okResult.Value);

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(ResultCode.Success, actualResult.StatusCode);
            Assert.Equal("Success", actualResult.Message);
            Assert.Equal(true, actualResult.Data);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithSuccessMessage()
        {
            // Arrange
            var bookId = 1;
            var updatedBook = BookTestData.GetUpdatedBook();
            var resultMock = new ResponseResult(ResultCode.Success, "Success", true);
            _mockBookService.Setup(service => service.UpdateAsync(bookId, updatedBook)).ReturnsAsync(resultMock);

            // Act
            var result = await _booksController.Update(bookId, updatedBook);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResult = Assert.IsType<ResponseResult>(okResult.Value);

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(ResultCode.Success, actualResult.StatusCode);
            Assert.Equal("Success", actualResult.Message);
            Assert.Equal(true, actualResult.Data);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WithSuccessMessage()
        {
            // Arrange
            var bookId = 1;
            var resultMock = new ResponseResult(ResultCode.Success, "Success", true);
            _mockBookService.Setup(service => service.DeleteAsync(bookId)).ReturnsAsync(resultMock);

            // Act
            var result = await _booksController.Delete(bookId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResult = Assert.IsType<ResponseResult>(okResult.Value);

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(ResultCode.Success, actualResult.StatusCode);
            Assert.Equal("Success", actualResult.Message);
            Assert.Equal(true, actualResult.Data);
        }
        #endregion

        #region Should Return Exception
        [Fact]
        public async Task GetById_ReturnsBookNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var bookId = 1;
            var errorMessage = "BookId doest not exist.";
            var resultMock = new ResponseResult(ResultCode.Fail, errorMessage);
            _mockBookService.Setup(repo => repo.GetByIdAsync(bookId)).ThrowsAsync(new NotFoundException(errorMessage));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _booksController.GetById(bookId));

            Assert.Equal(errorMessage, exception.Message);
        }
        [Fact]
        public async Task Add_ReturnsBookNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var newBook = BookTestData.GetNewBook();
            var errorMessage = "BookId doest not exist.";
            var resultMock = new ResponseResult(ResultCode.Fail, errorMessage);
            _mockBookService.Setup(repo => repo.AddAsync(newBook)).ThrowsAsync(new NotFoundException(errorMessage));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _booksController.Add(newBook));

            Assert.Equal(errorMessage, exception.Message);
        }
        [Fact]
        public async Task Update_ReturnsBookNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var bookId = 1;
            var updateBook = BookTestData.GetUpdatedBook();
            var errorMessage = "BookId doest not exist.";
            var resultMock = new ResponseResult(ResultCode.Fail, errorMessage);
            _mockBookService.Setup(repo => repo.UpdateAsync(bookId, updateBook)).ThrowsAsync(new NotFoundException(errorMessage));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _booksController.Update(bookId, updateBook));

            Assert.Equal(errorMessage, exception.Message);
        }
        [Fact]
        public async Task Delete_ReturnsBookNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var bookId = 1;
            var errorMessage = "BookId doest not exist.";
            var resultMock = new ResponseResult(ResultCode.Fail, errorMessage);
            _mockBookService.Setup(repo => repo.DeleteAsync(bookId)).ThrowsAsync(new NotFoundException(errorMessage));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _booksController.Delete(bookId));

            Assert.Equal(errorMessage, exception.Message);
        }
        #endregion
    }
}
