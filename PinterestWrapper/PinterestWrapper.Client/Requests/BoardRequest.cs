using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.Requests
{
    public class BoardRequest : UserRequest
    {
        public string Board_Name { get; set; }
    }
}
