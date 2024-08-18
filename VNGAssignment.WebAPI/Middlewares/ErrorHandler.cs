using Newtonsoft.Json;
using System.Net;
using VNGAssignment.Contracts.Common;
using VNGAssignment.Contracts.Exceptions;
using VNGAssignment.Contracts.Enums;
using FluentValidation;
using Serilog;
namespace VNGAssignment.WebAPI.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (!context.Request.Headers.ContainsKey("xAuth") || string.IsNullOrWhiteSpace(context.Request.Headers["xAuth"]))
                {
                    throw new UnAuthorizedException("You are not authorized");
                }
                else
                {
                    await _next(context);
                }
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string errMessage;

                switch (error)
                {
                    case NotFoundException e:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        errMessage = e.Message;
                        break;

                    case BadRequestException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        errMessage = e.Message;
                        break;
                    case ErrorException e:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        errMessage = e.Message;
                        break;
                    case UnAuthorizedException e:
                        response.StatusCode = StatusCodes.Status401Unauthorized;
                        errMessage = e.Message;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        errMessage = "Something went wrong!!!";
                        break;
                }

                var result = JsonConvert.SerializeObject(new ResponseResult(ResultCode.Fail, errMessage));
                Log.Error($"Logtime: {DateTime.Now }. Detail: {result}");
                await response.WriteAsync(result);
            }
        }
    }
}
