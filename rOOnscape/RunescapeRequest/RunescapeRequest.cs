using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using rOOnscape.Structures;

namespace rOOnscape {
  public class RuneScapeRequest {

    public RuneScapeRequest() { }
    public string GetHttpRequestResponse(string url) {

      var request = WebRequest.Create(url);
      var httpResponse = request.GetResponse();
      var dataStream = httpResponse.GetResponseStream();
      var reader = new StreamReader(dataStream);

      var response = reader.ReadToEnd();

      reader.Close();
      httpResponse.Close();

      return response;

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
