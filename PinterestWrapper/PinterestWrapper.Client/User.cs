using PinterestService.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinterestService.Client
{
    public class User
    {
        PermissionsEnum _permissionScope { get; set; }
        RateStatus _rates { get; set; }

        public string AccessToken { get; set; }

        public User(IEnumerable<string> grantedPermissions)
        {
            SetPermissions(grantedPermissions);

        }
        
        public bool GrantedPermission(PermissionsEnum scope) => _permissionScope.HasFlag(scope);

        private void SetPermissions(IEnumerable<string> grantedPermissions)
        {
            foreach (var permission in grantedPermissions)
            {
                if (Enum.TryParse(permission, out PermissionsEnum EenumValue))
                {
                    _permissionScope |= EenumValue;
                }
            }
        }

    }
}
