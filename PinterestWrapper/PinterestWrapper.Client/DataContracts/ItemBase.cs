using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.DataContracts
{
    public class ItemBase : Base
    {
        public string Url { get; set; }
        public IDictionary<string, string> Creator { get; set; }
    }
}
