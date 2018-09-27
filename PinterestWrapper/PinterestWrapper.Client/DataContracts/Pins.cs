using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.DataContracts
{
    public class Pin : ItemBase
    {
        public string Link { get; set; }
        public Board Board { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
        public IDictionary<string, string> Media { get; set; }
        public IDictionary<string, string> Attribution { get; set; }
        public IDictionary<string, object> Metadata { get; set; }

    }

    public class Pins : List<Pin>
    {

    }

}
