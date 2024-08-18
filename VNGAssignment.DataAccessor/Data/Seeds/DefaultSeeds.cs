using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.DataAccessor.Entities;

namespace VNGAssignment.DataAccessor.Data.Seeds
{
    public static class DefaultSeeds
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if(!context.Books.Any())
            {
                await context.Books.AddRangeAsync(
                    new Book() { Title = "Tôi thấy hoa vàng trên cỏ xanh", Author = "Nguyễn Nhật Ánh", PublishedYear = 2010 },
                    new Book() { Title = "Đất rừng Phương Nam", Author = "Đoàn Giỏi", PublishedYear = 2014 },
                    new Book() { Title = "Sổ đỏ", Author = "Vũ Trọng Phụng", PublishedYear = 2012 });
                await context.SaveChangesAsync();
            }  
        }
    }
}
