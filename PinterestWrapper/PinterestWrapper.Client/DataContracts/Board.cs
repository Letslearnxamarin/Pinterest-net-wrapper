using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.DataContracts
{
    public class Board : ItemBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Boards : List<Board>
    {

    }
}
