
set DOTNET_HOME=C:\Windows\Microsoft.NET\Framework\v4.0.30319
set BUILD=Debug
REM set BUILD=Release

%DOTNET_HOME%\RegAsm ..\bin\%BUILD%\PivoTurtle.dll /codebase /regfile:PivoTurtle.reg

copy /b PivoTurtle.reg+PivoTurtle-bare.reg PivoTurtle-%BUILD%.reg

pause
