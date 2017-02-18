"%ProgramFiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" ..\DashAPI.sln /p:Configuration=Release /m

cd /d %~dp0
cd DashAPI
call .\nupack.bat

cd /d %~dp0