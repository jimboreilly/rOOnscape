using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using rOOnscape.Structures;
using rOOnscape.Structures.Types;

namespace rOOnscape {
  public class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");

      var api = new RuneScapeRequest();
      var me = api.GetOsrsPlayerByName("SystemTest");

      Console.WriteLine(me.GetLevelOfSkill(SkillName.Strength));
      Console.ReadLine();
    }
  }

}
