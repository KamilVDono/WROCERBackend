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


$content3 = ""
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    
    $typ = ($path -replace ".cs" , "")
    $controllerName = ($typ -replace "Data" , "")

    $content3 += "FillDatabase"+"$controllerName"+"("+"$controllerName"+");
    "
}

Write-Host $content3

$content4 = ""
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    
    $typ = ($path -replace ".cs" , "")
    $controllerName = ($typ -replace "Data" , "")

    $content4 += "
    private static void FillDatabase"+"$controllerName"+"(List<"+$typ+"> "+"$controllerName"+")
		{
			foreach (var dataDruzyna in "+"$controllerName"+")
			{
				var json = Serialize(dataDruzyna);
				SendAsync(BaseUri, ""$controllerName"", json);
			}
		}
    "
}

Write-Host $content4

$content5 = ""
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    
    $typ = ($path -replace ".cs" , "")
    $controllerName = ($typ -replace "Data" , "")

    $content5 += "
    List<"+$typ+"> "+$controllerName+" = new List<"+$typ+">()
			{
				new "+$typ+"(),
			};
    "
}

Write-Host $content5