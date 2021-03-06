using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataAccess;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class DruzynaController : BaseController<DataDruzyna>
	{
		public DruzynaController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}

		// GET: api/Druzyna
		[HttpGet]
		public ActionResult<IEnumerable<DataDruzyna>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/Druzyna/5
		[HttpGet("{id}", Name = "GetDataDruzyna")]
		public ActionResult<DataDruzyna> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/Druzyna
		[HttpPost("trener/{idTrener}")]
		public ActionResult Post(int idTrener, [FromBody] DataDruzyna value)
		{
			var trener = _DataAccess.GetItem<DataUzytkownik>(idTrener);
			if (trener == null) return NotFound();

			value.Trener = trener;

			return TryPost(value);
		}

		// PUT: api/Druzyna/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataDruzyna value)
		{
			return TryPut(id, value);
		}

		// DELETE: api/Druzyna/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return TryDelete(id);
		}
	}
}
