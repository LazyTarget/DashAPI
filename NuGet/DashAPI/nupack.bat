rmdir package /s /q
mkdir .\package\lib\net45
copy ..\..\DashAPI\bin\Release\DashAPI.dll .\package\lib\net45\

copy .\DashAPI.nuspec .\package\DashAPI.nuspec
..\nuget pack .\package\DashAPI.nuspec
mkdir .\releases
move .\DashAPI.*.nupkg .\releases\
rmdir package /s /q