using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;


namespace WebApplication1
{
    public class WebEventHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(new
                    WebSocketHandler());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}