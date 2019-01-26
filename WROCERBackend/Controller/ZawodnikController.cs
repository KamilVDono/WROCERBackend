using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataAccess;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ZawodnikController : BaseController<DataZawodnik>
	{
		public ZawodnikController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}

		// GET: api/Zawodnik
		[HttpGet]
		public ActionResult<IEnumerable<DataZawodnik>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/Zawodnik/5
		[HttpGet("{id}", Name = "GetDataZawodnik")]
		public ActionResult<DataZawodnik> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/Zawodnik
		[HttpPost("pozycja/{idPozycja}/druzyna/{idDruzyna}")]
		public ActionResult Post(int idPozycja, int idDruzyna, [FromBody] DataZawodnik value)
		{
			var pozycja = _DataAccess.GetItem<DataPozycja>(idPozycja);
			if (pozycja == null) return NotFound();

			var druzyna = _DataAccess.GetItem<DataDruzyna>(idDruzyna);
			if (druzyna == null) return NotFound();

			value.Pozycja = pozycja;
			value.Druzyna = druzyna;

			return TryPost(value);
		}

		// PUT: api/Zawodnik/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataZawodnik value)
		{
			return TryPut(id, value);
		}

		// DELETE: api/Zawodnik/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return TryDelete(id);
		}
	}
}