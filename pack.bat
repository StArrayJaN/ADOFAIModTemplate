@echo off
REM 打包 NuGet 模板包的脚本

echo ========================================
echo   ADOFAI Mod Template 打包工具
echo ========================================
echo.

REM 清理旧的包
echo [1/3] 清理旧的 NuGet 包...
del /Q *.nupkg 2>nul
del /Q *.snupkg 2>nul
echo 完成
echo.

REM 打包
echo [2/3] 打包模板...
dotnet pack ADOFAIModTemplate.Template.csproj -c Release -o .

if %ERRORLEVEL% EQU 0 (
    echo.
    echo [3/3] 打包成功！
    echo.
    echo ========================================
    echo   使用说明
    echo ========================================
    echo.
    echo 本地安装模板:
    echo   dotnet new install .\ADOFAIModTemplate.1.0.0.nupkg
    echo.
    echo 卸载模板:
    echo   dotnet new uninstall ADOFAIModTemplate
    echo.
    echo 使用模板创建项目:
    echo   dotnet new adofaimod -n MyMod
    echo.
    echo 发布到 NuGet.org:
    echo   dotnet nuget push ADOFAIModTemplate.1.0.0.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
    echo.
    echo ========================================
) else (
    echo.
    echo [错误] 打包失败！
    echo 请检查错误信息并重试。
    echo.
)

pause
