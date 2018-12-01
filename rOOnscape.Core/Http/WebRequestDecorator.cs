using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;

namespace rOOnscape.Core.Http {

  public interface IWebRequest {
    WebResponse GetResponse();
  }

  public class WebRequestDecorator : IWebRequest {

    private readonly WebRequest request;

    public WebRequestDecorator(String url) {
      this.request = WebRequest.Create(url);
    }

    public WebResponse GetResponse() {
      return request.GetResponse();
    }
  }
}