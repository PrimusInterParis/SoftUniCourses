﻿
namespace SUHttpServer.Responses
{
    using HTTP;

    public class RedirectResponse:Response
    {
        public RedirectResponse(string location) 
            : base(StatusCode.Found)
        {
            this.Headers.Add(Header.Location, location);
        }
    }
}
