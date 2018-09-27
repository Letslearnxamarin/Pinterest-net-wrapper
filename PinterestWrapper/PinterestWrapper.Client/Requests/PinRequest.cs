using PinterestService.Client.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.Requests
{
    public class PinRequest
    {
        public string Note { get; set; }
        public string Link { get; set; }
        public Image Image { get; set; }
        public string Image_Url { get; set; }
        public string Image_Base64 { get; set; }
    }
}
