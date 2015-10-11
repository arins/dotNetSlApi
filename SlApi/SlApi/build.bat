
if "%ConfigurationName%" == "Release" (
	GOTO package
) ELSE (
	GOTO noPackage
)

:package
echo starting package beacause build mode is %ConfigurationName%
cd "%SolutionDir%"


nuget.exe restore %SolutionFileName%

echo test

cd

IF EXIST SlApi\bin\Release\net40 (
	rmdir /q /s SlApi\bin\Release\net40
)

IF EXIST SlApi\bin\Release\net45 (
	rmdir /q /s SlApi\bin\Release\net45
)

IF EXIST SlApi\bin\Release\net46 (
	rmdir /q /s SlApi\bin\Release\net46
)
IF EXIST SlApi\bin\Release\sl5 (
	rmdir /q /s SlApi\bin\Release\sl5
)

IF EXIST SlApi\bin\Release\SlApi (
	rmdir /q /s SlApi\bin\Release\SlApi
)

IF EXIST SlApi\bin\Release\windowsphone81 (
	rmdir /q /s SlApi\bin\Release\windowsphone81
)


mkdir SlApi\bin\Release\net40
mkdir SlApi\bin\Release\net45
mkdir SlApi\bin\Release\net46
mkdir SlApi\bin\Release\sl5
mkdir SlApi\bin\Release\SlApi
mkdir SlApi\bin\Release\windowsphone81

pause 10

echo copying net 4.0 ...
copy SlApi.Net40\bin\Release\SlApi.dll SlApi\bin\Release\net40\SlApi.dll

echo copying .net 4.5 ...
copy SlApi.Net45\bin\Release\SlApi.dll SlApi\bin\Release\net45\SlApi.dll

echo copying .net 4.6 ...
copy SlApi.Net46\bin\Release\SlApi.dll SlApi\bin\Release\net46\SlApi.dll

echo copying .net silverlight 5 ...
copy SlApi.Silverlight\bin\Release\SlApi.dll SlApi\bin\Release\sl5\SlApi.dll

echo copying .net windows phone 8.1 ...
copy SlApi.WindowsPhone8.1\bin\Release\SlApi.dll SlApi\bin\Release\windowsphone81\SlApi.dll

echo preparing for nuget packaging
copy SlApi\bin\Release\SlApi.dll SlApi\bin\Release\SlApi\SlApi.dll


echo packaging...
nuget.exe pack SlApi/SlApi.csproj -IncludeReferencedProjects -Prop Configuration=Release -Properties OutDir=%OutDir%




IF EXIST SlApi\bin\Release\net40 (
	rmdir /q /s SlApi\bin\Release\net40
)
IF EXIST SlApi\bin\Release\net45 (
	rmdir /q /s SlApi\bin\Release\net45
)
IF EXIST SlApi\bin\Release\net46 (
	rmdir /q /s SlApi\bin\Release\net46
)
IF EXIST SlApi\bin\Release\sl5 (
	rmdir /q /s SlApi\bin\Release\sl5
)
IF EXIST SlApi\bin\Release\SlApi (
	rmdir /q /s SlApi\bin\Release\SlApi
)


goto end


:noPackage
echo not packaging
echo %ConfigurationName%
GOTO END


:end