using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Log
{
    public class SystemActivityLog : ActivityLogBase
    {
        public string Message { get; set; }
        public SystemActivityLog(string message) : base()
        {
            Message = message;
        }
    }
}
