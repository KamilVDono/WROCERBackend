using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using WROCERBackend.Model.DataModel;

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

		public static IEnumerable<AbstractDataModel> Deserialize<T>(string uri) where T : AbstractDataModel
		{
			var json = Get(uri);
			var o =  JsonConvert.DeserializeObject<List<T>>(json);
			return o;
		}

		public static void DeleteItem(string uri, long id, string type)
		{
			WebRequest request = WebRequest.Create(uri + $"{type}/{id}");
			request.Method = "DELETE";

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		}

		public static void ClearDatabase()
		{

			ClearDatabaseDruzyna();
			ClearDatabaseGracz();
			ClearDatabaseMecz();
			ClearDatabasePozycja();
			ClearDatabaseRaport();
			ClearDatabaseSezon();
			ClearDatabaseSklad();
			ClearDatabaseSytuacjaMeczowa();
			ClearDatabaseSytuacjaTyp();
			ClearDatabaseUzytkownik();
			ClearDatabaseUzytkownikTyp();
			ClearDatabaseZawodnik();
			ClearDatabaseZmiana();
		}

		private static void ClearDatabaseDruzyna()
		{
			var items = Deserialize<DataDruzyna>(BaseUri + "Druzyna");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Druzyna");
			}
		}
		private static void ClearDatabaseGracz()
		{
			var items = Deserialize<DataGracz>(BaseUri + "Gracz");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Gracz");
			}
		}
		private static void ClearDatabaseMecz()
		{
			var items = Deserialize<DataMecz>(BaseUri + "Mecz");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Mecz");
			}
		}
		private static void ClearDatabasePozycja()
		{
			var items = Deserialize<DataPozycja>(BaseUri + "Pozycja");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Pozycja");
			}
		}
		private static void ClearDatabaseRaport()
		{
			var items = Deserialize<DataRaport>(BaseUri + "Raport");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Raport");
			}
		}
		private static void ClearDatabaseSezon()
		{
			var items = Deserialize<DataSezon>(BaseUri + "Sezon");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Sezon");
			}
		}
		private static void ClearDatabaseSklad()
		{
			var items = Deserialize<DataSklad>(BaseUri + "Sklad");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Sklad");
			}
		}
		private static void ClearDatabaseSytuacjaMeczowa()
		{
			var items = Deserialize<DataSytuacjaMeczowa>(BaseUri + "SytuacjaMeczowa");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "SytuacjaMeczowa");
			}
		}
		private static void ClearDatabaseSytuacjaTyp()
		{
			var items = Deserialize<DataSytuacjaTyp>(BaseUri + "SytuacjaTyp");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "SytuacjaTyp");
			}
		}
		private static void ClearDatabaseUzytkownik()
		{
			var items = Deserialize<DataUzytkownik>(BaseUri + "Uzytkownik");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Uzytkownik");
			}
		}
		private static void ClearDatabaseUzytkownikTyp()
		{
			var items = Deserialize<DataUzytkownikTyp>(BaseUri + "UzytkownikTyp");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "UzytkownikTyp");
			}
		}
		private static void ClearDatabaseZawodnik()
		{
			var items = Deserialize<DataZawodnik>(BaseUri + "Zawodnik");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Zawodnik");
			}
		}
		private static void ClearDatabaseZmiana()
		{
			var items = Deserialize<DataZmiana>(BaseUri + "Zmiana");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "Zmiana");
			}
		}
	}
}
