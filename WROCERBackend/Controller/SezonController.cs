using System.Collections.Generic;
	using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataAccess;
using WROCERBackend.Model.DataModel;

	namespace WROCERBackend.Controller
	{
		[Route("api/[controller]")]
		[ApiController]
		public class SezonController : BaseController<DataSezon>
		{
			public SezonController(IDataAccess dataAccess)
			{
				_DataAccess = dataAccess;
			}

			// GET: api/Sezon
			[HttpGet]
			public ActionResult<IEnumerable<DataSezon>> Get()
			{
				return Ok(GetAll());
			}

			// GET: api/Sezon/5
			[HttpGet("{id}", Name = "GetDataSezon")]
			public ActionResult<DataSezon> Get(int id)
			{
				return TryGet(id);
			}

			// POST: api/Sezon
			[HttpPost]
			public ActionResult Post([FromBody] DataSezon value)
			{
				return TryPost(value);
			}

			// PUT: api/Sezon/5
			[HttpPut("{id}")]
			public ActionResult Put(int id, [FromBody] DataSezon value)
			{
				return TryPut(id, value);
			}

			// DELETE: api/Sezon/5
			[HttpDelete("{id}")]
			public ActionResult Delete(int id)
			{
				return TryDelete(id);
			}
		}
	}
