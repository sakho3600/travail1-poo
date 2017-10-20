using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace gestion
{
    public class User
    {
		public string name { get; set; }
		public int id { get; set; }
		public string screen_name { get; set; }
	}

	public class RootObject
	{
		public string text { get; set; }
		public long id { get; set; }
		public User user { get; set; }
		public object in_reply_to_screen_name { get; set; }

	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			string data = System.IO.File.ReadAllText(@"data.json");

            var h = JsonConvert.DeserializeObject<List<RootObject>>(data);

			Console.WriteLine(h[0].text);
            Console.WriteLine(h[1].user.screen_name);

		}
	}
}