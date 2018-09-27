using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.DataContracts
{
    public class Topic : Entity
    {
        public string Name { get; set; }
    }

    public class Topics : List<Topic> { }
}
