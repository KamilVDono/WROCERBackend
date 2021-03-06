using System.Collections.Generic;
	using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataAccess;
using WROCERBackend.Model.DataModel;

	namespace WROCERBackend.Controller
	{
		[Route("api/[controller]")]
		[ApiController]
		public class SytuacjaMeczowaController : BaseController<DataSytuacjaMeczowa>
		{
			public SytuacjaMeczowaController(IDataAccess dataAccess)
			{
				_DataAccess = dataAccess;
			}

			// GET: api/SytuacjaMeczowa
			[HttpGet]
			public ActionResult<IEnumerable<DataSytuacjaMeczowa>> Get()
			{
				return Ok(GetAll());
			}

			// GET: api/SytuacjaMeczowa/5
			[HttpGet("{id}", Name = "GetDataSytuacjaMeczowa")]
			public ActionResult<DataSytuacjaMeczowa> Get(int id)
			{
				return TryGet(id);
			}

			// POST: api/SytuacjaMeczowa
			[HttpPost("gracz/{idGracz}/typ/{idTyp}")]
			public ActionResult Post(int idGracz, int idTyp, [FromBody] DataSytuacjaMeczowa value)
			{
				var gracz = _DataAccess.GetItem<DataGracz>(idGracz);
				if (gracz == null) return NotFound();

				var typ = _DataAccess.GetItem<DataSytuacjaTyp>(idTyp);
				if (typ == null) return NotFound();

				value.Gracz = gracz;
				value.Typ = typ;

				return TryPost(value);
			}

			// PUT: api/SytuacjaMeczowa/5
			[HttpPut("{id}")]
			public ActionResult Put(int id, [FromBody] DataSytuacjaMeczowa value)
			{
				return TryPut(id, value);
			}

			// DELETE: api/SytuacjaMeczowa/5
			[HttpDelete("{id}")]
			public ActionResult Delete(int id)
			{
				return TryDelete(id);
			}
		}
	}
