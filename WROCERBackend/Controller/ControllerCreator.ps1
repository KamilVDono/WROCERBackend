$pathes = get-childitem "..\Model\DataModel" -recurse
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    $className = ($path -replace ".cs" , "")
    $var = "public DbSet<" + $className + "> "+$className+"s { get; set; }"
    
    $typ = ($path -replace ".cs" , "")
    $controllerName = ($typ -replace "Data" , "")
    $class = "using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WROCERBackend.Model.DataModel;

    namespace WROCERBackend.Controller
    {
	    [Route(""api/[controller]"")]
	    [ApiController]
	    public class "+$controllerName+"Controller : BaseController<$typ>
	    {
		    // GET: api/$controllerName
		    [HttpGet]
		    public ActionResult<IEnumerable<$typ>> Get()
		    {
			    return Ok(GetAll());
		    }

		    // GET: api/$controllerName/5
		    [HttpGet(""{id}"", Name = ""Get$typ"")]
		    public ActionResult<$typ> Get(int id)
		    {
			    return TryGet(id);
		    }

		    // POST: api/$controllerName
		    [HttpPost]
		    public ActionResult Post([FromBody] $typ value)
		    {
			    return TryPost(value);
		    }

		    // PUT: api/$controllerName/5
		    [HttpPut(""{id}"")]
		    public ActionResult Put(int id, [FromBody] $typ value)
		    {
			    return TryPut(id, value);
		    }

		    // DELETE: api/$controllerName/5
		    [HttpDelete(""{id}"")]
		    public ActionResult Delete(int id)
		    {
			    return TryDelete(id);
		    }
	    }
    }"

    $path2 = $controllerName + "Controller.cs"

    If(Test-Path $path2 -PathType Leaf)
    {
        Write-Host "$path2 File Exists"
    }
    Else
    {
        $class | Out-File -FilePath $path2
        Write-Host "$path2 File Created"
    }

}