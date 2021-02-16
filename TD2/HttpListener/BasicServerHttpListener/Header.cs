using System.Net;
using System.Text;

namespace BasicServerHTTPlistener
{
    class Header
    {
        private string accept;
        private string acceptCharset;
        private string acceptEncoding;
        private string acceptLanguage;
        private string allow;
        private string authorization;
        private string cookie;
        private string from;
        private string userAgent;

        public Header(WebHeaderCollection webHeaderCollection)
        {
            accept = webHeaderCollection.Get("Accept");
            acceptCharset = webHeaderCollection.Get("Accept-Charset");
            acceptEncoding = webHeaderCollection.Get("Accept-Encoding");
            acceptLanguage = webHeaderCollection.Get("Accept-Language");
            allow = webHeaderCollection.Get("Allow");
            authorization = webHeaderCollection.Get("Authorization");
            cookie = webHeaderCollection.Get("Cookie");
            from = webHeaderCollection.Get("From");
            userAgent = webHeaderCollection.Get("User-Agent");
        }

        public override string ToString()
        {
            string headers = "<< Headers >>\n";

            if (this.accept != null)
                headers += "Accept: " + this.accept + "\n";
            if (this.acceptCharset != null)
                headers += "Accept-Charset: " + this.acceptCharset + "\n";
            if (this.acceptEncoding != null)
                headers += "Accept-Encoding : " + this.acceptEncoding + "\n";
            if (this.acceptLanguage != null)
                headers += "Accept-Language: " + this.acceptLanguage + "\n";
            if (this.allow != null)
                headers += "Allow: " + this.allow + "\n";
            if (this.authorization != null)
                headers += "Authorization: " + this.authorization + "\n";
            if (this.cookie != null)
                headers += "Cookie: " + this.cookie + "\n";
            if (this.from != null)
                headers += "From: " + this.from + "\n";
            if (this.userAgent != null)
                headers += "User-Agent: " + this.userAgent + "\n";

            return headers;
        }
    }
}