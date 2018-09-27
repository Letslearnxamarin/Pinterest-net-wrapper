using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.DataContracts
{
    public class Base : Entity
    {
        public string Created_At { get; set; }
        public IDictionary<string, Int32> Counts { get; set; }
        public IDictionary<string, Image> Image { get; set; }
    }
}
