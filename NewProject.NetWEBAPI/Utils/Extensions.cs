using System;
using System.Web;

using Elmah;

namespace NewProject.NetWEBAPI.Utils
{
    public static class Extensions
    {
        public static void Log(this Exception ex)
        {
            if (HttpContext.Current == null)
                ErrorLog.GetDefault(null).Log(new Error(ex));
            else
                ErrorSignal.FromCurrentContext().Raise(ex);
        }
    }
}