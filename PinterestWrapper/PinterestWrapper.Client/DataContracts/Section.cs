using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.DataContracts
{
    public class Section : Entity
    {
        public string Title { get; set; }
    }

    public class Sections : List<Section>
    {

    }

}
