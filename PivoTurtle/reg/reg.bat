
set DOTNET_HOME=C:\Windows\Microsoft.NET\Framework64\v4.0.30319
set BUILD=Debug
#set BUILD=Release

copy PivoTurtle-bare.reg PivoTurtle.reg
%DOTNET_HOME%\RegAsm bin\%BUILD%\PivoTurtle.dll /codebase /regfile:PivoTurtle.reg

pause
