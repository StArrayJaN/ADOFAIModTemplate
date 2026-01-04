# ADOFAI UMM Mod Template

这是一个 A Dance of Fire and Ice (ADOFAI) 的 UnityModManager (UMM) Mod 开发模板项目。

## 项目结构

```
项目根目录/
├── ADOFAIModTemplate.csproj    # 项目文件
├── Main.cs                      # 主 Mod 类
├── ModSettings.cs               # Mod 设置类
├── Patches.cs                   # Harmony 补丁
├── Info.json                    # UMM Mod 信息文件
├── Properties/
│   └── AssemblyInfo.cs          # 程序集信息
└── Libraries/                   # 游戏依赖库（需要手动添加）
```

## 功能特性

- ✅ UnityModManager 集成
- ✅ Harmony 补丁支持
- ✅ 自动构建后复制到 out 文件夹
- ✅ 可配置的根命名空间
- ✅ Info.json 自动复制

## 开发环境

- .NET Framework 4.8.1
- Visual Studio 2019 或更高版本 / JetBrains Rider
- UnityModManager 0.27.0+
- Harmony 2.3.3

## 依赖库设置

模板需要 ADOFAI 游戏的依赖库。请将游戏的 DLL 文件复制到 `Libraries/` 文件夹：

```
Libraries/
├── ModManager/
│   ├── 0Harmony.dll
│   └── UnityModManager.dll
├── Assembly-CSharp.dll
├── UnityEngine.dll
└── ... (其他 Unity 模块)
```

你可以从游戏安装目录的以下位置找到这些文件：
- `<游戏目录>/A Dance of Fire and Ice_Data/Managed/`
- `<游戏目录>/Mods/UnityModManager/` (UMM 相关 DLL)

## 构建项目

### 使用 Visual Studio
1. 打开 `ADOFAIModTemplate.sln`
2. 选择 Debug 或 Release 配置
3. 按 F6 或点击"生成" -> "生成解决方案"
4. 构建完成后，DLL 和 Info.json 会自动复制到 `out/` 文件夹
5. 如果配置了游戏路径，会自动部署到游戏 Mods 文件夹并启动游戏

### 使用命令行
```bash
dotnet build ADOFAIModTemplate.sln -c Release
```

### 配置游戏路径
如果创建项目时没有指定游戏路径，可以手动编辑 `.csproj` 文件：
```xml
<PropertyGroup>
  <GameExePath>C:\Games\ADOFAI\A Dance of Fire and Ice.exe</GameExePath>
</PropertyGroup>
```

配置后，每次构建都会自动：
1. 复制文件到 `out/` 文件夹
2. 部署到游戏的 `Mods/ModName/` 文件夹
3. 启动游戏

## 安装 Mod

构建完成后，将 `out/` 文件夹中的所有文件复制到 ADOFAI 的 Mods 文件夹中：
```
<ADOFAI安装目录>/Mods/ADOFAIModTemplate/
```

## 开发指南

1. 在 `Class1.cs` 中实现你的 Mod 功能
2. 使用 Harmony 创建补丁类来修改游戏行为
3. 更新 `Info.json` 中的 Mod 信息
4. 根据需要添加更多类文件

## 使用此模板

### 安装模板
```bash
# 从本地文件夹安装（开发测试）
dotnet new install . --force

# 从 NuGet 包安装
dotnet new install .\StArray.ADOFAIModTemplate.1.0.0.nupkg
```

### 从模板创建新项目
```bash
# 基础用法（使用 --name 或 -n 指定项目名称）
dotnet new adofaimod --name MyModName

# 完整参数
dotnet new adofaimod -n MyModName -d "My Mod Description" -a "Your Name" -v "1.0.0"

# 带游戏路径（自动部署和启动）
dotnet new adofaimod -n MyModName -g "C:\Games\ADOFAI\A Dance of Fire and Ice.exe"
```

### 参数说明
- `-n, --name`: 项目名称（必需，会自动替换所有 ADOFAIModTemplate）
- `-d, --description`: Mod 描述
- `-a, --author`: 作者名称
- `-v, --version`: 版本号
- `-g, --game-path`: 游戏 exe 路径（可选，用于自动部署和启动游戏）

### 卸载模板
```bash
dotnet new uninstall StArray.ADOFAIModTemplate
```
dotnet new uninstall ADOFAIModTemplate
```

## 打包和发布模板

### 打包为 NuGet 包
```bash
# 使用脚本打包（Windows）
pack.bat

# 或手动打包
dotnet pack ADOFAIModTemplate.Template.csproj -o .

# 从 NuGet 包安装
dotnet new install ADOFAIModTemplate.1.0.0.nupkg
```

### 发布到 NuGet.org
```bash
# 打包
dotnet pack ADOFAIModTemplate.Template.csproj -c Release

# 发布（需要 API Key）
dotnet nuget push ADOFAIModTemplate.1.0.0.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

### 从 NuGet.org 安装
```bash
dotnet new install ADOFAIModTemplate
```
