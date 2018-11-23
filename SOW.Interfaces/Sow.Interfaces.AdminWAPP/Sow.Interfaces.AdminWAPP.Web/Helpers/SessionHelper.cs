using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.Web.Helpers
{
    public static class SessionHelper
    {
        private static readonly IHttpContextAccessor _httpContextAccessor;
        private static ISession _session => _httpContextAccessor.HttpContext.Session;

        public static void SetSession(string key, string value)
        {
            _session.SetString(key, value);
        }

        public static string GetSession(string key)
        {
            return _session.GetString(key);
        }
    }
}
