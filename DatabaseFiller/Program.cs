using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

			Console.WriteLine("Start deleting");
			ClearDatabase();
			Console.WriteLine("Deleted");
			Console.WriteLine("Start adding");
			FillDatabase();
			Console.WriteLine("Filled");
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

		public static async void SendAsync(string uri, string type, string json)
		{
			using (var client = new HttpClient())
			{
				var response = await client.PostAsync(
					$"{uri}{type}",
					new StringContent(json, Encoding.UTF8, "application/json"));
			}
		}

		public static void DeleteItem(string uri, long id, string type)
		{
			WebRequest request = WebRequest.Create(uri + $"{type}/{id}");
			request.Method = "DELETE";

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		}

		public static IEnumerable<AbstractDataModel> Deserialize<T>(string uri) where T : AbstractDataModel
		{
			var json = Get(uri);
			var o = JsonConvert.DeserializeObject<List<T>>(json);
			return o;
		}

		public static string Serialize<T>(T item) where T : AbstractDataModel
		{
			return JsonConvert.SerializeObject(item);
		}

		private static void FillDatabase()
		{
			List<DataSezon> Sezon = new List<DataSezon>()
			{
				new DataSezon(){Rok = 2019}
			};
			FillDatabaseSezon(Sezon);

			List<DataSklad> Sklad = new List<DataSklad>()
			{
				new DataSklad(){Nazwa = "Podstawowy"},
				new DataSklad(){Nazwa = "Rezerwowy"},
			};
			FillDatabaseSklad(Sklad);

			List<DataUzytkownikTyp> UzytkownikTyp = new List<DataUzytkownikTyp>()
			{
				new DataUzytkownikTyp(){Nazwa = "Trener"},
				new DataUzytkownikTyp(){Nazwa = "Sedzia"},
				new DataUzytkownikTyp(){Nazwa = "Zarzadca"},
			};
			FillDatabaseUzytkownikTyp(UzytkownikTyp);

			List<DataSytuacjaTyp> SytuacjaTyp = new List<DataSytuacjaTyp>()
			{
				new DataSytuacjaTyp(){Nazwa = "Żółta kartka"},
				new DataSytuacjaTyp(){Nazwa = "Czerwona kartka"},
				new DataSytuacjaTyp(){Nazwa = "Gol"},
				new DataSytuacjaTyp(){Nazwa = "Asysta"},
			};
			FillDatabaseSytuacjaTyp(SytuacjaTyp);

			List<DataUzytkownik> Uzytkownik = new List<DataUzytkownik>()
			{
				new DataUzytkownik()
				{
					Imie = "Trener", Nazwisko = "1", Typ = UzytkownikTyp[0],
				},
				new DataUzytkownik()
				{
					Imie = "Trener", Nazwisko = "2", Typ = UzytkownikTyp[0],
				},
				new DataUzytkownik()
				{
					Imie = "Sedzia", Nazwisko = "1", Typ = UzytkownikTyp[1],
				},
			};
			FillDatabaseUzytkownik(Uzytkownik);

			List<DataPozycja> Pozycja = new List<DataPozycja>()
			{
				new DataPozycja(){Nazwa = "Bramkarz"},
				new DataPozycja(){Nazwa = "Obrońca"},
				new DataPozycja(){Nazwa = "Pomocnik"},
				new DataPozycja(){Nazwa = "Napastnik"},
			};
			FillDatabasePozycja(Pozycja);

			List<DataDruzyna> Druzyna = new List<DataDruzyna>()
			{
				new DataDruzyna()
				{
					Nazwa = "Krasnale Wrocław",
					Trener = Uzytkownik[0],
				},
				new DataDruzyna()
				{
					Nazwa = "Krasnale Wrocław2",
					Trener = Uzytkownik[1],
				},
			};
			FillDatabaseDruzyna(Druzyna);

			List<DataZawodnik> Zawodnik = new List<DataZawodnik>()
			{
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 10, 21).Ticks),
					Imie = "Janusz",

				}
			};
			FillDatabaseZawodnik(Zawodnik);

			List<DataRaport> Raport = new List<DataRaport>()
			{
				new DataRaport(),
			};
			FillDatabaseRaport(Raport);

			

			List<DataGracz> Gracz = new List<DataGracz>()
			{
				new DataGracz(),
			};

			List<DataMecz> Mecz = new List<DataMecz>()
			{
				new DataMecz(),
			};

			List<DataSytuacjaMeczowa> SytuacjaMeczowa = new List<DataSytuacjaMeczowa>()
			{
				new DataSytuacjaMeczowa(),
			};

			

			List<DataZmiana> Zmiana = new List<DataZmiana>()
			{
				new DataZmiana(),
			};

			
			FillDatabaseGracz(Gracz);
			FillDatabaseMecz(Mecz);

			FillDatabaseSytuacjaMeczowa(SytuacjaMeczowa);

			
			FillDatabaseZmiana(Zmiana);
		}

		private static void FillDatabaseDruzyna(List<DataDruzyna> Druzyna)
		{
			var typesJson = Get(BaseUri + "Uzytkownik");
			var types = JsonConvert.DeserializeObject<List<DataUzytkownik>>(typesJson);
			foreach (var dataDruzyna in Druzyna)
			{
				var json = Serialize(dataDruzyna);
				var idTyp = types.FirstOrDefault(t => t.Imie == dataDruzyna.Trener.Imie && t.Nazwisko == dataDruzyna.Trener.Nazwisko);
				SendAsync(BaseUri, $"Druzyna/trener/{idTyp.ID}", json);
			}
		}

		private static void FillDatabaseGracz(List<DataGracz> Gracz)
		{
			foreach (var dataDruzyna in Gracz)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "Gracz", json);
			}
		}

		private static void FillDatabaseMecz(List<DataMecz> Mecz)
		{
			foreach (var dataDruzyna in Mecz)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "Mecz", json);
			}
		}

		private static void FillDatabasePozycja(List<DataPozycja> Pozycja)
		{
			foreach (var dataDruzyna in Pozycja)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "Pozycja", json);
			}
		}

		private static void FillDatabaseRaport(List<DataRaport> Raport)
		{
			foreach (var dataDruzyna in Raport)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "Raport", json);
			}
		}

		private static void FillDatabaseSezon(List<DataSezon> Sezon)
		{
			foreach (var dataDruzyna in Sezon)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "Sezon", json);
			}
		}

		private static void FillDatabaseSklad(List<DataSklad> Sklad)
		{
			foreach (var dataDruzyna in Sklad)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "SkladTyp", json);
			}
		}

		private static void FillDatabaseSytuacjaMeczowa(List<DataSytuacjaMeczowa> SytuacjaMeczowa)
		{
			foreach (var dataDruzyna in SytuacjaMeczowa)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "SytuacjaMeczowa", json);
			}
		}

		private static void FillDatabaseSytuacjaTyp(List<DataSytuacjaTyp> SytuacjaTyp)
		{
			foreach (var dataDruzyna in SytuacjaTyp)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "SytuacjaTyp", json);
			}
		}

		private static void FillDatabaseUzytkownik(List<DataUzytkownik> Uzytkownik)
		{
			var typesJson = Get(BaseUri + "UzytkownikTyp");
			var types = JsonConvert.DeserializeObject<List<DataUzytkownikTyp>>(typesJson);
			foreach (var dataDruzyna in Uzytkownik)
			{
				var json = Serialize(dataDruzyna);
				var idTyp = types.FirstOrDefault(t => t.Nazwa == dataDruzyna.Typ.Nazwa);
				SendAsync(BaseUri, $"Uzytkownik/typ/{idTyp.ID}", json);
			}
		}

		private static void FillDatabaseUzytkownikTyp(List<DataUzytkownikTyp> UzytkownikTyp)
		{
			foreach (var dataDruzyna in UzytkownikTyp)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "UzytkownikTyp", json);
			}
		}

		private static void FillDatabaseZawodnik(List<DataZawodnik> Zawodnik)
		{
			foreach (var dataDruzyna in Zawodnik)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "Zawodnik", json);
			}
		}

		private static void FillDatabaseZmiana(List<DataZmiana> Zmiana)
		{
			foreach (var dataDruzyna in Zmiana)
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, "Zmiana", json);
			}
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
			var items = Deserialize<DataSklad>(BaseUri + "SkladTyp");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, "SkladTyp");
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
