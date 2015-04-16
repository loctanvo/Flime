$root = $env:APPVEYOR_BUILD_FOLDER
$versionStr = $env:APPVEYOR_BUILD_VERSION

Write-Host $root
Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\source\Fluent.Time\Fluent.Time.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\source\Fluent.Time\Fluent.Time.nuspec