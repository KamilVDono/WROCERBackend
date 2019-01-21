using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataAccess;
using WROCERBackend.Model.DataModel;
using WROCERBackend.Utils;

namespace WROCERBackend.Controller
{
	/// <summary>
	/// Base class for controllers in WROCERBackend project.
	/// Provide basic implementation of controllers functions.
	/// </summary>
	/// <typeparam name="T">Type of Data Model mainly used by controller</typeparam>
	public class BaseController<T> : ControllerBase where T : AbstractDataModel
	{
		protected IDataAccess _DataAccess;

		protected IEnumerable<T> GetAll()
		{
			return _DataAccess.GetAll<T>();
		}

		protected IEnumerable<T> GetWhere(Func<T, bool> whereFunc)
		{
			return _DataAccess.GetAll<T>().Where(whereFunc);
		}

		protected ActionResult<T> TryGet(int id)
		{
			var item = _DataAccess.GetItem<T>(id);

			if (item == null)
			{
				return NotFound();
			}

			return Ok(item);
		}

		protected ActionResult TryPost(T value)
		{
			var success = _DataAccess.AddItem(value);

			if (success)
			{
				return CreatedAtAction("Get", value);
			}
			return Conflict("Can not add element");
		}

		protected ActionResult TryPut(int id, T value)
		{
			T toUpdateItem = _DataAccess.GetItem<T>(id);

			if (value == null || toUpdateItem == null)
			{
				return NotFound();
			}

			value.CopyProperties(toUpdateItem);

			return _DataAccess.UpdateItem(toUpdateItem) == false ? 
				(ActionResult)NotFound() : (ActionResult)Ok();
		}

		protected ActionResult TryDelete(int id)
		{
			var item = _DataAccess.GetItem<T>(id);

			if (item == null)
			{
				return NotFound();
			}

			var success = _DataAccess.RemoveItem(item);

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
