@echo off
echo Building and setting up PUP_RMS...

cd /d "%~dp0\PUP_RMS"

echo.
echo 1. Cleaning old build...
if exist "bin\Debug\*" del /Q "bin\Debug\*"

echo.
echo 2. Copying Resources to Debug directory...
xcopy "Resources" "bin\Debug\Resources" /E /I /Y

echo.
echo 3. Copying tessdata files...
if not exist "bin\Debug\tessdata" mkdir "bin\Debug\tessdata"
REM You may need to manually download eng.traineddata and copy to tessdata folder
REM Download from: https://github.com/tesseract-ocr/tessdata/raw/main/eng.traineddata

echo.
echo 4. Setup complete!
echo.
echo Note: If Tesseract OCR shows "tessdata not found", download eng.traineddata from:
echo https://github.com/tesseract-ocr/tessdata/raw/main/eng.traineddata
echo and copy it to: bin\Debug\tessdata\
echo.
pause