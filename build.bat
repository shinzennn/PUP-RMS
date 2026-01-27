@echo off
echo Building PUP_RMS project...
cd /d "%~dp0\PUP_RMS"

REM Try to restore NuGet packages
echo Restoring NuGet packages...
nuget restore packages.config -PackagesDirectory packages

REM Try to build with MSBuild
echo Building with MSBuild...
msbuild PUP_RMS.csproj /p:Configuration=Debug /verbosity:minimal

if %ERRORLEVEL% EQU 0 (
    echo Build successful!
) else (
    echo Build failed with error code %ERRORLEVEL%
)

pause