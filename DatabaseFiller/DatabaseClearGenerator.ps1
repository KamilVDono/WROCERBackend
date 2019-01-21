$pathes = get-childitem "..\WROCERBackend\Model\DataModel" -recurse

$header1 = "public static void ClearDatabase()
		{
"
$content1 = ""
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    
    $className = ($path -replace ".cs" , "")
    $var = "public DbSet<" + $className + "> "+$className+"s { get; set; }"
    
    $typ = ($path -replace ".cs" , "")
    $controllerName = ($typ -replace "Data" , "")
    $content1 = $content1 + "
    ClearDatabase" + $controllerName + "();"
}
$bottom1 = "
}"
$fn1 = $header1+$content1+$bottom1
Write-Host $fn1

$fn2 = ""
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    $className = ($path -replace ".cs" , "")
    $var = "public DbSet<" + $className + "> "+$className+"s { get; set; }"
    
    $typ = ($path -replace ".cs" , "")
    $controllerName = ($typ -replace "Data" , "")
    $fn2 = $fn2 +"
    " + "private static void ClearDatabase"+$controllerName+"()
		{
			var items = Deserialize<$typ>(BaseUri + ""$controllerName"");
			foreach (var item in items)
			{
				DeleteItem(BaseUri, item.ID, ""$controllerName"");
			}
		}"
}
Write-Host $fn2

