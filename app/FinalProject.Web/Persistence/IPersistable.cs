using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;

namespace FinalProject.Web.Persistence
{
    internal interface IPersistable
    {
        StateBag LocalViewState { get; }
        HttpRequest Request { get; }
        HttpSessionState Session { get; }
        HttpApplicationState Application { get; }
        HttpResponse Response { get; }
        HttpServerUtility Server { get; }
    }
}
