using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.Utility
{
    public class RequestStatus
    {
        public RequestStatusEnum Request { get; set; }
    }

    public enum RequestStatusEnum
    {
       Executed,
       AwaitResponse,
       Complete,
       Error
    }
}
