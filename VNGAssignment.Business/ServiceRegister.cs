using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.Business.Interfaces;
using VNGAssignment.Business.Services;

namespace VNGAssignment.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer( this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IBookService, BookService>();
        }
    }
}
