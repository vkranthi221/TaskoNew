using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;
using Tasko.Repository;

namespace Tasko.Common
{
    public static class TokenHelper
    {
        /// <summary>
        /// Validates the token.
        /// </summary>
        /// <returns>bool value</returns>
        public static bool ValidateToken()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string tokenCode = headers["Token_Code"];
            string userId = headers["User_Id"];
            if (!string.IsNullOrEmpty(tokenCode) && !string.IsNullOrEmpty(userId))
            {
                bool isTokenValid = VendorData.ValidateTokenCode(tokenCode, userId);
                return isTokenValid;
            }

            return false;
        }
    }
}