using System;
using System.IO;
using Newtonsoft.Json;

namespace gestion{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string text = System.IO.File.ReadAllText(@"data.json");
			Console.WriteLine(text);
		}
	}   
}