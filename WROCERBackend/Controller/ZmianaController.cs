using System.Collections.Generic;
	using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataAccess;
using WROCERBackend.Model.DataModel;

	namespace WROCERBackend.Controller
	{
		[Route("api/[controller]")]
		[ApiController]
		public class ZmianaController : BaseController<DataZmiana>
		{

			public ZmianaController(IDataAccess dataAccess)
			{
				_DataAccess = dataAccess;
			}

			// GET: api/Zmiana
			[HttpGet]
			public ActionResult<IEnumerable<DataZmiana>> Get()
			{
				return Ok(GetAll());
			}

			// GET: api/Zmiana/5
			[HttpGet("{id}", Name = "GetDataZmiana")]
			public ActionResult<DataZmiana> Get(int id)
			{
				return TryGet(id);
			}

			// POST: api/Zmiana
			[HttpPost("wchodzacy/{idWchodzacy}/schodzacy/{idSchodzacy}")]
			public ActionResult Post(int idWchodzacy, int idSchodzacy, [FromBody] DataZmiana value)
			{
				var wchodzacy = _DataAccess.GetItem<DataGracz>(idWchodzacy);
				if (wchodzacy == null) return NotFound();

				var schodzacy = _DataAccess.GetItem<DataGracz>(idSchodzacy);
				if (schodzacy == null) return NotFound();

				value.Wchodzacy = wchodzacy;
				value.Schodzacy = schodzacy;

				return TryPost(value);
			}

			// PUT: api/Zmiana/5
			[HttpPut("{id}")]
			public ActionResult Put(int id, [FromBody] DataZmiana value)
			{
				return TryPut(id, value);
			}

			// DELETE: api/Zmiana/5
			[HttpDelete("{id}")]
			public ActionResult Delete(int id)
			{
				return TryDelete(id);
			}
		}
	}
