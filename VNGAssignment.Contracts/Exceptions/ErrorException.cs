﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNGAssignment.Contracts.Exceptions
{
    public class ErrorException : Exception
    {
        public ErrorException()
        {

        }
        public ErrorException(string message) : base(message)
        {

        }
    }
}
