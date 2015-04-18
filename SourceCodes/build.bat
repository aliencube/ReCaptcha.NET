@echo off

reg.exe query "HKLM\SOFTWARE\Microsoft\MSBuild\ToolsVersions\4.0" /v MSBuildToolsPath > nul 2>&1
if ERRORLEVEL 1 goto MissingMSBuildRegistry

for /f "skip=2 tokens=2,*" %%A in ('reg.exe query "HKLM\SOFTWARE\Microsoft\MSBuild\ToolsVersions\4.0" /v MSBuildToolsPath') do SET MSBUILDDIR=%%B

IF NOT EXIST %MSBUILDDIR%nul goto MissingMSBuildToolsPath
IF NOT EXIST %MSBUILDDIR%msbuild.exe goto MissingMSBuildExe

::BUILD
"tools\nuget.exe" restore ReCaptcha.sln
"%MSBUILDDIR%msbuild.exe" "03_Services\ReCaptcha.Wrapper\ReCaptcha.Wrapper.csproj" /t:ReBuild /p:Configuration=Release;TargetFrameworkVersion=v4.5;DefineConstants="TRACE;NET45";OutPutPath=bin\Release\net45\;DocumentationFile=bin\Release\net45\Aliencube.ReCaptcha.Wrapper.xml
"%MSBUILDDIR%msbuild.exe" "03_Services\ReCaptcha.Wrapper\ReCaptcha.Wrapper.Mvc.csproj" /t:ReBuild /p:Configuration=Release;TargetFrameworkVersion=v4.5;DefineConstants="TRACE;NET45";OutPutPath=bin\Release\net45\;DocumentationFile=bin\Release\net45\Aliencube.ReCaptcha.Wrapper.Mvc.xml

IF [%1]==[] GOTO MissingApiKey

mkdir build
del "build\*.nupkg"

::SET API KEY
"tools\nuget.exe" setApiKey %1

::PACK
"tools\nuget.exe" pack "03_Services\ReCaptcha.Wrapper\ReCaptcha.Wrapper.nuspec" -OutputDirectory build
"tools\nuget.exe" pack "03_Services\ReCaptcha.Wrapper.Mvc\ReCaptcha.Wrapper.Mvc.nuspec" -OutputDirectory build

::DEPLOY
"tools\nuget.exe" push "build\*.nupkg"

goto:eof
::ERRORS
::---------------------
:MissingApiKey
echo API Key not found
goto:eof
:MissingMSBuildRegistry
echo Cannot obtain path to MSBuild tools from registry
goto:eof
:MissingMSBuildToolsPath
echo The MSBuild tools path from the registry '%MSBUILDDIR%' does not exist
goto:eof
:MissingMSBuildExe
echo The MSBuild executable could not be found at '%MSBUILDDIR%'
goto:eof