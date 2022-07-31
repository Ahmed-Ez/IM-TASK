using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace IM_Task.App_Start
{
    public static class WebApiConfig
    {
        #region Public Methods and Operators       

        public static void RegisterRoutes(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
        }

        #endregion
    }
}