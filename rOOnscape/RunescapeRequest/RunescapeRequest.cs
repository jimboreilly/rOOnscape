using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using rOOnscape.Structures;
using rOOnscape.Core.Http;

namespace rOOnscape {
  public class RuneScapeRequest {

    public RuneScapeRequest() { }

    private string parseWebResponseToString(WebResponse response) {
      var streamReader = new StreamReader(response.GetResponseStream());
      var responseString = streamReader.ReadToEnd();
      streamReader.Close();

      return responseString;
    }

    public string GetHttpRequestResponse(string url) {

      var request = new WebRequestDecorator(url);
      var httpResponse = request.GetResponse();
      var responseString = parseWebResponseToString(httpResponse);

      httpResponse.Close();

      return responseString;

    }

    public Player GetOsrsPlayerByName(string playerName) {
      var baseurl = "http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=";
      var responseFromServer = GetHttpRequestResponse(baseurl + playerName);

      var transcribedResponse = responseFromServer.Split('\n').Select(row => row.Split(','));

      var justSkills = transcribedResponse.Take(Player.TotalSkills);
      var justMinigames = transcribedResponse.Skip(Player.TotalSkills);

      return new Player(justSkills, justMinigames);
    }
  }
}
