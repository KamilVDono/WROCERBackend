using System;
using System.IO;
using System.Net;

namespace DatabaseFiller
{
	class Program
	{
		private static string BaseUri = "https://localhost:44375/api/";

		static void Main(string[] args)
		{
			bool runFiller = true;
			if (runFiller == false)
			{
				Console.WriteLine("Filler is off");
				Console.ReadLine();
				return;
			}

			ClearDatabase();

			Console.ReadLine();
		}

		public static string Get(string uri)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}

		public static void ClearDatabase()
		{

		}

		public static void DeleteItem(string uri, int id, string type)
		{
			WebRequest request = WebRequest.Create(uri+$"{type}/{id}");
			request.Method = "DELETE";

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		}
	}
}
