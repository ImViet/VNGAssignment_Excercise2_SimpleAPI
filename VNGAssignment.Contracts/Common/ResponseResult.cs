using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.Contracts.Enums;

namespace VNGAssignment.Contracts.Common
{
    public class ResponseResult
    {
        public ResultCode StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public ResponseResult()
        {

        }
        public ResponseResult(ResultCode code, string mesasge)
        {
            StatusCode = code;
            Message = mesasge;
        }
        public ResponseResult(ResultCode code, string message, object data) 
        {
            StatusCode = code;
            Message = message;
            Data = data;
        }
    }
}
