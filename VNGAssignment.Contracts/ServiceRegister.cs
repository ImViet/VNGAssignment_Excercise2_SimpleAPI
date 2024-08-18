using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using System.Reflection;
using VNGAssignment.Contracts.Validators;

namespace VNGAssignment.Contracts
{
    public static class ServiceRegister
    {
        public static void AddContractsLayer(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<BookDtoValidator>();
            });
        }
    }
}
