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
	public class MeczController : BaseController<DataMecz>
	{
		public MeczController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}

		// GET: api/Mecz
		[HttpGet]
		public ActionResult<IEnumerable<DataMecz>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/Mecz/5
		[HttpGet("{id}", Name = "GetMecz")]
		public ActionResult<DataMecz> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/Mecz/sezon/id/sedzia/id/gospodarz
		[HttpPost("sezon/{idSezon}/sedzia/{idSedzia}/gospodarz/{idGospodarz}/gosc/{idGosc}")]
		public ActionResult Post(int idSezon, int idSedzia, int idGospodarz, int idGosc, [FromBody] DataMecz value)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var sezon = _DataAccess.GetItem<DataSezon>(idSezon);
			if (sezon == null)
			{
				return NotFound();
			}

			var sedzia = _DataAccess.GetItem<DataUzytkownik>(idSedzia);
			if (sedzia == null)
			{
				return NotFound();
			}

			var gospodarz = _DataAccess.GetItem<DataDruzyna>(idGospodarz);
			if (gospodarz == null)
			{
				return NotFound();
			}

			var gosc = _DataAccess.GetItem<DataDruzyna>(idGosc);
			if (gosc == null)
			{
				return NotFound();
			}

			value.Sezon = sezon;
			value.Sedzia = sedzia;
			value.Gospodarz = gospodarz;
			value.Gosc = gosc;

			return TryPost(value);
		}

		// PUT: api/Mecz/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataMecz value)
		{
			return TryPut(id, value);
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return TryDelete(id);
		}
	}
}
