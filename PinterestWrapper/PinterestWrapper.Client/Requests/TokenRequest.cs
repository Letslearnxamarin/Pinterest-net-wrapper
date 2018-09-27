using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.Requests
{
    public class TokenRequest
    {
        public string Grant_Type { get; set; }
        public string Client_Id { get; set; }
        public string Client_Secret { get; set; }
        public string Code { get; set; }
    }
}
