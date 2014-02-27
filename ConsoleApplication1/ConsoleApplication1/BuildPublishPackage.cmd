@echo off

:: Set repository info
set key=klucz123
set url= http://172.17.18.12/MyNuget/

:: Make sure the nuget executable is writable
attrib -R NuGet.exe

:: Make sure the nupkg files are writeable and create backup
IF EXIST *.nupkg (
	echo.
	echo Creating backup...
	forfiles /m *.nupkg /c "cmd /c attrib -R @File"
	forfiles /m *.nupkg /c "cmd /c move /Y @File @File.bak"
)

echo.
echo Updating NuGet...
cmd /c nuget.exe update -Self

echo.
echo Creating package...
nuget.exe spec -f
nuget.exe pack  %1.csproj

//nuget.exe pack  %1.csproj -Verbose -Version %2
//nuget.exe pack %1.nuspec -Verbosity -Version %2

:: Check if package should be published
IF /I "%2"=="Publish" goto :publish
goto :eof

:publish
IF EXIST *.nupkg (
	echo.
	echo Publishing package...
	echo API Key: %key%
	echo NuGet Url: %url%
	forfiles /m *.nupkg /c "cmd /c nuget.exe push @File %key% -Source %url%"
	goto :eof
)

:eof