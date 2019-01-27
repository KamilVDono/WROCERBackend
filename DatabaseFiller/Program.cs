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
			//ClearDatabase();
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

		public static async System.Threading.Tasks.Task<string> SendAsync(string uri, string type, string json)
		{
			HttpResponseMessage response;
			using (var client = new HttpClient())
			{
				response = await client.PostAsync(
					$"{uri}{type}",
					new StringContent(json, Encoding.UTF8, "application/json"));
			}

			return response.Content.ReadAsStringAsync().Result;
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
					Nazwisko = "Januszowski",
					NumerKoszulki = 99,
					Pozycja = Pozycja[0],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1991, 10, 21).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski1",
					NumerKoszulki = 1,
					Pozycja = Pozycja[1],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1992, 10, 21).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski2",
					NumerKoszulki = 11,
					Pozycja = Pozycja[1],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 11, 21).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski3",
					NumerKoszulki = 22,
					Pozycja = Pozycja[1],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 12, 21).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski4",
					NumerKoszulki = 21,
					Pozycja = Pozycja[1],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 10, 11).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski5",
					NumerKoszulki = 45,
					Pozycja = Pozycja[2],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 10, 22).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski6",
					NumerKoszulki = 2,
					Pozycja = Pozycja[2],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 10, 12).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski7",
					NumerKoszulki = 1,
					Pozycja = Pozycja[2],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 11, 12).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski8",
					NumerKoszulki = 9,
					Pozycja = Pozycja[2],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 12, 11).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski9",
					NumerKoszulki = 65,
					Pozycja = Pozycja[3],
					Druzyna = Druzyna[0]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 1, 21).Ticks),
					Imie = "Janusz",
					Nazwisko = "Januszowski10",
					NumerKoszulki = 69,
					Pozycja = Pozycja[3],
					Druzyna = Druzyna[0]
				},

				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1990, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz",
					NumerKoszulki = 88,
					Pozycja = Pozycja[0],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1981, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz1",
					NumerKoszulki = 15,
					Pozycja = Pozycja[1],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1982, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz2",
					NumerKoszulki = 9,
					Pozycja = Pozycja[1],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1983, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz3",
					NumerKoszulki = 8,
					Pozycja = Pozycja[1],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1984, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz4",
					NumerKoszulki = 7,
					Pozycja = Pozycja[1],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1985, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz5",
					NumerKoszulki = 66,
					Pozycja = Pozycja[2],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1986, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz6",
					NumerKoszulki = 5,
					Pozycja = Pozycja[2],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1987, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz7",
					NumerKoszulki = 4,
					Pozycja = Pozycja[2],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1988, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz8",
					NumerKoszulki = 3,
					Pozycja = Pozycja[3],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1989, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz9",
					NumerKoszulki = 2,
					Pozycja = Pozycja[3],
					Druzyna = Druzyna[1]
				},
				new DataZawodnik()
				{
					DataUrodzenia = (new DateTime(1996, 2, 21).Ticks),
					Imie = "Adam",
					Nazwisko = "Adamowicz10",
					NumerKoszulki = 1,
					Pozycja = Pozycja[3],
					Druzyna = Druzyna[1]
				},
			};
			FillDatabaseZawodnik(Zawodnik);

			List<DataMecz> Mecz = new List<DataMecz>()
			{
				new DataMecz()
				{
					Termin = new DateTime(2019, 1, 26).Ticks,
					Gospodarz = Druzyna[0],
					Gosc = Druzyna[1],
					Sedzia = Uzytkownik[2],
					Sezon = Sezon[0]
				},
			};
			FillDatabaseMecz(Mecz);

			List<DataRaport> Raport = new List<DataRaport>()
			{
				new DataRaport(){ Mecz = Mecz[0]},
			};
			FillDatabaseRaport(Raport);

			List<DataGracz> Gracz = new List<DataGracz>()
			{
				new DataGracz(),
			};
			Get($"{BaseUri}Sklad/mecz/{Mecz[0].ID}/druzyna/{Druzyna[0].ID}");
			Get($"{BaseUri}Sklad/mecz/{Mecz[0].ID}/druzyna/{Druzyna[1].ID}");
			//FillDatabaseGracz(Gracz);

			List<DataSytuacjaMeczowa> SytuacjaMeczowa = new List<DataSytuacjaMeczowa>()
			{
				new DataSytuacjaMeczowa(),
			};

			List<DataZmiana> Zmiana = new List<DataZmiana>()
			{
				new DataZmiana(),
			};

			//

			//FillDatabaseSytuacjaMeczowa(SytuacjaMeczowa);

			//FillDatabaseZmiana(Zmiana);
		}

		private static void FillDatabaseDruzyna(List<DataDruzyna> Druzyna)
		{
			for (int i = 0; i < Druzyna.Count; i++)
			{
				var json = Serialize(Druzyna[i]);
				var rJSON = SendAsync(BaseUri, $"Druzyna/trener/{Druzyna[i].Trener.ID}", json).Result;
				Druzyna[i] = JsonConvert.DeserializeObject<DataDruzyna>(rJSON);
			}
		}

		private static void FillDatabaseGracz(List<DataGracz> Gracz)
		{
			for (int i = 0; i < Gracz.Count; i++)
			{
				var json = Serialize(Gracz[i]);
				var rJSON = SendAsync(BaseUri, "Gracz", json).Result;
				Gracz[i] = JsonConvert.DeserializeObject<DataGracz>(rJSON);
			}
		}

		private static void FillDatabaseMecz(List<DataMecz> Mecz)
		{
			for (int i = 0; i < Mecz.Count; i++)
			{
				var json = Serialize(Mecz[i]);
				var rJSON = SendAsync(BaseUri, 
					$"Mecz/sezon/{Mecz[i].Sezon.ID}/sedzia/{Mecz[i].Sedzia.ID}/gospodarz/{Mecz[i].Gospodarz.ID}/gosc/{Mecz[i].Gosc.ID}", json).Result;
				Mecz[i] = JsonConvert.DeserializeObject<DataMecz>(rJSON);
			}
		}

		private static void FillDatabasePozycja(List<DataPozycja> Pozycja)
		{
			for (int i = 0; i < Pozycja.Count; i++)
			{
				var json = Serialize(Pozycja[i]);
				var rJSON = SendAsync(BaseUri, "Pozycja", json).Result;
				Pozycja[i] = JsonConvert.DeserializeObject<DataPozycja>(rJSON);
			}
		}

		private static void FillDatabaseRaport(List<DataRaport> Raport)
		{
			for (int i = 0; i < Raport.Count; i++)
			{
				var json = Serialize(Raport[i]);
				var rJSON = SendAsync(BaseUri, "Raport", json).Result;
				Raport[i] = JsonConvert.DeserializeObject<DataRaport>(rJSON);
			}
		}

		private static void FillDatabaseSezon(List<DataSezon> Sezon)
		{
			for (int i = 0; i < Sezon.Count; i++)
			{
				var json = Serialize(Sezon[i]);
				var rJSON = SendAsync(BaseUri, "Sezon", json).Result;
				Sezon[i] = JsonConvert.DeserializeObject<DataSezon>(rJSON);
			}
		}

		private static void FillDatabaseSklad(List<DataSklad> Sklad)
		{
			for (int i = 0; i < Sklad.Count; i++)
			{
				var json = Serialize(Sklad[i]);
				var rJSON = SendAsync(BaseUri, "Sklad", json).Result;
				Sklad[i] = JsonConvert.DeserializeObject<DataSklad>(rJSON);
			}
		}

		private static void FillDatabaseSytuacjaMeczowa(List<DataSytuacjaMeczowa> SytuacjaMeczowa)
		{
			for (int i = 0; i < SytuacjaMeczowa.Count; i++)
			{
				var json = Serialize(SytuacjaMeczowa[i]);
				var rJSON = SendAsync(BaseUri, "SytuacjaMeczowa", json).Result;
				SytuacjaMeczowa[i] = JsonConvert.DeserializeObject<DataSytuacjaMeczowa>(rJSON);
			}
		}

		private static void FillDatabaseSytuacjaTyp(List<DataSytuacjaTyp> SytuacjaTyp)
		{
			for (int i = 0; i < SytuacjaTyp.Count; i++)
			{
				var json = Serialize(SytuacjaTyp[i]);
				var rJSON = SendAsync(BaseUri, "SytuacjaTyp", json).Result;
				SytuacjaTyp[i] = JsonConvert.DeserializeObject<DataSytuacjaTyp>(rJSON);
			}
		}

		private static void FillDatabaseUzytkownik(List<DataUzytkownik> Uzytkownik)
		{
			for (int i = 0; i < Uzytkownik.Count; i++)
			{
				var json = Serialize(Uzytkownik[i]);
				var rJSON = SendAsync(BaseUri, $"Uzytkownik/typ/{Uzytkownik[i].Typ.ID}", json).Result;
				Uzytkownik[i] = JsonConvert.DeserializeObject<DataUzytkownik>(rJSON);
			}
		}

		private static void FillDatabaseUzytkownikTyp(List<DataUzytkownikTyp> UzytkownikTyp)
		{
			for (int i = 0; i < UzytkownikTyp.Count; i++)
			{
				var json = Serialize(UzytkownikTyp[i]);
				var rJSON = SendAsync(BaseUri, "UzytkownikTyp", json).Result;
				UzytkownikTyp[i] = JsonConvert.DeserializeObject<DataUzytkownikTyp>(rJSON);
			}
		}

		private static void FillDatabaseZawodnik(List<DataZawodnik> Zawodnik)
		{
			for (int i = 0; i < Zawodnik.Count; i++)
			{
				var json = Serialize(Zawodnik[i]);
				var rJSON = SendAsync(BaseUri, $"Zawodnik/pozycja/{Zawodnik[i].Pozycja.ID}/druzyna/{Zawodnik[i].Druzyna.ID}", json).Result;
				Zawodnik[i] = JsonConvert.DeserializeObject<DataZawodnik>(rJSON);
			}
		}

		private static void FillDatabaseZmiana(List<DataZmiana> Zmiana)
		{
			for (int i = 0; i < Zmiana.Count; i++)
			{
				var json = Serialize(Zmiana[i]);
				var rJSON = SendAsync(BaseUri, "Zmiana", json).Result;
				Zmiana[i] = JsonConvert.DeserializeObject<DataZmiana>(rJSON);
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
