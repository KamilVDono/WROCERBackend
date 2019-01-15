#Generate DbSets
$pathes = ls
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    $className = ($path -replace ".cs" , "")
    $var = "public DbSet<" + $className + "> "+$className+"s { get; set; }"
    Write-Host $var
}

#Generate dictionary get
$pathes = ls
Write-Host '_DataDictionaryGet = new Dictionary<Type, Func<IEnumerable<AbstractDataModel>>>()'
Write-Host '{'
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    $className = ($path -replace ".cs" , "")
    $var = '{ typeof(' + $className + '), () => '+$className+'s.Cast<AbstractDataModel>().AsEnumerable()},'
    Write-Host $var
}
Write-Host '};'

#Generate dictionary update
$pathes = ls
Write-Host '_DataDictionaryUpdate = new Dictionary<Type, Action<AbstractDataModel>>()'
Write-Host '{'
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    $className = ($path -replace ".cs" , "")
    $var = '{ typeof(' + $className + '), (d) => '+$className+'s.Update(('+$className+')d)},'
    Write-Host $var
}
Write-Host '};'

#Generate dictionary remove _DataDictionaryRemove
$pathes = ls
Write-Host '_DataDictionaryRemove = new Dictionary<Type, Action<AbstractDataModel>>()'
Write-Host '{'
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    $className = ($path -replace ".cs" , "")
    $var = '{ typeof(' + $className + '), (d) => '+$className+'s.Remove(('+$className+')d)},'
    Write-Host $var
}
Write-Host '};'

#Generate dictionary update
$pathes = ls
Write-Host '_DataDictionaryAdd = new Dictionary<Type, Action<AbstractDataModel>>()'
Write-Host '{'
Foreach($path in $pathes){
    If($path -like "IData*" -or $path -like "Abstract*" -or $path -like "*.ps1"){
        continue
    }
    $className = ($path -replace ".cs" , "")
    $var = '{ typeof(' + $className + '), (d) => '+$className+'s.Add(('+$className+')d)},'
    Write-Host $var
}
Write-Host '};'