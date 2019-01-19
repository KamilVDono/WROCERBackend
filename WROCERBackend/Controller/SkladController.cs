using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataAccess;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkladController : ControllerBase
	{
		private readonly IDataAccess _DataAccess;

		public SkladController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}

		// GET: api/Sklad/mecz/1/druzyna/1
		[HttpGet("mecz/{idMecz}/druzyna/{idDruzyna}", Name = "Get")]
		public ActionResult<IEnumerable<DataGracz>> Get(int idMecz, int idDruzyna)
		{
			var mecz = _DataAccess.GetItem<DataMecz>(idMecz);
			if (mecz == null)
			{
				return NotFound();
			}

			var druzyna = _DataAccess.GetItem<DataDruzyna>(idDruzyna);
			if (druzyna == null)
			{
				return NotFound();
			}

			var raport = _DataAccess.GetAll<DataRaport>().FirstOrDefault(r => r.Mecz == mecz);
			if (raport == null)
			{
				raport = new DataRaport()
				{
					Mecz = mecz,
				};
				_DataAccess.AddItem(raport);
				raport = _DataAccess.GetAll<DataRaport>().FirstOrDefault(r => r.Mecz == mecz);
			}

			var zawodnicy = _DataAccess.GetAll<DataZawodnik>().Where(z => z.Druzyna == druzyna)
				.ToList();

			if (!zawodnicy.Any())
			{
				return NotFound();
			}

			var gracze = GetOrCreateDataGraczes(zawodnicy, raport);

			return Ok(gracze);
		}

		private IEnumerable<DataGracz> GetOrCreateDataGraczes(List<DataZawodnik> zawodnicy,
			DataRaport raport)
		{
			var gracze = _DataAccess.GetAll<DataGracz>()
				.Where(g => g.Raport == raport && zawodnicy.Contains(g.Zawodnik));

			var graczeList = gracze.ToList();
			if (graczeList.Count == zawodnicy.Count)
			{
				return graczeList;
			}

			List<DataZawodnik> missing = zawodnicy.Where(
				z => graczeList.All(g => g.Zawodnik != z)
			).ToList();

			graczeList = new List<DataGracz>(missing.Count);
			foreach (var dataZawodnik in missing)
			{
				graczeList.Add(new DataGracz()
				{
					Pozycja = dataZawodnik.Pozycja,
					Raport = raport,
					Zawodnik = dataZawodnik,
				});
			}

			foreach (var gracz in graczeList)
			{
				_DataAccess.AddItem(gracz);
			}

			return _DataAccess.GetAll<DataGracz>()
				.Where(g => g.Raport == raport && zawodnicy.Contains(g.Zawodnik));
		}

		// PUT: api/Sklad/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataGracz value)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (value == null || _DataAccess.UpdateItem(value) == false)
			{
				return NotFound();
			}

			return Ok();
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var gracz = _DataAccess.GetItem<DataGracz>(id);

			if (gracz == null)
			{
				return NotFound();
			}

			var success = _DataAccess.RemoveItem(gracz);

			if (success)
			{
				return Ok();
			}
			else
			{
				return NotFound();
			}
		}
	}
}
