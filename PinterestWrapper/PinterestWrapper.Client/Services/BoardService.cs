using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.Services
{
    public class BoardService : BaseService
    {
        public BoardService(string version)
        {
            this.Version = version;
            this.Type = "Boards";
        }

    }
}
