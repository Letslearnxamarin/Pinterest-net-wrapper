using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client.Helpers
{
    [Flags]
    internal enum PermissionsEnum
    {
        None = 1,
        Read_public = 2,
        Write_public = 4,
        Read_relationships = 8,
        Write_relationships = 16
    }
}
