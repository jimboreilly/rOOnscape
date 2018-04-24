using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace rOOnscape {
  public class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");

      var baseurl = "http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=Eeli";
      var request = WebRequest.Create(baseurl);
      var response = request.GetResponse();
      var dataStream = response.GetResponseStream();
      var reader = new StreamReader(dataStream);
      var responseFromServer = reader.ReadToEnd();

      var transcribedResponse = responseFromServer.Split('\n').Select(row => row.Split(','));
      var overallOffset = 1;
      var totalskills = 23;
      var minigameOffset = 9;

      var justSkills = transcribedResponse.Take(totalskills - minigameOffset).Skip(overallOffset);
      var justMinigame = transcribedResponse.Skip(overallOffset + totalskills);

      Console.WriteLine(responseFromServer);

      var a = new Player(justSkills, justMinigame);

      reader.Close();
      response.Close();
    }
  }

}
